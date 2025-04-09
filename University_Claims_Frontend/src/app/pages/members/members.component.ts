import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/app/models/member.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss']
})
export class MembersComponent implements OnInit {
  
  members$!:Observable<Member[]>;

  constructor(private api:ApiService){
    
  }
  ngOnInit(): void {
    this.members$=this.api.allMembers()
  }
}
