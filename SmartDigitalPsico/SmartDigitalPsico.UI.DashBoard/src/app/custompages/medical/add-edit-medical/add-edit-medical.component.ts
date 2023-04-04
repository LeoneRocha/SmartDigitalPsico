import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { ActivatedRoute, Router } from '@angular/router';
import swal from 'sweetalert2';
import { CaptureTologFunc } from 'app/common/app-error-handler';
import { GetMsgServiceResponse } from 'app/common/GetMsgServiceResponse';
import { botaoAnimado } from 'app/common/animations/geral-trigger-animation';
import { MedicalModel } from 'app/models/principalsmodel/MedicalModel';
import { MedicalService } from 'app/services/general/principals/medical.service';
import { OfficeService } from 'app/services/general/simple/office.service';
import { OfficeModel } from 'app/models/simplemodel/OfficeModel';
import { ETypeAccreditationOptions } from 'app/common/etypeaccreditation-options';
import { SpecialtyService } from 'app/services/general/simple/specialty.service';
import { SpecialtyModel } from 'app/models/simplemodel/SpecialtyModel';
import { Observable, forkJoin } from 'rxjs';

declare var $: any;

@Component({
    moduleId: module.id,
    selector: 'add-edit-gender',
    templateUrl: 'add-edit-medical.component.html',
    //styleUrls: ['./gender.component.css']
    animations: [
        botaoAnimado
    ]
})
//5-  a lista
export class AddEditMedicalComponent implements OnInit {
    registerId: number;
    registerForm: FormGroup;
    isUpdateRegister: boolean = false;
    isModeViewForm: boolean = false;
    registerModel: MedicalModel;
    serviceResponse: ServiceResponse<MedicalModel>;
    estadoBotao_goBackToList = 'inicial';
    estadoBotao_addRegister = 'inicial';
    estadoBotao_updateRegister = 'inicial';
    public officesOpts: OfficeModel[];  ///ServiceResponse<OfficeModel>[];
    public specialtiesOpts: SpecialtyModel[];  //ServiceResponse<OfficeModel>[];
    officesOptsObs$: Observable<{}>;

    public typeAccreditationOpts = ETypeAccreditationOptions;

