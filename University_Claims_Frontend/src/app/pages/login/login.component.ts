import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  fg!:FormGroup;
  constructor(private api:ApiService,private fb:FormBuilder,private router:Router){}

  ngOnInit(): void {
    this.createForm();
  }

  submitForm(){
    if(this.fg.invalid){
      alert('Please fill the required fields')
      return;
    }
    this.api.validate(this.fg.value).subscribe({
      next:resp=>{
        console.log(resp)
        this.api.storeUserInfo(resp)
        if(resp.isadmin){
          this.router.navigate(['dashboard'])
        }else{
          this.router.navigate(['profile'])
        }
      },
      error:err=>{
        console.log(err)
      }
    })
  }

  createForm(){
    this.fg=this.fb.group({
      'userid':['',Validators.required],
      'pwd':['',Validators.required]      
    })
  }
}
