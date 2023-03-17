import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core';
import { GenderModel } from 'app/models/GenderModel';
import { ActivatedRoute, Router } from '@angular/router';
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
    public tableData3: TableData;
    state_plain: boolean = true;
    public listResult: GenderModel[];

    constructor(@Inject(GenderService) private genderService: GenderService, @Inject(Router) private router: Router) { }
    ngOnInit() {
        this.retrieveList();
        this.tableData1 = {
            headerRow: ['#', 'Description', 'Language', 'Enable', 'Actions'],
            dataRows: []
        };
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
        //this.router.navigate(['/pages/genderaction']);
        alert('Not implemented');
    } 
    retrieveList(): void {
        this.genderService.getAll()
            .subscribe({
                next: (response) => {
                    this.listResult = response["data"];
                    console.log(this.listResult);
                },
                error: (e) => console.error(e)
            });
    }
    ngAfterViewInit() {
    }
}