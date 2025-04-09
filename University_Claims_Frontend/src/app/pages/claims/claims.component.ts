import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, filter, map } from 'rxjs';
import { Claim } from 'src/app/models/claim.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-claims',
  templateUrl: './claims.component.html',
  styleUrls: ['./claims.component.scss']
})
export class ClaimsComponent {
  claims$!:any;
  
  constructor(private api:ApiService,private router:Router){
    this.loadData()
  }

  loadData(){
    const user=this.api.getUserInfofromStorage()
    if(user){
      const info=JSON.parse(user)
      if(info.role!=="Admin"){
        this.claims$=this.api.getMemberClaims(info.id)
      }else{
        this.claims$= this.api.getAllClaims()
      }
    }
  }

  filterClaim(event:any){
    const search=event.target.value
    const user=this.api.getUserInfofromStorage()
    if(user && search.length>0){
      const info=JSON.parse(user)
      if(info.role!=="Admin"){
        this.claims$=this.api.filterClaims(info.id,search)        
      }
      else {
        this.claims$= this.api.filterClaims(null,search)
      }
    }else{
      this.loadData()
    }
  }
}