    constructor(@Inject(ActivatedRoute) private route: ActivatedRoute,
        private fb: FormBuilder,
        @Inject(Router) private router: Router,
        @Inject(MedicalService) private registerService: MedicalService,
        @Inject(OfficeService) private officeService: OfficeService,
        @Inject(SpecialtyService) private specialtyService: SpecialtyService,
    ) {

    }
    animarBotao(estado: string, stateBtn: string) {
        if (stateBtn === 'goBackToList')
            this.estadoBotao_goBackToList = estado;

        if (stateBtn === 'addRegister')
            this.estadoBotao_addRegister = estado;

        if (stateBtn === 'updateRegister')
            this.estadoBotao_updateRegister = estado;
    }
    ngOnInit() {
        this.loadOfficesAndSpcialty();
        //this.loadOffices();
        //this.loadSpecialties();
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
    loadOfficesAndSpcialty() {
        let request1 = this.officeService.getAll();
        let request2 = this.specialtyService.getAll();

        forkJoin([request1, request2]).subscribe(results => {
            this.officesOpts = results[0]['data'];
            this.specialtiesOpts = results[1]['data'];                        
            //console.log('loadOfficesAndSpcialty-1');
            //console.log(this.officesOpts);
            //console.log('loadOfficesAndSpcialty-2');
            //console.log(this.specialtiesOpts);
        });
    }
    loadOffices() {
        this.officeService.getAll().subscribe({
            next: (response: any) => { this.officesOpts = response['data']; }, error: (err) => { console.log(err); },
        });
        // console.log('loadOffices');
        //console.log(this.officesOpts); 
    }
    loadSpecialties() {
        this.specialtyService.getAll().subscribe({
            next: (response: any) => { this.specialtiesOpts = response['data']; }, error: (err) => { console.log(err); },
        });
        // console.log('loadSpecialties');
        // console.log(this.specialtiesOpts);
    }
    loadFormRegister() {
        let formsElement = this.registerForm;
        let paramsUrl = this.route.snapshot.paramMap;
        this.isModeViewForm = paramsUrl.get('modeForm') === 'view';
        if (this.isModeViewForm) {
            formsElement.controls['name'].disable();
            formsElement.controls['email'].disable();
            formsElement.controls['accreditation'].disable();
            formsElement.controls['typeAccreditation'].disable();
            formsElement.controls['officeId'].disable();
            formsElement.controls['specialtiesIds'].disable();
            formsElement.controls['enableOpt'].disable();
        }
        this.registerId = Number(paramsUrl.get('id'));
    }
    ngAfterViewInit() {
    }
    loadRegister() {
        this.registerService.getById(this.registerId).subscribe({
            next: (response: ServiceResponse<MedicalModel>) => { this.processLoadRegister(response); }, error: (err) => { this.processLoadRegisterErro(err); },
        });
    }
    addRegister() {
        this.getValuesForm();
        console.log(this.registerModel);
        /* this.registerService.add(this.registerModel).subscribe({
             next: (response: ServiceResponse<MedicalModel>) => { this.processAddRegister(response); }, error: (err) => { this.processAddRegisterErro(err); },
         });*/
    }
    updateRegister() {
        this.getValuesForm();
        this.registerService.update(this.registerModel).subscribe({
            next: (response: ServiceResponse<MedicalModel>) => { this.processUpdateRegister(response); }, error: (err) => { this.processUpdateRegisterErro(err); },
        });
    }
    processAddRegister(response: ServiceResponse<MedicalModel>) {
        CaptureTologFunc('processAddRegister-Medical', response);
        this.serviceResponse = response;
        if (response?.errors?.length == 0) {
            this.modalSuccessAlert();
        } else {
            this.modalErroAlert("Error adding!", response);
        }
        this.goBackToList();
    }
    processAddRegisterErro(response: ServiceResponse<MedicalModel>) {
        CaptureTologFunc('processAddRegisterErro-Medical', response);
        this.modalErroAlert("Error adding!", response);
    }

    processUpdateRegister(response: ServiceResponse<MedicalModel>) {
        CaptureTologFunc('processUpdateRegister-Medical', response);
        this.serviceResponse = response;
        this.modalSuccessAlert();
    }
    processUpdateRegisterErro(response: ServiceResponse<MedicalModel>) {
        CaptureTologFunc('processUpdateRegisterErro-Medical', response);
        this.modalErroAlert("Error update!", response);
    }

    processLoadRegister(response: ServiceResponse<MedicalModel>) {
        CaptureTologFunc('processLoadRegister-Medical', response);
        this.serviceResponse = response;
        this.fillFieldsForm();
        this.isUpdateRegister = true && !this.isModeViewForm;
    }
    processLoadRegisterErro(response: ServiceResponse<MedicalModel>) {
        CaptureTologFunc('processLoadRegisterErro-Medical', response);
        this.modalErroAlert("Error load!", response);
    }
    fillFieldsForm(): void {
        let responseData: any = this.serviceResponse?.data;
        let formsElement = this.registerForm;
        this.registerModel = {
            id: responseData?.id,
            name: responseData?.name,
            email: responseData?.email,
            accreditation: responseData?.accreditation,
            typeAccreditation: responseData?.typeAccreditation,
            officeId: responseData?.officeId,
            specialtiesIds: responseData?.specialtiesIds,
            enable: responseData?.enable,
        };
        let modelEntity = this.registerModel;
        formsElement.controls['name'].setValue(modelEntity?.name);
        formsElement.controls['email'].setValue(modelEntity?.email);
        formsElement.controls['accreditation'].setValue(modelEntity?.accreditation);
        formsElement.controls['typeAccreditation'].setValue(modelEntity?.typeAccreditation);
        formsElement.controls['officeId'].setValue(modelEntity?.officeId);
        formsElement.controls['specialtiesIds'].setValue(modelEntity?.specialtiesIds);
        formsElement.controls['enableOpt'].setValue(modelEntity?.enable);
    }
    isValidFormName(): boolean {
        let isValid = this.registerForm.get('name').errors?.required;
        return this.registerForm.controls['name'].touched && this.registerForm.controls['name'].invalid && isValid;
    }
    isValidFormEmail(): boolean {
        let isValid = this.registerForm.get('email').errors?.required;
        return this.registerForm.controls['email'].touched && this.registerForm.controls['email'].invalid && isValid;
    }
    isValidFormTypeAccreditation(): boolean {
        let isValid = this.registerForm.get('typeAccreditation').errors?.required;
        return this.registerForm.controls['typeAccreditation'].touched && this.registerForm.controls['typeAccreditation'].invalid && isValid;
    }
    isValidFormAccreditation(): boolean {
        let isValid = this.registerForm.get('accreditation').errors?.required;
        return this.registerForm.controls['accreditation'].touched && this.registerForm.controls['accreditation'].invalid && isValid;
    }
    isValidFormOfficeId(): boolean {
        let isValid = this.registerForm.get('officeId').errors?.required;
        return this.registerForm.controls['officeId'].touched && this.registerForm.controls['officeId'].invalid && isValid;
    }
    isValidFormSpecialtiesIds(): boolean {
        let isValid = this.registerForm.get('specialtiesIds').errors?.required;
        return this.registerForm.controls['specialtiesIds'].touched && this.registerForm.controls['specialtiesIds'].invalid && isValid;
    }
    gerateFormRegister() {
        this.registerForm = this.fb.group({
            id: new FormControl(),
            name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            email: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]),
            accreditation: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
            typeAccreditation: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            officeId: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            specialtiesIds: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
            enableOpt: new FormControl(false, Validators.required),
        });
    }
    getValuesForm() {
        let formElement = this.registerForm;
        this.registerModel = {
            id: this.registerId ? this.registerId : 0,
            name: formElement.controls['name']?.value,
            email: formElement.controls['email']?.value,
            accreditation: formElement.controls['accreditation']?.value,
            typeAccreditation: formElement.controls['typeAccreditation']?.value,
            officeId: formElement.controls['officeId']?.value,
            specialtiesIds: formElement.controls['specialtiesIds']?.value,
            enable: formElement.controls['enableOpt']?.value,
        };
    }
    createEmptyRegister(): void {
        this.registerModel = {
            id: 0,
            name: '',
            email: '',
            accreditation: '',
            typeAccreditation: 0,
            officeId: 0,
            specialtiesIds: [],
            enable: false
        }
    }
    onSelect(selectedValue: string) {
        //console.log(selectedValue); 
    }
    goBackToList() {
        this.router.navigate(['/administrative/Medical']);
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
    modalErroAlert(msgErro: string, response: ServiceResponse<MedicalModel>) {
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