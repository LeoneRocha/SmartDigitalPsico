import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { GenderModel } from 'app/models/GenderModel';
import { NgForm } from '@angular/forms';
import { ServiceResponse } from 'app/models/ServiceResponse';

@Component({
    moduleId: module.id,
    selector: 'add-edit-gender',
    templateUrl: 'add-edit-gender.component.html'
    //styleUrls: ['./gender.component.css']
})

//1- fazer funcionar o create - ok 
//2- fazer funcionar o update
//3- tratativa de menssagem  generico se possivel e cptura do erro.
//4- Validador dos campos- tratativa de menssagem  generico se possivel e cptura do erro.
//5- Arrumar navegacao e botoes da lista

export class AddEditGenderComponent implements OnInit {
    registerId: number = 20001;
    registerForm: FormGroup;
    isUpdateGender: boolean = false;
    public registerModel: GenderModel;
    serviceResponse: ServiceResponse<GenderModel>

    public languages = [
        { code: 'pt-BR', name: 'pt-BR' },
        { code: 'pt-BR', name: 'en-US' }
    ];
    constructor(
        @Inject(GenderService) private registerService: GenderService
        , private fb: FormBuilder) {
        this.gerateFormRegister();
    }
    ngOnInit() {

        this.loadRegister();

        //if (!this.registerModel.id)
        this.createEmptyRegister();
    }
    ngAfterViewInit() {

    }
    addRegister() {
        this.getValuesForm();
        this.registerService.add(this.registerModel).subscribe({
            next: (response) => {
                this.serviceResponse = response;
                console.log(this.serviceResponse);
                //this.toastr.success('Employee Added successfully', 'Add New Employee');
                //this.CloseDialog();
            },
            error: (err) => {
                console.log(err);
                //this.toastr.error('Error adding employee', 'Add New Employee');
            },
        });
    }
    updateRegister() {
        this.getValuesForm();
        this.registerService.add(this.registerModel).subscribe({
            next: (response) => {
                this.serviceResponse = response;
                console.log(this.serviceResponse);
                //this.toastr.success('Employee Added successfully', 'Add New Employee');
                //this.CloseDialog();
            },
            error: (err) => {
                console.log(err);
                //this.toastr.error('Error adding employee', 'Add New Employee');
            },
        });
    }

    loadRegister() {

        let idLoaded: number;
        let descriptionLoaded: string;
        let languageLoaded: string;

        this.registerService.getById(this.registerId).subscribe({
            next: (response) => {
                this.serviceResponse = response;
                console.log(response);
            },
            error: (err) => {
                console.log(err);
                // this.toastr.error('Error Fetching Data, Please try again');
            },
        });

        this.registerModel = {
            id: idLoaded,
            description: descriptionLoaded,
            language: languageLoaded
        };
        this.registerForm.controls['description'].setValue(descriptionLoaded);
        this.registerForm.controls['language'].setValue(descriptionLoaded);
    }

    isValidFormDescription(): boolean {

        let isValid = this.registerForm.get('description').errors?.required;
        return this.registerForm.controls['description'].touched && this.registerForm.controls['description'].invalid && isValid;
    }
    isValidFormLanguage(): boolean {
        let isValid = this.registerForm.get('language').errors?.required;
        return this.registerForm.controls['language'].touched && this.registerForm.controls['language'].invalid && isValid;
    }
    gerateFormRegister() {
        this.registerForm = this.fb.group({
            id: new FormControl(),
            description: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            language: new FormControl('', Validators.required)
        });
    }
    getValuesForm() {
        this.registerModel = {
            id: 0,
            description: this.registerForm?.controls['description']?.value,
            language: this.registerForm?.controls['language']?.value
        };
    }
    createEmptyRegister(): void {
        this.registerModel = {
            id: 0,
            description: '',
            language: ''
        }
    }
}

