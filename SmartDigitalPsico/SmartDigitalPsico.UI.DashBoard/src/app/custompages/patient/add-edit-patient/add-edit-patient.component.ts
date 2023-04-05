import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { ActivatedRoute, Router } from '@angular/router';
import swal from 'sweetalert2';
import { CaptureTologFunc } from 'app/common/app-error-handler';
import { GetMsgServiceResponse } from 'app/common/GetMsgServiceResponse';
import { botaoAnimado } from 'app/common/animations/geral-trigger-animation';
import { PatientModel } from 'app/models/principalsmodel/PatientModel';
import { PatientService } from 'app/services/general/principals/patient.service';
import { OfficeModel } from 'app/models/simplemodel/OfficeModel';
import { ETypeAccreditationOptions } from 'app/common/etypeaccreditation-options';
import { SpecialtyModel } from 'app/models/simplemodel/SpecialtyModel';
import { forkJoin } from 'rxjs';

declare var $: any;

@Component({
    moduleId: module.id,
    selector: 'add-edit-patient',
    templateUrl: 'add-edit-patient.component.html',
    //styleUrls: ['./gender.component.css']
    animations: [
        botaoAnimado
    ]
})
//5-  a lista
export class AddEditPatientComponent implements OnInit {
    registerId: number;
    registerForm: FormGroup;
    isUpdateRegister: boolean = false;
    isModeViewForm: boolean = false;
    registerModel: PatientModel;
    serviceResponse: ServiceResponse<PatientModel>;
    estadoBotao_goBackToList = 'inicial';
    estadoBotao_addRegister = 'inicial';
    estadoBotao_updateRegister = 'inicial';
    public officesOpts: OfficeModel[];  ///ServiceResponse<OfficeModel>[];
    public specialtiesOpts: SpecialtyModel[];  //ServiceResponse<OfficeModel>[];  
    public typeAccreditationOpts = ETypeAccreditationOptions;

    constructor(@Inject(ActivatedRoute) private route: ActivatedRoute,
        private fb: FormBuilder,
        @Inject(Router) private router: Router,
        @Inject(PatientService) private registerService: PatientService,
    ) {

    }
    //https://netbasal.com/implementing-grouping-checkbox-behavior-with-angular-reactive-forms-9ba4e3ab3965
    animarBotao(estado: string, stateBtn: string) {
        if (stateBtn === 'goBackToList')
            this.estadoBotao_goBackToList = estado;

        if (stateBtn === 'addRegister')
            this.estadoBotao_addRegister = estado;

        if (stateBtn === 'updateRegister')
            this.estadoBotao_updateRegister = estado;
    }
    ngOnInit() {
        this.gerateFormRegister();
        this.loadFormRegister();
        if (this.registerId)
            this.loadRegister();

        if (this.registerModel?.id)
            this.createEmptyRegister();
    }
    ngAfterContentInit() {
        this.loadBoostrap();
    }
    loadBoostrap() {
        //  Activate the tooltips
        $('[rel="tooltip"]').tooltip();

        //  Init Bootstrap Select Picker
        if ($(".selectpicker").length != 0) {
            $(".selectpicker").selectpicker({
                iconBase: "fa",
                tickIcon: "fa-check"
            });
        }
    }

