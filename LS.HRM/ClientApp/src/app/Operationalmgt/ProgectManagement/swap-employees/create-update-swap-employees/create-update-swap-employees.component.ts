import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../../../../api-authorization/AuthorizeService';
import { ApiService } from '../../../../services/api.service';
import { ParentOptMgtComponent } from '../../../../sharedcomponent/parentoptmgt.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DBOperation } from '../../../../services/utility.constants';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CustomSelectListItem } from '../../../../models/MenuItemListDto';
import { debounceTime, distinctUntilChanged, map, startWith, switchMap } from 'rxjs/operators';
import { UtilityService } from '../../../../services/utility.service';
import { TranslateService } from '@ngx-translate/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-create-update-swap-employees',
  templateUrl: './create-update-swap-employees.component.html'
})
export class CreateUpdateSwapEmployeesComponent extends ParentOptMgtComponent implements OnInit {
  modalTitle: string;
  modalBtnTitle: string;
  dbops: DBOperation;
  form: FormGroup;
  id: number=0;

  readonly: string = "";

  projectData: any;
  srcProjectData: any;
  destProjectData: any;



  requestData: any;


  srcSiteCodeList: Array<CustomSelectListItem> = [];
  destSiteCodeList: Array<CustomSelectListItem> = [];

  srcCustomerCode: string = '';
  destCustomerCode: string = '';
  srcEmpNumber: string = '';
  destEmpNumber: string = '';
  isDataLoading: boolean = false;
  filteredSrcCustCodes: Observable<Array<CustomSelectListItem>>;
  filteredDestCustCodes: Observable<Array<CustomSelectListItem>>;
  filteredSrcEmployees: Observable<Array<CustomSelectListItem>>;
  filteredDestEmployees: Observable<Array<CustomSelectListItem>>;
  srcCustCodeControl = new FormControl('', Validators.required);
  destCustCodeControl = new FormControl('', Validators.required);
  srcEmpNumberControl = new FormControl('', Validators.required);
  destEmpNumberControl = new FormControl('', Validators.required);
  isArabic: boolean = false;


  srcProjectsList: Array<CustomSelectListItem> = [];
  destProjectsList: Array<CustomSelectListItem> = [];
  filterSrcCustCodes(val: string): Observable<Array<CustomSelectListItem>> {
    return this.apiService.getall(`CustomerMaster/getSelectCustomerList?search=${val}`)
      .pipe(
        map(response => {
          const res = response as Array<CustomSelectListItem>;
          this.isDataLoading = false;
          return res;
        })
      )
  }
  filterDestCustCodes(val: string): Observable<Array<CustomSelectListItem>> {
    return this.apiService.getall(`CustomerMaster/getSelectCustomerList?search=${val}`)
      .pipe(
        map(response => {
          const res = response as Array<CustomSelectListItem>;
          this.isDataLoading = false;
          return res;
        })
    )


    












  }

  filtersrcEmpNumbers(val: string): Observable<Array<CustomSelectListItem>> {
    return this.apiService.getall(`EmployeesToProjectSite/getAutoFillEmployeeListForProjectSite/${this.form.controls['srcProjectCode'].value}/${this.form.controls['srcSiteCode'].value}/?search=${val}`)
      .pipe(
        map(response => {
          const res = response as Array<any>;
          this.isDataLoading = false;
          return res;
        })
      )
  }
   filterdestEmpNumbers(val: string): Observable<Array<CustomSelectListItem>> {
    return this.apiService.getall(`EmployeesToProjectSite/getAutoFillEmployeeListForProjectSite/${this.form.controls['destProjectCode'].value}/${this.form.controls['destSiteCode'].value}/?search=${val}`)
      .pipe(
        map(response => {
          const res = response as Array<any>;
          this.isDataLoading = false;
          return res;
        })
      )
  }

  isFromProjectsAction: boolean = false;

  constructor(public datepipe: DatePipe, private translate: TranslateService, private fb: FormBuilder, private authService: AuthorizeService, private utilService: UtilityService, private apiService: ApiService, public dialogRef: MatDialogRef<CreateUpdateSwapEmployeesComponent>) {

    super(authService);

    this.filteredSrcCustCodes = this.srcCustCodeControl.valueChanges.pipe(
      startWith(this.srcCustomerCode),
      debounceTime(utilService.autoDelay()),
      distinctUntilChanged(),
      switchMap((val: string) => {
        if (val.trim() !== '')
          this.isDataLoading = true;
        return this.filterSrcCustCodes(val || '')
      })
    );
    this.filteredDestCustCodes = this.destCustCodeControl.valueChanges.pipe(
      startWith(this.destCustomerCode),
      debounceTime(utilService.autoDelay()),
      distinctUntilChanged(),
      switchMap((val: string) => {
        if (val.trim() !== '')
          this.isDataLoading = true;
        return this.filterDestCustCodes(val || '')
      })
    );


    




  }

