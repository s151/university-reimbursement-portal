import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/models/member.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  uname!:string
  isadmin!:boolean
  constructor(public api:ApiService){

  }
  ngOnInit(): void {
    const info=this.api.getUserInfofromStorage()
    if(info){
      console.log("info",info)
      const member=JSON.parse(info)
      this.uname=member?.username
      this.isadmin=member.role=="Admin"
    }
  }


}