    loadFormRegister() {
        let formsElement = this.registerForm;
        let paramsUrl = this.route.snapshot.paramMap;
        this.isModeViewForm = paramsUrl.get('modeForm') === 'view';
        if (this.isModeViewForm) {
            formsElement.controls['name'].disable();
            formsElement.controls['email'].disable();
            formsElement.controls['addressCep'].disable();
            formsElement.controls['addressCity'].disable();
            formsElement.controls['addressNeighborhood'].disable();
            formsElement.controls['addressState'].disable();
            formsElement.controls['addressStreet'].disable();
            formsElement.controls['cpf'].disable();
            formsElement.controls['dateOfBirth'].disable();
            formsElement.controls['education'].disable();
            formsElement.controls['emergencyContactName'].disable();
            formsElement.controls['emergencyContactPhoneNumber'].disable();
            formsElement.controls['genderId'].disable();
            formsElement.controls['profession'].disable();
            formsElement.controls['rg'].disable();
            formsElement.controls['medicalId'].disable();
            formsElement.controls['enableOpt'].disable();
        }
        this.registerId = Number(paramsUrl.get('id'));
    }
    ngAfterViewInit() {
    }
    loadRegister() {
        this.registerService.getById(this.registerId).subscribe({
            next: (response: ServiceResponse<PatientModel>) => { this.processLoadRegister(response); }, error: (err) => { this.processLoadRegisterErro(err); },
        });
    }
    addRegister() {
        this.getValuesForm();
        this.registerService.add(this.registerModel).subscribe({
            next: (response: ServiceResponse<PatientModel>) => { this.processAddRegister(response); }, error: (err) => { this.processAddRegisterErro(err); },
        });
    }
    updateRegister() {
        this.getValuesForm();
        this.registerService.update(this.registerModel).subscribe({
            next: (response: ServiceResponse<PatientModel>) => { this.processUpdateRegister(response); }, error: (err) => { this.processUpdateRegisterErro(err); },
        });
    }
    processAddRegister(response: ServiceResponse<PatientModel>) {
        CaptureTologFunc('processAddRegister-Patient', response);
        this.serviceResponse = response;
        if (response?.errors?.length == 0) {
            this.modalSuccessAlert();
        } else {
            this.modalErroAlert("Error adding!", response);
        }
        this.goBackToList();
    }
    processAddRegisterErro(response: ServiceResponse<PatientModel>) {
        CaptureTologFunc('processAddRegisterErro-Patient', response);
        this.modalErroAlert("Error adding!", response);
    }

    processUpdateRegister(response: ServiceResponse<PatientModel>) {
        CaptureTologFunc('processUpdateRegister-Patient', response);
        this.serviceResponse = response;
        this.modalSuccessAlert();
    }
    processUpdateRegisterErro(response: ServiceResponse<PatientModel>) {
        CaptureTologFunc('processUpdateRegisterErro-Patient', response);
        this.modalErroAlert("Error update!", response);
    }

