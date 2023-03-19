import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core';
import { GenderModel } from 'app/models/GenderModel';
import { Router } from '@angular/router';
import swal from 'sweetalert2';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { CaptureTologFunc } from 'app/common/app-error-handler';
declare interface TableData {
    headerRow: string[];
    dataRows: string[][];
}
declare var $: any;
declare interface DataTable {
    headerRow: string[];
    footerRow: string[];
    dataRows: string[][];
}

@Component({
    moduleId: module.id,
    selector: 'genderlist',
    templateUrl: 'gender.component.html'
    //styleUrls: ['./gender.component.css']
})

export class GenderComponent implements OnInit {
    public tableData1: TableData;
    public listResult: GenderModel[];
    serviceResponse: ServiceResponse<GenderModel>;
    public dataTable: DataTable;

    constructor(@Inject(GenderService) private registerService: GenderService, @Inject(Router) private router: Router) { }
    ngOnInit() {
        this.retrieveList();
        this.loadFakeDataSimple();
        this.loadFakeData();
    }
    ngAfterViewInit() {
    }
    newRegister(): void {
        this.router.navigate(['/pages/genderaction']);
    }
    viewRegister(idRegister: number): void {
        this.router.navigate(['/pages/genderaction', { modeForm: 'view', id: idRegister }]);
    }
    editRegister(idRegister: number): void {
        this.router.navigate(['/pages/genderaction', { modeForm: 'edit', id: idRegister }]);
    }
    removeRegister(idRegister: number): void {
        this.modalAlertRemove(idRegister);
        //this.router.navigate(['/pages/genderaction']); 
        //TODO: REMOVER SEM PRECISAR RECARREGAR
    }
    retrieveList(): void {
        this.registerService.getAll().subscribe({
            next: (response: any) => { this.listResult = response["data"];; this.loadConfigDataTablesLazzy(); CaptureTologFunc('retrieveList-gender', response); },
            error: (err) => { this.showNotification('top', 'center', 'Erro ao conectar!', 'danger'); }
        });
    }
    executeDeleteRegister(idRegister: number) {
        this.registerService.delete(idRegister).subscribe({
            next: (response: any) => { CaptureTologFunc('executeDeleteRegister-gender', response); this.modalAlertDeleted(); },
            error: (err) => { this.modalErroAlert('Error of delete.'); }
        });
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
    modalAlertDeleted() {
        swal.fire({
            title: 'Deleted!',
            text: 'Your imaginary file has been deleted.',
            icon: 'success',
            customClass: {
                confirmButton: "btn btn-fill btn-success",
            },
            buttonsStyling: false
        });
    }
    modalAlertCancelled() {
        swal.fire({
            title: 'Cancelled',
            text: 'Your imaginary file is safe :)',
            icon: 'error',
            customClass: {
                confirmButton: "btn btn-fill btn-info",
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
    showNotification(from, align, messageCustom: string, colorType: string) {
        //var type = ['','info','success','warning','danger']; 
        $.notify({
            icon: "pe-7s-attention",
            message: messageCustom
        }, {
            type: colorType,
            timer: 4000,
            placement: {
                from: from,
                align: align
            }
        });
    }
    //TODO - https://stackoverflow.com/questions/38321634/change-boolean-values-to-text-in-angular-2-client-side
    loadConfigDataTablesLazzy(): void {
        setTimeout(() => { 
            this.loadConfigDataTables(); 
          }, 500);
    }
    loadConfigDataTables(): void {
        $('#datatables').DataTable({
            "pagingType": "full_numbers",
            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
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
    loadFakeDataSimple() {
        this.tableData1 = {
            headerRow: ['#', 'Description', 'Language', 'Enable', 'Actions'],
            dataRows: []
        };
    }
    loadFakeData() {
        this.dataTable = {
            headerRow: ['Id', 'Description', 'Language', 'Enable', 'Actions'],
            footerRow: ['Id', 'Description', 'Language', 'Enable', 'Actions'],
            dataRows: []
        };
    }
} 