  ngOnInit(): void {
    this.isDataLoading = true;
    this.setForm();

    this.isArabic = this.utilService.isArabic();
    if (this.id > 0) {
      this.readonly = "readonly";
      this.editForm();
      // this.loadSiteCodes(this.form.controls['siteCode'].value);
    }
    else {
      this.readonly = "";
      this.isDataLoading = false;

    }


  }


  setForm() {

    this.form = this.fb.group({

      'srcCustomerCode': ['', Validators.required],
      'destCustomerCode': ['', Validators.required],
      'srcProjectCode': ['', Validators.required],
      'destProjectCode': ['', Validators.required],
      'srcSiteCode': ['', Validators.required],
      'destSiteCode': ['', Validators.required],
      'id': [this.id, Validators.required],
      'fromDate': ['', Validators.required],
      'srcEmployeeNumber': ['', Validators.required],
      'destEmployeeNumber': ['', Validators.required],







    });

    if (this.isFromProjectsAction) {
      this.srcProjectData = this.projectData;
      this.srcCustCodeControl.setValue(this.srcProjectData.customerCode);
      this.form.controls['srcSiteCode'].setValue(this.projectData.siteCode);
      this.form.controls['srcProjectCode'].setValue(this.projectData.projectCode);
      this.form.controls['srcCustomerCode'].setValue(this.projectData.customerCode);
      this.loadProjectsList(this.projectData.customerCode,"src");
      this.loadSiteCodes(this.projectData.projectCode,"src");
      this.onSelectionSiteCode("src");
    }
  }





  onSelectionCustomerCode(event: any, op: number, origin: string) {
    let CustCode: string = '';
    if (op == 1) { CustCode = event.option.value; }
    else if (op == 2) { CustCode = event.target.value; }
    else if (op == 3) { CustCode = event }

    this.apiService.getall('CustomerMaster/getCustomerByCustomerCode/' + CustCode).subscribe(res => {
      if (res != null) {




        if (origin == "src") {
          this.form.controls['srcCustomerCode'].setValue(CustCode);
          this.loadProjectsList(CustCode, "src");
          this.form.controls['srcSiteCode'].setValue('');
          this.form.controls['srcProjectCode'].setValue('');
          this.srcSiteCodeList = [];
          this.srcEmpNumberControl.setValue('');
          this.form.controls['srcEmployeeNumber'].setValue('');
          this.form.controls['fromDate'].setValue('');

        }
        if (origin == "dest") {
          this.form.controls['destCustomerCode'].setValue(CustCode);

          this.loadProjectsList(CustCode, "dest");
          this.form.controls['destSiteCode'].setValue('');
          this.form.controls['destProjectCode'].setValue('');
          this.form.controls['destEmployeeNumber'].setValue('');
          this.destEmpNumberControl.setValue('');
          this.destSiteCodeList = [];
        }



      }/*, error => {*/
      //}
      else {
        if (origin == "src") {
          this.form.controls['srcCustomerCode'].setValue('');
          this.srcCustCodeControl.setValue('');
          this.srcProjectsList = [];
          this.srcSiteCodeList = [];
          this.form.controls['srcProjectCode'].setValue('');
          this.form.controls['srcSiteCode'].setValue('');
          this.srcEmpNumberControl.setValue('');
          this.form.controls['srcEmployeeNumber'].setValue('');
          this.form.controls['fromDate'].setValue('');
        }
        if (origin == "dest") {
          this.form.controls['destCustomerCode'].setValue('');
          this.destCustCodeControl.setValue('');
          this.destProjectsList = [];
          this.destSiteCodeList = [];
          this.form.controls['destProjectCode'].setValue('');
          this.form.controls['destSiteCode'].setValue('');
          this.destEmpNumberControl.setValue('');
          this.form.controls['destEmployeeNumber'].setValue('');
        }


      }

    });


  }
  onSelectionEmployee(event: any, op: number,origin:string) {
    let EmpNumber: string = '';
    if (op == 1) { EmpNumber = event.option.value.toString(); }
    else if (op == 2) { EmpNumber = event.target.value.toString(); }
    else if (op == 3) { EmpNumber = event }

    if (origin =="src") {
      this.apiService.getall('Employee/getEmployeeByEmployeeNumber/' + EmpNumber).subscribe(res => {
        if (res != null) {

          let srcEmpNumber = this.srcEmpNumberControl.value as string;


          this.form.controls['srcEmployeeNumber'].setValue(srcEmpNumber);


        }
        else {

          this.form.controls['srcEmployeeNumber'].setValue('');


        }

      });
    }
    else if (origin == "dest"){
      this.apiService.getall('Employee/getEmployeeByEmployeeNumber/' + EmpNumber).subscribe(res => {
        if (res != null) {

          let destEmpNumber = this.destEmpNumberControl.value as string;


          this.form.controls['destEmployeeNumber'].setValue(destEmpNumber);


        }
        else {

          this.form.controls['destEmployeeNumber'].setValue('');


        }

      });
    }

  }
  onSelectionProjectCode(origin: string) {

    if (origin == "src")
    {
      this.form.controls['srcSiteCode'].setValue('');
      this.srcSiteCodeList = [];
      this.loadSiteCodes(this.form.controls['srcProjectCode'].value, origin);
      this.form.controls['fromDate'].setValue('');



      this.srcEmpNumberControl.setValue('');
      this.form.controls['srcEmployeeNumber'].setValue('');

    }
    else if (origin == "dest") {
      this.form.controls['destSiteCode'].setValue('');
      this.destSiteCodeList = [];
      this.loadSiteCodes(this.form.controls['destProjectCode'].value, origin);

      this.destEmpNumberControl.setValue('');
      this.form.controls['destEmployeeNumber'].setValue('');

    }
    this.isDataLoading = false;
  }

