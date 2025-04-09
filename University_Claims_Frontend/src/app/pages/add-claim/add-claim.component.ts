import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-claim',
  templateUrl: './add-claim.component.html',
  styleUrls: ['./add-claim.component.scss']
})
export class AddClaimComponent implements OnInit {
  claimForm!:FormGroup;

  constructor(private api:ApiService,private router:Router,private fb:FormBuilder){

  }
  ngOnInit(): void {
    this.createForm()
  }

  submitClaim(){
    
    console.log("form",this.claimForm.value)
    if(this.claimForm.invalid){
      alert('Please fill all required fields')
      return
    } 

    const fd=new FormData()
    Object.keys(this.claimForm.value).forEach(key=>{
      fd.append(key,this.claimForm.value[key])
    })
    const user=this.api.getUserInfofromStorage()
    if(user)
      fd.append('memberid',JSON.parse(user).id)

    this.api.saveClaim(fd).subscribe({
      next:resp=>{
        alert(resp.msg)
        this.router.navigate(['/claims'])
      },
      error:err=>{
        console.log(err)
      }
    })
  }

  uploadFile(event:any,id:number){
    const file=event.target?.files[0] as File
    switch(id){
      case 1:
        this.claimForm.patchValue({docFile1:file})
        break
      case 2:
        this.claimForm.patchValue({docFile2:file})
        break
      case 3:
        this.claimForm.patchValue({docFile3:file})
        break
    }
  }

  createForm(){
    this.claimForm=this.fb.group({
      'vtype':['',Validators.required],
      'vno':['',Validators.required],
      'model':['',Validators.required],
      'insuranceAmount':['',Validators.required],
      'claimAmount':['',Validators.required],
      'docType1':['',Validators.required],
      'docType2':[''],
      'docType3':[''],
      'docFile1':['',Validators.required],
      'docFile2':[''],
      'docFile3':['']
    })
  }
}
