import { JsonPipe } from '@angular/common';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/app/models/member.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  user$!: Observable<Member>;
  constructor(private api:ApiService){
    const info=api.getUserInfofromStorage()
    if(info){
      this.user$=this.api.getMemberDetails(JSON.parse(info).id); 
    }
  }


}
