import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-claim-details',
  templateUrl: './claim-details.component.html',
  styleUrls: ['./claim-details.component.scss']
})
export class ClaimDetailsComponent implements OnInit{
  claim!:any
  user!:any;
  isAdmin=false;
  approveForm!:FormGroup;
  rejectForm!:FormGroup;
  constructor(private api:ApiService,
    private router:Router,
    private snapshot:ActivatedRoute,
    private fb:FormBuilder
    ){
  }

  createForms(){
    this.approveForm=this.fb.group({
      'claimId':[''],
      'finalAmount':['',Validators.required],
      'status':['Approved']
    })
    this.rejectForm=this.fb.group({
      'claimId':[''],
      'rejReason':['',Validators.required],
      'status':['Rejected']
    })
  }

  submitApprove(){
    
    if(this.approveForm.invalid){
      alert('Please fill required field')
      return
    }
    this.approveForm.patchValue({'claimId':this.claim?.id})
    this.api.updateClaim(this.claim.id,this.approveForm.value).subscribe({
      next:resp=>{
        alert(resp.msg)
        this.router.navigate(['claims'])
      },
      error:err=>console.log(err)
    })
  }

  submitReject(){
    if(this.rejectForm.invalid){
      alert('Please fill required field')
      return
    }
    this.rejectForm.patchValue({'claimId':this.claim?.id})
    this.api.updateClaim(this.claim.id,this.rejectForm.value).subscribe({
      next:resp=>{
        alert(resp.msg)
        this.router.navigate(['claims'])
      },
      error:err=>console.log(err)
    })
  }

  ngOnInit(): void {
    const Id=this.snapshot.snapshot.paramMap.get('id')    
    this.api.getClaimDetails(Id).subscribe(resp=>this.claim=resp)    
    
    const info=this.api.getUserInfofromStorage()
    if(info){
      this.user=JSON.parse(info)
      this.isAdmin=this.user.role==="Admin";
    }
    this.createForms()

  }
}
