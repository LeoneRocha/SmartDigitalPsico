import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/gender.service';
import { Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { GenderModel } from 'app/models/GenderModel';
import { NgForm } from '@angular/forms';

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

export class AddEditGenderComponent implements OnInit {

    registerForm: FormGroup;
    isUpdateGender: boolean = false;
    public registerModel: GenderModel;

    public languages = [
        { code: 'pt-BR', name: 'pt-BR' },
        { code: 'pt-BR', name: 'en-US' }
    ];
    constructor(
        @Inject(GenderService) private genderService: GenderService
        , private fb: FormBuilder) {
        this.gerateFormRegister();
    }
    ngOnInit() {
        this.createEmptyRegister();
    }
    ngAfterViewInit() {

    } 
    addRegister() { 
        this.getValuesForm();
        this.genderService.add(this.registerModel).subscribe({
            next: (res) => {
                console.log(res);
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
        this.genderService.add(this.registerModel).subscribe({
            next: (res) => {
                console.log(res);
                //this.toastr.success('Employee Added successfully', 'Add New Employee');
                //this.CloseDialog();
            },
            error: (err) => {
                console.log(err);
                //this.toastr.error('Error adding employee', 'Add New Employee');
            },
        });
    }
    isValidFormDescription(): boolean {

        let isValid = this.registerForm.get('description').errors?.required;

        return this.registerForm.controls['description'].touched && this.registerForm.controls['description'].invalid
            && isValid;
    }

    isValidFormLanguage(): boolean {

        let isValid = this.registerForm.get('language').errors?.required;

        return this.registerForm.controls['language'].touched && this.registerForm.controls['language'].invalid
            && isValid;
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

