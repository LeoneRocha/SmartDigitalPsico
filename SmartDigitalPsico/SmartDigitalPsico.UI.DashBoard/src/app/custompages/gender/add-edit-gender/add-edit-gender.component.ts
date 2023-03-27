import { Component, OnInit } from '@angular/core';
import { GenderService } from 'app/services/general/simple/gender.service';
import { Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { GenderModel } from 'app/models/SimpleModel/GenderModel';
import { GetMsgServiceResponse, ServiceResponse } from 'app/models/ServiceResponse';
import { ActivatedRoute, Router } from '@angular/router';
import swal from 'sweetalert2';
import { LanguageOptions } from 'app/common/language-options';
import { CaptureTologFunc } from 'app/common/app-error-handler';
@Component({
    moduleId: module.id,
    selector: 'add-edit-gender',
    templateUrl: 'add-edit-gender.component.html'
    //styleUrls: ['./gender.component.css']
})
//5-  a lista

export class AddEditGenderComponent implements OnInit {
    registerId: number;
    registerForm: FormGroup;
    isUpdateRegister: boolean = false;
    isModeViewForm: boolean = false;
    registerModel: GenderModel;
    serviceResponse: ServiceResponse<GenderModel>;
    public languages = LanguageOptions;

    constructor(@Inject(ActivatedRoute) private route: ActivatedRoute,
        @Inject(GenderService) private registerService: GenderService,
        private fb: FormBuilder, @Inject(Router) private router: Router) {
        this.gerateFormRegister();
    }
    ngOnInit() {
        this.loadFormRegister();
        if (this.registerId)
            this.loadRegister();

        if (this.registerModel?.id)
            this.createEmptyRegister();
    }
    loadFormRegister() {
        let formsElement = this.registerForm;
        let paramsUrl = this.route.snapshot.paramMap;
        this.isModeViewForm = paramsUrl.get('modeForm') === 'view';

        if (this.isModeViewForm) {
            formsElement.controls['description'].disable();
            formsElement.controls['language'].disable();
            formsElement.controls['enableOpt'].disable();
        }
        this.registerId = Number(paramsUrl.get('id'));
    }
    ngAfterViewInit() {
    }
    loadRegister() {
        this.registerService.getById(this.registerId).subscribe({
            next: (response: ServiceResponse<GenderModel>) => { this.processLoadRegister(response); }, error: (err) => { this.processLoadRegisterErro(err); },
        });
    }
    addRegister() {
        this.getValuesForm();
        this.registerService.add(this.registerModel).subscribe({
            next: (response: ServiceResponse<GenderModel>) => { this.processAddRegister(response); }, error: (err) => { this.processAddRegisterErro(err); },
        });
    }
    updateRegister() {
        this.getValuesForm();
        this.registerService.update(this.registerModel).subscribe({
            next: (response: ServiceResponse<GenderModel>) => { this.processUpdateRegister(response); }, error: (err) => { this.processUpdateRegisterErro(err); },
        });
    }
    processAddRegister(response: ServiceResponse<GenderModel>) {
        CaptureTologFunc('processAddRegister-gender', response);
        this.serviceResponse = response;
        if (response?.errors?.length == 0) {
            this.modalSuccessAlert();
        } else {
            this.modalErroAlert("Error adding!", response);
        }
        this.goBackToList();
    }
    processAddRegisterErro(response: ServiceResponse<GenderModel>) {
        CaptureTologFunc('processAddRegisterErro-gender', response);
        this.modalErroAlert("Error adding!", response);
    }

    processUpdateRegister(response: ServiceResponse<GenderModel>) {
        CaptureTologFunc('processUpdateRegister-gender', response);
        this.serviceResponse = response;
        this.modalSuccessAlert();
    }
    processUpdateRegisterErro(response: ServiceResponse<GenderModel>) {
        CaptureTologFunc('processUpdateRegisterErro-gender', response);
        this.modalErroAlert("Error update!", response);
    }

    processLoadRegister(response: ServiceResponse<GenderModel>) {
        CaptureTologFunc('processLoadRegister-gender', response);
        this.serviceResponse = response;
        this.fillFieldsForm();
        this.isUpdateRegister = true && !this.isModeViewForm;
    }
    processLoadRegisterErro(response: ServiceResponse<GenderModel>) {
        CaptureTologFunc('processLoadRegisterErro-gender', response);
        this.modalErroAlert("Error load!", response);
    }
    fillFieldsForm(): void {
        let responseData: any = this.serviceResponse?.data;
        let formsElement = this.registerForm;
        this.registerModel = {
            id: responseData?.id,
            description: responseData?.description,
            language: responseData?.language,
            enable: responseData?.enable,
        };
        let modelEntity = this.registerModel;
        formsElement.controls['description'].setValue(modelEntity?.description);
        formsElement.controls['language'].setValue(modelEntity?.language);
        //this.registerModel_Enable = modelEntity?.enable;
        formsElement.controls['enableOpt'].setValue(modelEntity?.enable);
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
            language: new FormControl('', Validators.required),
            enableOpt: new FormControl(false, Validators.required),
        });
    }
    getValuesForm() {
        let formElement = this.registerForm;
        this.registerModel = {
            id: this.registerId ? this.registerId : 0,
            description: formElement.controls['description']?.value,
            language: formElement.controls['language']?.value,
            enable: formElement.controls['enableOpt']?.value,//this.registerModel_Enable,
        };
    }
    createEmptyRegister(): void {
        this.registerModel = {
            id: 0,
            description: '',
            language: '',
            enable: false
        }
    }
    onSelect(selectedValue: string) {
        //console.log(selectedValue);
        //demo
    }
    goBackToList() {
        this.router.navigate(['/administrative/gender']);
    }
    modalSuccessAlert() {
        swal.fire({
            title: "Register is saved!",
            text: "I will close in 5 seconds.",
            timer: 5000,
            buttonsStyling: false,
            customClass: {
                confirmButton: "btn btn-fill btn-success",
            },
            icon: "success"
        });
    }
    modalErroAlert(msgErro: string, response: ServiceResponse<GenderModel>) {
        swal.fire({
            title: msgErro,
            text: GetMsgServiceResponse(response),
            icon: 'error',
            customClass: {
                confirmButton: "btn btn-fill btn-info",
            },
            buttonsStyling: false
        });
    }
}