  getProjectData(origin: string) {
    if (origin == "src") {
      this.apiService.getall(`ProjectSites/getProjectSiteByProjectAndSiteCode/${this.form.controls['srcProjectCode'].value}/${this.form.controls['srcSiteCode'].value}`).subscribe(res => {

        this.srcProjectData = res;
      });
    }
    else {
      this.apiService.getall(`ProjectSites/getProjectSiteByProjectAndSiteCode/${this.form.controls['destProjectCode'].value}/${this.form.controls['destSiteCode'].value}`).subscribe(res => {

        this.destProjectData = res;
      });
    }

  }

  loadSiteCodes(projectCode: string, origin: string) {
    this.isDataLoading = true;

    this.apiService.getall(`CustomerSite/getSelectSiteListByProjectCode/${projectCode}`).subscribe(res => {

      if (origin == "src") {
        this.srcSiteCodeList = res;

      }
      if (origin == "dest")
        this.destSiteCodeList = res;
      this.isDataLoading = false;

 

    });
  }
  loadProjectsList(custCode: string, origin: string) {
    //if (this.id == 0)
    //  this.form.controls['srcProjectCode'].setValue('');

    this.isDataLoading = true;

    this.apiService.getall(`project/getSelectProjectListByCustomerCode/${custCode}`).subscribe(res => {
      if (origin == "src")
        this.srcProjectsList = res;
      if (origin == "dest")
        this.destProjectsList = res;
      this.isDataLoading = false;

    });
  }


