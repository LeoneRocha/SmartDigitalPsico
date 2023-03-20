import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core';
import { GenderModel } from 'app/models/GenderModel';
import { Router } from '@angular/router';
import swal from 'sweetalert2';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { CaptureTologFunc } from 'app/common/app-error-handler';

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
    public listResult: GenderModel[];
    serviceResponse: ServiceResponse<GenderModel>;
    public dataTable: DataTable;

    constructor(@Inject(GenderService) private registerService: GenderService, @Inject(Router) private router: Router) { }
    ngOnInit() {
        this.retrieveList();
        this.loadHeaderFooterDataTable();
    }
    ngAfterViewInit() {
    }
    newRegister(): void {
        this.router.navigate(['/adminpages/gender/genderaction']);
    }
    viewRegister(idRegister: number): void {
        this.router.navigate(['/adminpages/gender/genderaction', { modeForm: 'view', id: idRegister }]);
    }
    editRegister(idRegister: number): void {
        this.router.navigate(['/adminpages/gender/genderaction', { modeForm: 'edit', id: idRegister }]);
    }
    removeRegister(idRegister: number): void {
        this.modalAlertRemove(idRegister);
    }
    retrieveList(): void {
        this.registerService.getAll().subscribe({
            next: (response: any) => { this.listResult = response["data"]; this.loadConfigDataTablesLazzy(); CaptureTologFunc('retrieveList-gender', response); },
            error: (err) => { this.showNotification('top', 'center', 'Erro ao conectar!', 'danger'); }
        });
    }
    executeDeleteRegister(idRegister: number) {

        this.registerService.delete(idRegister).subscribe({
            next: (response: any) => {
                CaptureTologFunc('executeDeleteRegister-gender', response);
                this.listResult = this.removeItemFromList<GenderModel>(this.listResult, idRegister);
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
            text: 'Register has been deleted. I will close in 5 seconds.',
            timer: 5000,
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
            text: "Register hasn't been deleted",
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
    loadHeaderFooterDataTable() {
        this.dataTable = {
            headerRow: ['Id', 'Description', 'Language', 'Enable', 'Actions'],
            footerRow: ['Id', 'Description', 'Language', 'Enable', 'Actions'],
            dataRows: []
        };
    }
} 