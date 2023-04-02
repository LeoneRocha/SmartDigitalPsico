import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { ActivatedRoute, Router } from '@angular/router';
import swal from 'sweetalert2';
import { LanguageOptions } from 'app/common/language-options';
import { CaptureTologFunc } from 'app/common/app-error-handler';
import { GetMsgServiceResponse } from 'app/common/GetMsgServiceResponse'; 
import { UserModel } from 'app/models/principalsmodel/UserModel';
import { UserService } from 'app/services/general/principals/user.service';
@Component({
    moduleId: module.id,
    selector: 'add-edit-usermanagement',
    templateUrl: 'add-edit-usermanagement.component.html'
    //styleUrls: ['./usermanagement.component.css']
})
//5-  a lista
export class AddEditUserManagementComponent implements OnInit {
    registerId: number;
    registerForm: FormGroup;
    isUpdateRegister: boolean = false;
    isModeViewForm: boolean = false;
    registerModel: UserModel;
    serviceResponse: ServiceResponse<UserModel>;
    public languages = LanguageOptions;

    constructor(@Inject(ActivatedRoute) private route: ActivatedRoute,
        @Inject(UserService) private registerService: UserService,
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
            formsElement.controls['rolePolicyClaimCode'].disable();
        }
        this.registerId = Number(paramsUrl.get('id'));
    }
    ngAfterViewInit() {
    }
    loadRegister() {
        this.registerService.getById(this.registerId).subscribe({
            next: (response: ServiceResponse<UserModel>) => { this.processLoadRegister(response); }, error: (err) => { this.processLoadRegisterErro(err); },
        });
    }
    addRegister() {
        this.getValuesForm();
        this.registerService.add(this.registerModel).subscribe({
            next: (response: ServiceResponse<UserModel>) => { this.processAddRegister(response); }, error: (err) => { this.processAddRegisterErro(err); },
        });
    }
    updateRegister() {
        this.getValuesForm();
        this.registerService.update(this.registerModel).subscribe({
            next: (response: ServiceResponse<UserModel>) => { this.processUpdateRegister(response); }, error: (err) => { this.processUpdateRegisterErro(err); },
        });
    }
    processAddRegister(response: ServiceResponse<UserModel>) {
        CaptureTologFunc('processAddRegister-usermanagement', response);
        this.serviceResponse = response;
        if (response?.errors?.length == 0) {
            this.modalSuccessAlert();
        } else {
            this.modalErroAlert("Error adding!", response);
        }
        this.goBackToList();
    }
    processAddRegisterErro(response: ServiceResponse<UserModel>) {
        CaptureTologFunc('processAddRegisterErro-usermanagement', response);
        this.modalErroAlert("Error adding!", response);
    }

    processUpdateRegister(response: ServiceResponse<UserModel>) {
        CaptureTologFunc('processUpdateRegister-usermanagement', response);
        this.serviceResponse = response;
        this.modalSuccessAlert();
    }
    processUpdateRegisterErro(response: ServiceResponse<UserModel>) {
        CaptureTologFunc('processUpdateRegisterErro-usermanagement', response);
        this.modalErroAlert("Error update!", response);
    }

    processLoadRegister(response: ServiceResponse<UserModel>) {
        CaptureTologFunc('processLoadRegister-usermanagement', response);
        this.serviceResponse = response;
        this.fillFieldsForm();
        this.isUpdateRegister = true && !this.isModeViewForm;
    }
    processLoadRegisterErro(response: ServiceResponse<UserModel>) {
        CaptureTologFunc('processLoadRegisterErro-usermanagement', response);
        this.modalErroAlert("Error load!", response);
    }
    fillFieldsForm(): void {
        let responseData: any = this.serviceResponse?.data;
        let formsElement = this.registerForm;
        this.registerModel = {
            id: responseData?.id,
            name: responseData?.name,
            email: responseData?.email,
            enable: responseData?.enable, 
            medicalId : responseData?.medicalId, 
        };
        let modelEntity = this.registerModel;
        formsElement.controls['name'].setValue(modelEntity?.name);
        formsElement.controls['email'].setValue(modelEntity?.email);
        formsElement.controls['medicalId'].setValue(modelEntity?.medicalId); 
        //this.registerModel_Enable = modelEntity?.enable;
        formsElement.controls['enableOpt'].setValue(modelEntity?.enable); 
    }
    isValidFormRolePolicyClaimCode(): boolean {
        let isValid = this.registerForm.get('rolePolicyClaimCode').errors?.required;
        return this.registerForm.controls['rolePolicyClaimCode'].touched
            && this.registerForm.controls['rolePolicyClaimCode'].invalid && isValid;
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
            rolePolicyClaimCode: new FormControl(false, Validators.required),
        });
    }
    getValuesForm() {
        let formElement = this.registerForm;
        this.registerModel = {
            id: this.registerId ? this.registerId : 0,
            name: formElement.controls['name']?.value, 
            email: formElement.controls['email']?.value, 
            enable: formElement.controls['enableOpt']?.value, 
            medicalId: formElement.controls['enableOpt']?.value, 
        }; 
        //console.log(this.registerModel);
    }
    createEmptyRegister(): void {
        this.registerModel = {
            id: 0,
            name: '',
            email:'',            
            enable: false,
        }
    }
    onSelect(selectedValue: string) {
        //console.log(selectedValue);
        //demo
    }
    goBackToList() {
        this.router.navigate(['/administrative/usermanagement']);
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
    modalErroAlert(msgErro: string, response: ServiceResponse<UserModel>) {
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