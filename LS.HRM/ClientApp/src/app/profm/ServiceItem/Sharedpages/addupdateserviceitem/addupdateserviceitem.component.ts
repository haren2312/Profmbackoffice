import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthorizeService } from 'src/app/api-authorization/AuthorizeService';
import { ApiService } from 'src/app/services/api.service';
import { NotificationService } from 'src/app/services/notification.service';
import { DBOperation } from 'src/app/services/utility.constants';
import { UtilityService } from 'src/app/services/utility.service';
import { ValidationService } from 'src/app/sharedcomponent/ValidationService';
import { ParentFomMgtComponent } from 'src/app/sharedcomponent/parentfommgt.component';
import { ParentB2CComponent } from '../../../../sharedcomponent/parentb2c.component';
import Validation from '../../../../Operationalmgt/Validators/custom.validators/custom.validators.component';

@Component({
  selector: 'app-addupdateserviceitem',
  templateUrl: './addupdateserviceitem.component.html',
})
export class AddupdateserviceitemComponent extends ParentB2CComponent implements OnInit {
  modalTitle!: string;
  modalBtnTitle!: string;
  dbops!: DBOperation;
  form!: FormGroup;
  id: number = 0;
  isReadOnly: boolean = false;
  fileUploadone!: File;
  fileUploadtwo!: File;
  formData!: FormData;
  disciplineList!: Array<any>;
  activitesList!: Array<any>;
  selectedServices: any;
  serviceList: any;
  thumbNailImagePath: string = '';
  fullImagePath: string = '';
  isMonthly: boolean = false;
  isYearly: boolean = false;
  isEditMode: boolean = false;
  constructor(private fb: FormBuilder, private apiService: ApiService,
    private authService: AuthorizeService, private utilService: UtilityService, public dialogRef: MatDialogRef<AddupdateserviceitemComponent>,
    private notifyService: NotificationService, private validationService: ValidationService) {
    super(authService)
  };

  ngOnInit(): void {
    this.isEditMode = false;
    this.loadFormData();
    this.setForm();
    if (this.id > 0)
      this.setEditForm();
  }

  loadFormData() {

    this.serviceList = [
      { id: "Daily", name: 'Daily Service', },
      { id: "Monthly", name: 'Monthly Service' },
      { id: "Yearly", name: 'Yearly Service' },
    ];

    this.apiService.getall('fomMobB2CService/getDepartmentList').subscribe(result => {
      this.disciplineList = result;
    });
  }

  loadActivitiesForDeptEvent(evt: any) {
    this.loadActivitiesForDept(evt.target.value);
  }
  loadActivitiesForDept(dept: any) {

    this.apiService.getall('fomMobB2CService/getActivitiesByDepartmentList?deptCode=' + dept).subscribe(result => {
      this.activitesList = result;
    });
  }

  setForm() {
    this.form = this.fb.group(
      {
        'serviceCode': ['', Validators.required],
        'deptCode': ['', Validators.required],
        'activityCode': ['', Validators.required],
        'serviceShortDesc': ['', Validators.required],
        'serviceShortDescAr': ['', Validators.required],
        'serviceDetails': ['', Validators.required],
        'serviceDetailsAr': [''],
        'timeUnitPrimary': ['', Validators.required],
        'resourceUnitPrimary': [0, Validators.required],
        'potentialCost': [0],
        'applicableDiscount': [0],
        'isOnOffer': [false],
        'offerPrice': [0, Validators.required],
        'offerStartDate': [null, Validators.required],
        'offerEndDate': [null, Validators.required],
        'remarks1': [''],
        'remarks2': [''],
        'thumbNailImagePath': [''],
        'minRequiredHrs': ['', Validators.required],
        'minReqResource': [0],
        'primaryUnitPrice': [0],
        'monthlyPrice': [0],
        'yearlyPrice': [0],
        'fullImagePath': [''],
        'selectedServices': ['', Validators.required],
        'isActive': [true],
      }
    );
    this.isReadOnly = false;
  }
  setEditForm() {
    this.apiService.get('fomMobB2CService/getServiceItemById', this.id).subscribe(res => {
      if (res) {

        let url = this.getCurrentUrl().replace('/api', '');
        this.thumbNailImagePath = this.utilService.hasValue(res['thumbNailImagePath']) ? `${url}/files/${res['thumbNailImagePath']}` : ''
        this.fullImagePath = this.utilService.hasValue(res['fullImagePath']) ? `${url}/files/${res['fullImagePath']}` : ''
        this.isReadOnly = true;
        this.loadActivitiesForDept(res.deptCode)
        this.form.patchValue(res);
        this.form.controls['timeUnitPrimary'].setValue(this.utilService.formatToTimeSpanTime(res.timeUnitPrimary));
        this.form.controls['minRequiredHrs'].setValue(this.utilService.formatToTimeSpanTime(res.minRequiredHrs));
        this.form.controls['selectedServices'].setValue((res.serviceitems as string).split(','));

        this.isMonthly = res.isMonthlyPrice;
        this.isYearly = res.isYearlyPrice;
        this.isEditMode = true;
      }
    });
  }

