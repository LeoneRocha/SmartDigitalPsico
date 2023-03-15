import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core';
import { GenderModel, ServiceResponse } from 'app/models/GenderModel';
declare interface TableData {
    headerRow: string[];
    dataRows: string[][];
}
@Component({
    moduleId: module.id,
    selector: 'admingender',
    templateUrl: 'gender.component.html'
    //styleUrls: ['./gender.component.css']
})

export class GenderComponent implements OnInit {
    public tableData1: TableData;
    public tableData3: TableData;
    state_plain: boolean = true;

    public listResult: GenderModel[];


    constructor(@Inject(GenderService) private genderService: GenderService) { }

    ngOnInit() {
        this.retrieveList();
        this.tableData1 = {
            headerRow: ['#', 'Description', 'Language', 'Enable', 'Actions'],
            dataRows: []
        };
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
