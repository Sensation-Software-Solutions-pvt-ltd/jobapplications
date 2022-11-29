import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiserviceService } from '../service/apiservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  submitted = false;
  emailPattern="^[a-zA-Z0-9._%+-]+@+[a-zA-Z0-9]{3,30}\\.+[a-z]{2,6}$";
  Option: any = [
    { id:1,name:"Job1"},
    { id:2,name:"Job2"},
    { id:3,name:"Job3"}
  ]
    constructor(
        private formBuilder: FormBuilder,private apiService: ApiserviceService,
    ) {
      this.form = this.formBuilder.group({
        FirstName: ['', Validators.required],
        LastName: ['', Validators.required],
        EmailId: ['',[Validators.required, Validators.email]],
        DOB:['',Validators.required],
        JobId:['',Validators.required],
        BirthPlace:['',Validators.required],
        DocumentData:['',Validators.required],
    });
     }

    ngOnInit() {
    }
    get f() { return this.form.controls; }
    changeJob(e:any) {
      console.log(e.value)
      // this.form.setValue(e.target.value, {
      //   onlySelf: true
      // })
    }
    onSubmit() {
      console.log(this.form.value)
        this.submitted = true;
        if (this.form.invalid) {
            return;
        }
        this.updateMilestone(this.form.value)
    }
    updateMilestone(data: any) {
      this.apiService.ApplyForJob(data).subscribe((res) => {
        const result: any = res;
        if (result.responseCode == '200') {
        }
  
      });
    }
}