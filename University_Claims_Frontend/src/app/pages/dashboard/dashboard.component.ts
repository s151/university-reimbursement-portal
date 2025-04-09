import { Component } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  members!:any
  claims!:any
  constructor(private api:ApiService){
      this.api.getDashboard().subscribe(resp=>{
        this.members=resp.members;
        this.claims=resp.claims;
      })
  }
}
