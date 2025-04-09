import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  fg!:FormGroup;

  constructor(private fb:FormBuilder,private api:ApiService,private router:Router){

  }

  ngOnInit(): void {
    this.createForm()
  }

  onSubmit(){
    if(this.fg.invalid){
      alert('Please fill all required fields')
      return
    }
    console.log("register",this.fg.value)
    this.api.register(this.fg.value).subscribe({
      next:resp=>{
        alert(resp.msg)
        this.router.navigate(['/'])
      },
      error:err=>{
        console.log("error",err)
      }
    })
  }

  createForm(){
    this.fg=this.fb.group({
      'mname':['',Validators.required],
      'address':['',Validators.required],
      'gender':['',Validators.required],
      'phone':['',Validators.required],
      'email':['',Validators.required],
      'pwd':['',Validators.required],
  })
  }

}