    processLoadRegister(response: ServiceResponse<PatientModel>) {
        CaptureTologFunc('processLoadRegister-Patient', response);
        this.serviceResponse = response;
        this.fillFieldsForm();
        this.isUpdateRegister = true && !this.isModeViewForm;
    }
    processLoadRegisterErro(response: ServiceResponse<PatientModel>) {
        CaptureTologFunc('processLoadRegisterErro-Patient', response);
        this.modalErroAlert("Error load!", response);
    }
    fillFieldsForm(): void {
        let responseData: PatientModel = this.serviceResponse?.data;
        let formsElement = this.registerForm;
        this.registerModel = {
            id: responseData?.id,
            name: responseData?.name,
            email: responseData?.email,
            addressCep: responseData?.addressCep,
            addressCity: responseData?.addressCity,
            addressNeighborhood: responseData?.addressNeighborhood,
            addressState: responseData?.addressState,
            addressStreet: responseData?.addressStreet,
            cpf: responseData?.cpf,
            dateOfBirth: responseData?.dateOfBirth,
            education: responseData?.education,
            emergencyContactName: responseData?.emergencyContactName,
            emergencyContactPhoneNumber: responseData?.emergencyContactPhoneNumber,
            genderId: responseData?.genderId,
            phoneNumber: responseData?.phoneNumber,
            profession: responseData?.profession,
            rg: responseData?.rg,
            medicalId: responseData?.medicalId,
            enable: responseData?.enable,
        };
        let modelEntity = this.registerModel;
        formsElement.controls['name'].setValue(modelEntity?.name);
        formsElement.controls['email'].setValue(modelEntity?.email);               
        formsElement.controls['addressCep'].setValue(modelEntity?.enable);
        formsElement.controls['addressCity'].setValue(modelEntity?.enable);
        formsElement.controls['addressNeighborhood'].setValue(modelEntity?.enable);
        formsElement.controls['addressState'].setValue(modelEntity?.enable);
        formsElement.controls['addressStreet'].setValue(modelEntity?.enable);
        formsElement.controls['cpf'].setValue(modelEntity?.enable);
        formsElement.controls['dateOfBirth'].setValue(modelEntity?.enable);
        formsElement.controls['education'].setValue(modelEntity?.enable);
        formsElement.controls['emergencyContactName'].setValue(modelEntity?.enable);
        formsElement.controls['emergencyContactPhoneNumber'].setValue(modelEntity?.enable);
        formsElement.controls['genderId'].setValue(modelEntity?.enable);
        formsElement.controls['phoneNumber'].setValue(modelEntity?.enable);
        formsElement.controls['profession'].setValue(modelEntity?.enable);
        formsElement.controls['rg'].setValue(modelEntity?.enable);
        formsElement.controls['medicalId'].setValue(modelEntity?.enable);  
        formsElement.controls['enableOpt'].setValue(modelEntity?.enable);      
    }
    isValidFormName(): boolean {
        let isRequired = this.registerForm.get('name').errors?.required;
        return this.registerForm.controls['name'].touched && this.registerForm.controls['name'].invalid && isRequired;
    }
    isValidFormEmail(): boolean {
        let isRequired = this.registerForm.get('email').errors?.required;
        return this.registerForm.controls['email'].touched && this.registerForm.controls['email'].invalid && isRequired;
    }
    isValidFormAddressCep(): boolean {
        let isRequired = this.registerForm.get('addressCep').errors?.required;
        return this.registerForm.controls['addressCep'].touched && this.registerForm.controls['addressCep'].invalid && isRequired;
    }
    isValidFormAddressCity(): boolean {
        let isRequired = this.registerForm.get('addressCity').errors?.required;
        return this.registerForm.controls['addressCity'].touched && this.registerForm.controls['addressCity'].invalid && isRequired;
    }
    isValidFormAddressNeighborhood(): boolean {
        let isRequired = this.registerForm.get('addressNeighborhood').errors?.required;
        return this.registerForm.controls['addressNeighborhood'].touched && this.registerForm.controls['addressNeighborhood'].invalid && isRequired;
    }
    isValidFormAddressState(): boolean {
        let isRequired = this.registerForm.get('addressState').errors?.required;
        return this.registerForm.controls['addressState'].touched && this.registerForm.controls['addressState'].invalid && isRequired;
    }
    isValidFormAddressStreet(): boolean {
        let isRequired = this.registerForm.get('addressStreet').errors?.required;
        return this.registerForm.controls['addressStreet'].touched && this.registerForm.controls['addressStreet'].invalid && isRequired;
    }
    isValidFormCPF(): boolean {
        let isRequired = this.registerForm.get('cpf').errors?.required;
        return this.registerForm.controls['cpf'].touched && this.registerForm.controls['cpf'].invalid && isRequired;
    }
    isValidFormDateOfBirth(): boolean {
        let isRequired = this.registerForm.get('dateOfBirth').errors?.required;
        return this.registerForm.controls['dateOfBirth'].touched && this.registerForm.controls['dateOfBirth'].invalid && isRequired;
    }
    isValidFormEducation(): boolean {
        let isRequired = this.registerForm.get('education').errors?.required;
        return this.registerForm.controls['education'].touched && this.registerForm.controls['education'].invalid && isRequired;
    }
    isValidFormEmergencyContactName(): boolean {
        let isRequired = this.registerForm.get('emergencyContactName').errors?.required;
        return this.registerForm.controls['emergencyContactName'].touched && this.registerForm.controls['emergencyContactName'].invalid && isRequired;
    }
    isValidFormEmergencyContactPhoneNumber(): boolean {
        let isRequired = this.registerForm.get('emergencyContactPhoneNumber').errors?.required;
        return this.registerForm.controls['emergencyContactPhoneNumber'].touched && this.registerForm.controls['emergencyContactPhoneNumber'].invalid && isRequired;
    }
    isValidFormPhoneNumber(): boolean {
        let isRequired = this.registerForm.get('phoneNumber').errors?.required;
        return this.registerForm.controls['phoneNumber'].touched && this.registerForm.controls['phoneNumber'].invalid && isRequired;
    }
    isValidFormProfession(): boolean {
        let isRequired = this.registerForm.get('profession').errors?.required;
        return this.registerForm.controls['profession'].touched && this.registerForm.controls['profession'].invalid && isRequired;
    }
    isValidFormRG(): boolean {
        let isRequired = this.registerForm.get('rg').errors?.required;
        return this.registerForm.controls['rg'].touched && this.registerForm.controls['rg'].invalid && isRequired;
    }
    isValidFormMedicalId(): boolean {
        let isRequired = this.registerForm.get('medicalId').errors?.required;
        return this.registerForm.controls['medicalId'].touched && this.registerForm.controls['medicalId'].invalid && isRequired;
    }
    isValidFormGenderId(): boolean {
        let isRequired = this.registerForm.get('genderId').errors?.required;
        return this.registerForm.controls['genderId'].touched && this.registerForm.controls['genderId'].invalid && isRequired;
    }
    gerateFormRegister() {
        this.registerForm = this.fb.group({
            id: new FormControl<number>(0),
            name: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            email: new FormControl<string>('', [Validators.required, Validators.email, Validators.maxLength(100)]),
            addressCep: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
            addressCity: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            addressNeighborhood: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            addressState: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            addressStreet: new FormControl<string>('', [Validators.required, Validators.email, Validators.maxLength(255)]),
            cpf: new FormControl<string>('', [Validators.required, Validators.minLength(10), Validators.maxLength(15)]),
            dateOfBirth: new FormControl<Date>(null, [Validators.required]),
            education: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            emergencyContactName: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            emergencyContactPhoneNumber: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
            phoneNumber: new FormControl<string>('', [Validators.required, Validators.minLength(10), Validators.maxLength(20)]),
            profession: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            rg: new FormControl<string>('', [Validators.required, Validators.minLength(10), Validators.maxLength(15)]),
            genderId: new FormControl<number>(0),
            medicalId: new FormControl<number>(0),
            enableOpt: new FormControl<boolean>(false, Validators.required),
        });
    }
    getValuesForm() {
        let formElement = this.registerForm;
        this.registerModel = {
            medicalId: formElement.controls['medicalId']?.value,

            id: this.registerId ? this.registerId : 0,
            name: formElement.controls['name']?.value,
            email: formElement.controls['email']?.value,
            addressCep: formElement.controls['addressCep']?.value,
            addressCity: formElement.controls['addressCity']?.value,
            addressNeighborhood: formElement.controls['addressNeighborhood']?.value,
            addressState: formElement.controls['addressState']?.value,
            addressStreet: formElement.controls['email']?.value,
            cpf: formElement.controls['cpf']?.value,
            dateOfBirth: formElement.controls['dateOfBirth']?.value,
            education: formElement.controls['education']?.value,
            emergencyContactName: formElement.controls['emergencyContactName']?.value,
            emergencyContactPhoneNumber: formElement.controls['emergencyContactPhoneNumber']?.value,
            genderId: formElement.controls['genderId']?.value,
            phoneNumber: formElement.controls['phoneNumber']?.value,
            profession: formElement.controls['profession']?.value,
            rg: formElement.controls['rg']?.value,
            enable: formElement.controls['enableOpt']?.value,
        };
    }

