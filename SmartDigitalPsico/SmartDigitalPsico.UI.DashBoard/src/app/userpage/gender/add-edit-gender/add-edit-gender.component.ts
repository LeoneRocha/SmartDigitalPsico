import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core'; 
 
@Component({
    moduleId: module.id,
    selector: 'add-edit-gender',
    templateUrl: 'add-edit-gender.component.html'
    //styleUrls: ['./gender.component.css']
})

export class AddEditGenderComponent implements OnInit {
    
    constructor(@Inject(GenderService) private genderService: GenderService) { }

    ngOnInit() {
        
    } 
     
    ngAfterViewInit() {

    }
}