  checkDiscount(evt: any) {
    let discount = parseFloat(evt.target.value);
    if(discount > 100)
      this.form.controls['applicableDiscount'].setValue(0);
  }

  clearService(evt: any) {
    let item = evt.value.toLowerCase();
    if (item.includes('month')) {
      this.isMonthly = false;
      this.form.controls['monthlyPrice'].setValue(0);
    }
    else if (item.includes('year')) {
      this.isYearly = false;
      this.form.controls['yearlyPrice'].setValue(0);
    }

  }
  selectService(evt: any) {
    if (evt && evt.length > 0) {
      let services = evt as Array<string>;
      services.forEach(item => {
        item = item.toLowerCase();
        //console.log(item.includes('month'));      
        if (item.includes('month'))
          this.isMonthly = true;
        else if (item.includes('year'))
          this.isYearly = true;
      })

    }
  }
  onSelectFile1(fileInput: any) {
    this.fileUploadone = <File>fileInput.target.files[0];
  }
  onSelectFile2(fileInput: any) {
    this.fileUploadtwo = <File>fileInput.target.files[0];

  }

  closeModel() {
    this.dialogRef.close();
  }

  submit() {
    if (this.form.valid) {

      if (this.id > 0)
        this.form.value['id'] = this.id;

      this.formData = new FormData();

      this.form.value['offerStartDate'] = this.utilService.selectedDateTime(this.form.controls['offerStartDate'].value);
      this.form.value['offerEndDate'] = this.utilService.selectedDateTime(this.form.controls['offerEndDate'].value);

      this.formData.append("input", JSON.stringify(this.form.value));

      if (this.fileUploadone) {
        this.formData.append("fileone", this.fileUploadone, this.fileUploadone.name);
        this.formData.append("fileone_", 'thumb');
      }
      if (this.fileUploadtwo) {
        this.formData.append("filetwo", this.fileUploadtwo, this.fileUploadtwo.name);
        this.formData.append("filetwo_", 'item');
      }

      this.apiService.post('fomMobB2CService/createUpdateServiceItems', this.formData)
        .subscribe(res => {
          this.utilService.OkMessage();
          this.reset();
          this.dialogRef.close(true);
        },
          error => {
            this.utilService.ShowApiErrorMessage(error);
          });
    }
    else
      this.utilService.FillUpFields();
  }

  reset() {
    this.form.controls['serviceCode'].setValue('');
    this.form.controls['deptCode'].setValue('');
    this.form.controls['activityCode'].setValue('');
    this.form.controls['serviceShortDesc'].setValue('');
    this.form.controls['serviceShortDescAr'].setValue('');
    this.form.controls['serviceDetails'].setValue('');
    this.form.controls['serviceDetailsAr'].setValue('');
    this.form.controls['timeUnitPrimary'].setValue('');
    this.form.controls['resourceUnitPrimary'].setValue('');
    this.form.controls['potentialCost'].setValue('');
    this.form.controls['applicableDiscount'].setValue('');
    this.form.controls['isOnOffer'].setValue('');
    this.form.controls['offerPrice'].setValue('');
    this.form.controls['offerStartDate'].setValue('');
    this.form.controls['offerEndDate'].setValue('');
    this.form.controls['remarks1'].setValue('');
    this.form.controls['remarks2'].setValue('');
    this.form.controls['thumbNailImagePath'].setValue('');
    this.form.controls['fullImagePath'].setValue('');
    this.form.controls['minRequiredHrs'].setValue('');
    this.form.controls['minReqResource'].setValue('');
    this.form.controls['primaryUnitPrice'].setValue('');
    this.form.controls['isActive'].setValue('');

  }
}
