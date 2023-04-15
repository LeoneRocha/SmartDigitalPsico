import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { ActivatedRoute, Router } from '@angular/router';
import swal from 'sweetalert2';
import { CaptureTologFunc } from 'app/common/errohandler/app-error-handler';
import { GetMsgServiceResponse } from 'app/common/helpers/GetMsgServiceResponse';
import { botaoAnimado } from 'app/common/animations/geral-trigger-animation';
import { GenderModel } from 'app/models/simplemodel/GenderModel';
import { ETypeMaritalStatusOptions } from 'app/common/enuns/etypemaritalstatus-options';
import { DatePipe } from '@angular/common';
import { LanguageService } from 'app/services/general/language.service'; 
import { PatientMedicationInformationModel } from 'app/models/principalsmodel/PatientMedicationInformationModel';
import { PatientMedicationInformationService } from 'app/services/general/principals/patientmedicationinformation.service';
declare var $: any;

@Component({
    moduleId: module.id,
    selector: 'add-edit-patient_patientmedicationinformation',
    templateUrl: 'add-edit-patientmedicationinformation.component.html',
    //styleUrls: ['./gender.component.css']
    animations: [
        botaoAnimado
    ]
})
//5-  a lista
export class AddEditPatientMedicationInformationComponent implements OnInit {
    registerId: number;
    registerForm: FormGroup;
    isUpdateRegister: boolean = false;
    isModeViewForm: boolean = false;
    registerModel: PatientMedicationInformationModel;
    serviceResponse: ServiceResponse<PatientMedicationInformationModel>;
    estadoBotao_goBackToList = 'inicial';
    estadoBotao_addRegister = 'inicial';
    estadoBotao_updateRegister = 'inicial';
    public gendersOpts: GenderModel[];
    public maritalStatusOpts = ETypeMaritalStatusOptions;
    parentId: number;
    constructor(@Inject(ActivatedRoute) private route: ActivatedRoute
        , private fb: FormBuilder
        , @Inject(Router) private router: Router
        , @Inject(PatientMedicationInformationService) private registerService: PatientMedicationInformationService
        , private datePipe: DatePipe
        , @Inject(LanguageService) private languageService: LanguageService
    ) {
    } 
    ngOnInit() {
        this.languageService.loadLanguage();

        this.getPatientId();
        this.gerateFormRegister();
        this.loadFormRegister();
        if (this.registerId)
            this.loadRegister();

        if (this.registerModel?.id)
            this.createEmptyRegister();
    }
    ngAfterContentInit() {
        this.loadBoostrap();
        this.loadDatePicker();
    }
    private getPatientId(): number {
        let paramsUrl = this.route.snapshot.paramMap;
        this.parentId = Number(paramsUrl.get('parentId'));
        return this.parentId;
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
            formsElement.controls['cid'].disable();
            formsElement.controls['description'].disable();
            formsElement.controls['dosage'].disable();
            formsElement.controls['mainDrug'].disable();
            formsElement.controls['posology'].disable(); 
            formsElement.controls['startDate'].disable();
            formsElement.controls['endDate'].disable();
            formsElement.controls['enableOpt'].disable();
        }
        this.registerId = Number(paramsUrl.get('id'));
    }
    ngAfterViewInit() {
    }
    loadRegister() {
        this.registerService.getById(this.registerId).subscribe({
            next: (response: ServiceResponse<PatientMedicationInformationModel>) => { this.processLoadRegister(response); }, error: (err) => { this.processLoadRegisterErro(err); },
        });
    }
    addRegister() {
        //console.log(this.registerModel);
        this.getValuesForm();
        console.log(this.registerModel);
        this.registerService.add(this.registerModel).subscribe({
            next: (response: ServiceResponse<PatientMedicationInformationModel>) => { this.processAddRegister(response); }, error: (err) => { this.processAddRegisterErro(err); },
        });
    }
    updateRegister() {
        //console.log(this.registerModel);
        this.getValuesForm();
        console.log(this.registerModel);
        this.registerService.update(this.registerModel).subscribe({
            next: (response: ServiceResponse<PatientMedicationInformationModel>) => { this.processUpdateRegister(response); }, error: (err) => { this.processUpdateRegisterErro(err); },
        });
    }
    processAddRegister(response: ServiceResponse<PatientMedicationInformationModel>) {
        CaptureTologFunc('processAddRegister-Patient', response);
        this.serviceResponse = response;
        if (response?.errors?.length == 0) {
            this.modalSuccessAlert();
            this.goBackToList();
        } else {
            this.modalErroAlert(this.gettranslateInformationAsync('modalalert.saved.erro'), response);
        }
    }
    processAddRegisterErro(response: ServiceResponse<PatientMedicationInformationModel>) {
        CaptureTologFunc('processAddRegisterErro-Patient', response);
        this.modalErroAlert(this.gettranslateInformationAsync('modalalert.saved.erro'), response);
    }

    processUpdateRegister(response: ServiceResponse<PatientMedicationInformationModel>) {
        CaptureTologFunc('processUpdateRegister-Patient', response);
        this.serviceResponse = response;
        this.modalSuccessAlert();
    }
    processUpdateRegisterErro(response: ServiceResponse<PatientMedicationInformationModel>) {
        CaptureTologFunc('processUpdateRegisterErro-Patient', response);
        this.modalErroAlert(this.gettranslateInformationAsync('modalalert.saved.erroupdate'), response);
    }

    processLoadRegister(response: ServiceResponse<PatientMedicationInformationModel>) {
        CaptureTologFunc('processLoadRegister-Patient', response);
        this.serviceResponse = response;
        this.fillFieldsForm();
        this.isUpdateRegister = true && !this.isModeViewForm;
    }
    processLoadRegisterErro(response: ServiceResponse<PatientMedicationInformationModel>) {
        CaptureTologFunc('processLoadRegisterErro-Patient', response);
        this.modalErroAlert(this.gettranslateInformationAsync('modalalert.load.title'), response);
    }
    fillFieldsForm(): void {
        let formatDate = 'dd/MM/yyyy';
        let cultureUi = 'en'
        let pipeDate = new DatePipe('pt-BR');

        let responseData: PatientMedicationInformationModel = this.serviceResponse?.data;
        let formsElement = this.registerForm;
        this.registerModel = {
            id: responseData?.id,     
            patientId: responseData?.patientId,
            description: responseData?.description, 
            dosage: responseData?.dosage, 
            mainDrug: responseData?.mainDrug, 
            posology: responseData?.posology, 
            endDate: responseData?.endDate, 
            startDate: responseData?.startDate,
            enable: responseData?.enable,
        };
        let modelEntity = this.registerModel;

        let text_startDate  = this.datePipe.transform(modelEntity?.startDate, 'yyyy-MM-dd');
        let text_endDate  = this.datePipe.transform(modelEntity?.startDate, 'yyyy-MM-dd');

        //formsElement.controls['patientId'].setValue(modelEntity?.patientId); 
        formsElement.controls['description'].setValue(modelEntity?.description); 
        formsElement.controls['dosage'].setValue(modelEntity?.dosage); 
        formsElement.controls['mainDrug'].setValue(modelEntity?.mainDrug); 
        formsElement.controls['posology'].setValue(modelEntity?.posology); 
        formsElement.controls['startDate'].setValue(text_startDate);
        formsElement.controls['endDate'].setValue(text_endDate);
        formsElement.controls['enableOpt'].setValue(modelEntity?.enable);
        //console.log(modelEntity);
    }
    isValidFormDosage(): boolean {
        let isRequired = this.registerForm.get('dosage').errors?.required;
        return this.registerForm.controls['dosage'].touched && this.registerForm.controls['dosage'].invalid && isRequired;
    }
    isValidFormMainDrug(): boolean {
        let isRequired = this.registerForm.get('mainDrug').errors?.required;
        return this.registerForm.controls['mainDrug'].touched && this.registerForm.controls['mainDrug'].invalid && isRequired;
    }
    isValidFormPosology(): boolean {
        let isRequired = this.registerForm.get('posology').errors?.required;
        return this.registerForm.controls['posology'].touched && this.registerForm.controls['posology'].invalid && isRequired;
    }
    isValidFormDescription(): boolean {
        let isRequired = this.registerForm.get('description').errors?.required;
        return this.registerForm.controls['description'].touched && this.registerForm.controls['description'].invalid && isRequired;
    }

    isValidFormStartDate(): boolean {
        let isRequired = this.registerForm.get('startDate').errors?.required;
        return this.registerForm.controls['startDate'].touched && this.registerForm.controls['startDate'].invalid && isRequired;
    }     isValidFormEndDate(): boolean {
        let isRequired = this.registerForm.get('endDate').errors?.required;
        return this.registerForm.controls['endDate'].touched && this.registerForm.controls['endDate'].invalid && isRequired;
    } 
    gerateFormRegister() {
        this.registerForm = this.fb.group({
            id: new FormControl<number>(0),            
            description: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),            
            dosage: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(250)]),
            mainDrug: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(250)]),            
            posology: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(250)]),
            startDate: new FormControl<Date>(new Date(), [Validators.required]),            
            endDate: new FormControl<Date>(new Date(), [Validators.required]),
            patientId: new FormControl<number>(0),
            enableOpt: new FormControl<boolean>(false, Validators.required),
        });
    }

    getValuesForm() {
        let formElement = this.registerForm;
        this.registerModel = {
            patientId: this.parentId ? this.parentId : 0,
            id: this.registerId ? this.registerId : 0,            
            description: formElement.controls['description']?.value,
            dosage: formElement.controls['dosage']?.value,
            mainDrug: formElement.controls['mainDrug']?.value,
            posology: formElement.controls['posology']?.value,
            startDate: formElement.controls['startDate']?.value,
            endDate: formElement.controls['endDate']?.value,            
            enable: formElement.controls['enableOpt']?.value,
        };
    }
    createEmptyRegister(): void {
        this.registerModel = {
            id: 0, 
            description: '',
            dosage : '',
            mainDrug : '',
            posology : '', 
            startDate: new Date(), 
            endDate: new Date(),
            patientId: 0,
            enable: false
        }
    }
    onSelect(selectedValue: string) {
        console.log(this.registerForm);
    }
    goBackToList() {
        this.router.navigate(['/patient/manage/patientmedicationinformation', { parentId: this.parentId }]);
    }
    gettranslateInformationAsync(key: string): string {
        let result = this.languageService.translateInformationAsync([key])[0];
        //console.log(result);
        return result;
    }
    modalSuccessAlert() {
        swal.fire({
            title: this.gettranslateInformationAsync('modalalert.saved.title'),//"Register is saved!",
            text: this.gettranslateInformationAsync('modalalert.saved.text'),//"I will close in 5 seconds.",
            timer: 5000,
            buttonsStyling: false,
            customClass: {
                confirmButton: "btn btn-fill btn-success",
            },
            icon: "success"
        });
    }
    modalErroAlert(msgErro: string, response: ServiceResponse<PatientMedicationInformationModel>) {
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

    loadDatePicker(): void {
        $('.datepicker').datetimepicker({
            format: 'DD/MM/YYYY',    //use this format if you want the 12hours timpiecker with AM/PM toggle
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-chevron-up",
                down: "fa fa-chevron-down",
                previous: 'fa fa-chevron-left',
                next: 'fa fa-chevron-right',
                today: 'fa fa-screenshot',
                clear: 'fa fa-trash',
                close: 'fa fa-remove'
            }
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