  editForm() {
    this.isDataLoading = true;

    this.apiService.get('PvSwapEmployees/getPvSwapEmployeesReqById', this.id).subscribe(res => {

      if (res != null) {
        console.log(res);
        // this.form.value({'projectCode':res.projectCode,'siteCode':res.siteCode});

        this.requestData = res as any;


        this.srcCustCodeControl.setValue(res.srcCustomerCode);
        this.destCustCodeControl.setValue(res.destCustomerCode);

        this.srcEmpNumberControl.setValue(res.srcEmployeeNumber);
        this.destEmpNumberControl.setValue(res.destEmployeeNumber);

        this.loadProjectsList(res.srcCustomerCode, "src");
        this.loadProjectsList(res.destCustomerCode, "dest");


        //this.form.controls['srcProjectCode'].disable({ onlySelf: true });
        //this.form.controls['destProjectCode'].disable({ onlySelf: true });

        //this.form.controls['srcSiteCode'].disable({ onlySelf: true });
        //this.form.controls['destSiteCode'].disable({ onlySelf: true });

        this.form.controls['srcProjectCode'].setValue(res.srcProjectCode);
        this.form.controls['destProjectCode'].setValue(res.destProjectCode);
       
        this.loadSiteCodes(res.srcProjectCode, "src");
        this.loadSiteCodes(res.destProjectCode, "dest");

        this.form.controls['srcCustomerCode'].setValue(res.srcCustomerCode);
        this.form.controls['destCustomerCode'].setValue(res.destCustomerCode);

        this.form.controls['srcSiteCode'].setValue(res.srcSiteCode);
        this.form.controls['destSiteCode'].setValue(res.destSiteCode);



        this.form.controls['srcEmployeeNumber'].setValue(res.srcEmployeeNumber);
        this.form.controls['destEmployeeNumber'].setValue(res.destEmployeeNumber);

        this.form.controls['fromDate'].setValue(res.fromDate);
        this.getProjectData("dest");
        this.getProjectData("src");


        if (this.id>0) {
          this.filteredSrcEmployees = this.srcEmpNumberControl.valueChanges.pipe(
            startWith(this.srcEmpNumber),
            debounceTime(this.utilService.autoDelay()),
            distinctUntilChanged(),
            switchMap((val: string) => {
              if (val.trim() !== '')
                this.isDataLoading = true;
              return this.filtersrcEmpNumbers(val || '')
            })
          );
          this.filteredDestEmployees = this.destEmpNumberControl.valueChanges.pipe(
            startWith(this.destEmpNumber),
            debounceTime(this.utilService.autoDelay()),
            distinctUntilChanged(),
            switchMap((val: string) => {
              if (val.trim() !== '')
                this.isDataLoading = true;
              return this.filterdestEmpNumbers(val || '')
            })
          );
        }

       







       


        this.isDataLoading = false;

       


      }


    });





  }
  closeModel() {
    this.dialogRef.close();
  }

  submit() {
    if (this.form.valid) {
      this.form.value['srcCustomerCode'] = this.srcCustCodeControl.value;
      this.form.value['destCustomerCode'] = this.destCustCodeControl.value;
      //this.form.value['srcSiteCode'] = this.form.controls['srcSiteCode'].value;

      // this.form.value['destProjectCode'] = this.form.controls['destProjectCode'].value;
      //this.form.value['destSiteCode'] = this.form.controls['destSiteCode'].value;



      let fd = new Date(this.form.controls['fromDate'].value);
      fd.setMinutes(fd.getMinutes() - fd.getTimezoneOffset());
      this.form.value['fromDate'] = fd;






      this.apiService.post('PvSwapEmployees', this.form.value)
        .subscribe(res => {
          if (res) {

            this.utilService.OkMessage();

            this.dialogRef.close(true);

          }
        },
          error => {
            console.error(error);
            this.utilService.ShowApiErrorMessage(error);
          });
    }
    else {
      this.utilService.FillUpFields();
    }
  }

  onSelectionSiteCode(origin: string) {


    if (origin == "src") {


      if (this.form.controls['srcSiteCode'].value != '') {
        this.isDataLoading = true;
        this.getProjectData("src");
        this.form.controls['fromDate'].setValue('');

      }





      this.srcEmpNumberControl.setValue('');
      this.filteredSrcEmployees = this.srcEmpNumberControl.valueChanges.pipe(
        startWith(this.srcEmpNumber),
        debounceTime(this.utilService.autoDelay()),
        distinctUntilChanged(),
        switchMap((val: string) => {
          if (val.trim() !== '')
            this.isDataLoading = true;
          return this.filtersrcEmpNumbers(val || '')
        })
      );
    }
    else
      if (origin == "dest") {
        if (this.form.controls['destSiteCode'].value != '') {
          this.isDataLoading = true;
          this.getProjectData("dest");
          this.form.controls['fromDate'].setValue('');

        }





        this.destEmpNumberControl.setValue('');
        this.filteredDestEmployees = this.destEmpNumberControl.valueChanges.pipe(
          startWith(this.destEmpNumber),
          debounceTime(this.utilService.autoDelay()),
          distinctUntilChanged(),
          switchMap((val: string) => {
            if (val.trim() !== '')
              this.isDataLoading = true;
            return this.filterdestEmpNumbers(val || '')
          })
        );
      }


  }


  translateToolTip(text: string) {
    return this.translate.instant(text);
  }


  ToDateString(date: any) {

    if (date != null)
      return this.datepipe.transform(date.toString(), 'yyyy-MM-dd')?.toString();
    else
      return "";
  }


  openDatePicker(dp: any) {
    dp.open();
  }

}
