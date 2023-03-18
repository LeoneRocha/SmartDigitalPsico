import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core';
import { GenderModel } from 'app/models/GenderModel';
import { ActivatedRoute, Router } from '@angular/router';
import swal from 'sweetalert2';
import { ServiceResponse } from 'app/models/ServiceResponse';


declare interface TableData {
    headerRow: string[];
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
    serviceResponse: ServiceResponse<GenderModel>

    constructor(@Inject(GenderService) private registerService: GenderService, @Inject(Router) private router: Router) { }
    ngOnInit() {
        this.retrieveList();
        this.tableData1 = {
            headerRow: ['#', 'Description', 'Language', 'Enable', 'Actions'],
            dataRows: []
        };
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
        //alert('Not implemented');
    }
    retrieveList(): void {
        this.registerService.getAll()
            .subscribe({
                next: (response) => {
                    this.listResult = response["data"];
                    console.log(this.listResult);
                },
                error: (e) => console.error(e)
            });
    }
    executeDeleteRegister(idRegister: number) {
        this.registerService.delete(idRegister).subscribe({
            next: (response) => {
                this.modalAlertDeleted();
                console.log(response);
            },
            error: (err) => {
                console.log(err);
                // this.toastr.error('Error Fetching Data, Please try again');
            },
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
} 