import { Component, Input, OnInit } from '@angular/core';
import { DataTable } from 'app/models/general/DataTable';
import { SimpleModel } from 'app/models/contracts/SimpleModel';

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

  constructor() { }

  ngOnInit() {

  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.loadConfigDataTablesLazzy(this.dataTableIn);
    }, 1000);
  }

  viewRegister(register: any): void {
    let registerid: number = register[0];
    console.log(registerid);
    //this.router.idRegisternavigate(['/administrative/gender/genderaction', { modeForm: 'view', id: idRegister }]);
    //alert('id :' + register.toString());

  }
  editRegister(register: any): void {
    let registerid: number = register[0];
    console.log(registerid);
    //this.router.navigate(['/administrative/gender/genderaction', { modeForm: 'edit', id: idRegister }]);
    //lert('id :' + register.toString());
  }
  removeRegister(register: any): void {
    let registerid: number = register[0];
    console.log(registerid);
    //this.modalAlertRemove(idRegister);
    //alert('id :' + register.toString());
  }
  /*id =
          name = array2d[i][1];
          price = array2d[i][2];*/
  loadConfigDataTablesLazzy(dataTableVal: DataTable): void {
    //console.log(dataTableVal);
    //console.log(dataTableVal?.dataRows);
    //onsole.log(dataTableVal?.dataRows?.length);
    if (dataTableVal?.dataRows?.length > 0) {
      const lista1D = this.convertArray2dToList(dataTableVal?.dataRows);
      console.log(lista1D);
      this.loadConfigDataTables(lista1D, dataTableVal.headerRow);
    }
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

  loadConfigDataTables(listData: any, columnsData: any): void {

    console.log(columnsData);
    if (typeof listData !== 'undefined' && typeof listData !== null && listData.length > 0) {
      $('#datatables').DataTable({
        "pagingType": "full_numbers",
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        data: listData,
        columns: columnsData,
        responsive: true,
        language: {
          search: "_INPUT_",
          searchPlaceholder: "Search records",
        }
      });
    }
  }

  /*
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
