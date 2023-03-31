import { Component, Inject, Input, OnInit } from '@angular/core';
import { DataTable } from 'app/models/general/DataTable';
import { SimpleModel } from 'app/models/contracts/SimpleModel';
import { Router } from '@angular/router';
import swal from 'sweetalert2';
import { GenderService } from 'app/services/general/simple/gender.service';
import { CaptureTologFunc } from 'app/common/app-error-handler';
import { GenderModel } from 'app/models/simplemodel/GenderModel';

declare var $: any;
@Component({
  selector: 'custom-genericdatatablegrid',
  templateUrl: './genericdatatablegrid.component.html'
})

export class GenericDataTableGrid implements OnInit {
  @Input() dataTableIn: DataTable;
  @Input() listDataIn: SimpleModel[];
  @Input() numberOfColumns: number
  public listResult: any[];

  constructor(@Inject(Router) private router: Router, @Inject(GenderService) private registerServiceGender: GenderService,) { }

  ngOnInit() {

  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.loadConfigDataTablesLazzy(this.dataTableIn);
    }, 1000);
  }

  viewRegister(register: any): void {
    let idRegister: number = register['id'];
    //console.log(idRegister);
    //console.log(register);
    this.router.navigate([this.dataTableIn?.routes?.baseRoute, { modeForm: 'view', id: idRegister }]);
    //alert('id :' + register.toString());

  }
  editRegister(register: SimpleModel): void {
    let idRegister: number = register['id'];
    //console.log(idRegister);
    //console.log(this.dataTableIn?.routes?.baseRoute);
    this.router.navigate([this.dataTableIn?.routes?.baseRoute, { modeForm: 'edit', id: idRegister }]);
    //lert('id :' + register.toString());
  }
  removeRegister(register: SimpleModel): void {
    let idRegister: number = register['id'];
    //console.log(idRegister);
    this.modalAlertRemove(idRegister);
    //alert('id :' + register.toString());
  }

  modalAlertRemove(idRegister: number) {
    swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover register!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it',
      customClass: {
        confirmButton: "btn btn-fill btn-success btn-mr-5",
        cancelButton: "btn btn-fill btn-danger",
      },
      buttonsStyling: false
    }).then((result) => {
      if (result.value) {
        this.executeDeleteRegister(idRegister);
      } else {
        this.modalAlertCancelled();
      }
    });
  }

  executeDeleteRegister(idRegister: number) {
    this.registerServiceGender.delete(idRegister).subscribe({
      next: (response: any) => {
        CaptureTologFunc('executeDeleteRegister-gender', response);
        //this.listResult = this.removeItemFromList<GenderModel>(this.dataTableIn.dataRows, idRegister);
        this.listResult = this.removeItemFromList<any>(this.dataTableIn.dataRows, idRegister);
        this.modalAlertDeleted();
      },
      error: (err) => { this.modalErroAlert('Error of delete.'); }
    });
  }

  removeItemFromList<T>(lista: Array<T>, idRemove: number): Array<T> {
    const registerFinded = lista.find(p => p["id"] === idRemove);
    let indexReg = lista.indexOf(registerFinded);
    lista.splice(indexReg, 1);
    return lista;
  }
  modalAlertCancelled() {
    swal.fire({
      title: 'Cancelled',
      text: "Register hasn't been deleted",
      icon: 'error',
      customClass: {
        confirmButton: "btn btn-fill btn-info",
      },
      buttonsStyling: false
    });
  }
  modalAlertDeleted() {
    swal.fire({
      title: 'Deleted!',
      text: 'Register has been deleted. I will close in 5 seconds.',
      timer: 5000,
      icon: 'success',
      customClass: {
        confirmButton: "btn btn-fill btn-success",
      },
      buttonsStyling: false
    });
  }
  modalErroAlert(msgErro: string) {
    swal.fire({
      title: 'Error!',
      text: msgErro,
      icon: 'error',
      customClass: {
        confirmButton: "btn btn-fill btn-info",
      },
      buttonsStyling: false
    });
  }
  loadConfigDataTablesLazzy(dataTableVal: any): void {
    //console.log(dataTableVal);
    //console.log(dataTableVal?.dataRows);
    //onsole.log(dataTableVal?.dataRows?.length);
    /*if (dataTableVal?.dataRows?.length > 0) {
      const lista1D = this.convertArray2dToList(dataTableVal?.dataRows);
      console.log(lista1D);
      this.loadConfigDataTables(lista1D, dataTableVal.headerRow);
    }*/
    this.loadConfigDataTablesV1();
  }

  convertArray2dToList(array2d): SimpleModel[] {
    const list = [];
    for (let i = 0; i < array2d.length; i++) {
      const obj: SimpleModel = {
        id: array2d[i][0],
        description: array2d[i][1],
        enable: array2d[i][2],
        language: array2d[i][3],
      }
      list.push(obj);
    }
    return list;
  }

  loadConfigDataTablesV1(): void {
    $('#datatables').DataTable({
      "pagingType": "full_numbers",
      "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
      //data: listData,
      //columns: columnsData,
      responsive: true,
      language: {
        search: "_INPUT_",
        searchPlaceholder: "Search records",
      }
    });

    var table = $('#datatables').DataTable();

    // Edit record
    table.on('click', '.edit', function () {
      //var $tr = $(this).closest('tr');
      //var data = table.row($tr).data();
      //alert('You press on Row: ' + data[0] + ' ' + data[1] + ' ' + data[2] + '\'s row.');
    });
    // Delete a record
    table.on('click', '.remove', function (e) {
      //var $tr = $(this).closest('tr');
      //table.row($tr).remove().draw();
      //e.preventDefault();
    });
    //Like record
    table.on('click', '.like', function () {
      // alert('You clicked on Like button');
    });
  }
  /*

    loadConfigDataTables(listData: any, columnsData: any): void {

    console.log(columnsData);
    if (typeof listData !== 'undefined' && typeof listData !== null && listData.length > 0) {
      $('#datatables').DataTable({
        "pagingType": "full_numbers",
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
       //data: listData,
        //columns: columnsData,
        responsive: true,
        language: {
          search: "_INPUT_",
          searchPlaceholder: "Search records",
        }
      });
    }
  }

  var table = $('#datatables').DataTable();

    // Edit record
    table.on('click', '.edit', function () {
        //var $tr = $(this).closest('tr');
        //var data = table.row($tr).data();
        //alert('You press on Row: ' + data[0] + ' ' + data[1] + ' ' + data[2] + '\'s row.');
    });
    // Delete a record
    table.on('click', '.remove', function (e) {
        //var $tr = $(this).closest('tr');
        //table.row($tr).remove().draw();
        //e.preventDefault();
    });
    //Like record
    table.on('click', '.like', function () {
        // alert('You clicked on Like button');
    });

    public listResult: GenderModel[];
    serviceResponse: ServiceResponse<GenderModel>;
  */
}