    setSpecialtiesOptsChecked(modelEntity): void {
        if (modelEntity?.specialtiesIds) {
            modelEntity?.specialtiesIds.forEach(specialtyId => {
                if (this.specialtiesOpts && this.specialtiesOpts.length > 0) {
                    const specialty = this.specialtiesOpts.find(opt => opt.id === specialtyId);
                    if (specialty) {
                        specialty.selected = true;
                    }
                }
            });
        }
    }

    createEmptyRegister(): void {
        this.registerModel = {
            id: 0,
            name: '',
            email: '',
            addressCep: '',
            addressCity: '',
            addressNeighborhood: '',
            addressState: '',
            addressStreet: '',
            cpf: '',
            dateOfBirth: null,
            education: '',
            emergencyContactName: '',
            emergencyContactPhoneNumber: '',
            genderId: 0,
            phoneNumber: '',
            profession: '',
            rg: '',
            medicalId: 0,
            enable: false
        }
    }
    onSelect(selectedValue: string) {
    }
    goBackToList() {
        this.router.navigate(['/Patient/manage/']);
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
    modalErroAlert(msgErro: string, response: ServiceResponse<PatientModel>) {
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
    onCheckboxChange(e) {
        const checkArray: FormArray = this.registerForm.get('specialtiesIds') as FormArray;
        if (e.target.checked) {
            checkArray.push(new FormControl(e.target.value));
        } else {
            let i: number = 0;
            checkArray.controls.forEach((item: FormControl) => {
                if (item.value == e.target.value) {
                    checkArray.removeAt(i);
                    return;
                }
                i++;
            });
        } //https://www.positronx.io/angular-checkbox-tutorial/          
    }
}

