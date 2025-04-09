import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Member } from '../models/member.model';
import { Claim } from '../models/claim.model';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  isloggedin=new BehaviorSubject<boolean>(false)
  isAdmin=new BehaviorSubject<boolean>(false)

  constructor(private http:HttpClient) { }

  validate(data:any){
    return this.http.post<any>("members/validate",data);
  }

  register(data:any){
    return this.http.post<any>("members",data);
  }

  allMembers(){
    return this.http.get<Member[]>("members")
  }

  getMemberDetails(id:number){
    return this.http.get<Member>("members/"+id)
  }

  getAllClaims(){
    return this.http.get<Claim>("claims");
  }

  saveClaim(data:any){
    return this.http.post<any>("claims",data);
  }

  getMemberClaims(id:number){
    return this.http.get<Claim>("claims/members/"+id);
  }

  filterClaims(memberid:any,search:string){
    if(memberid){
      return this.http.get<Claim>(`claims/filter?memberid=${memberid}&search=${search}`)
    }else{
      return this.http.get<Claim>(`claims/filter?search=${search}`)
    }
  }

  getClaimDetails(id:any){
    return this.http.get<any>("claims/"+id);
  }

  updateClaim(id:number,data:any){
    return this.http.put<any>("claims/"+id,data)
  }

  getDashboard(){
    return this.http.get<any>("members/dashboard")
  }

  storeUserInfo(data:any){
    this.decodeToken(data.token);
    this.isloggedin.next(true)    
    
  }

  decodeToken(token:string){
    let jwt= jwt_decode<{email:string,exp:number,role:string,username:string,id:number}>(token);
    this.isAdmin.next(jwt.role==="Admin")
    localStorage.setItem("uinfo",JSON.stringify(jwt))
    localStorage.setItem("token",token);
  }

  clearStorage(){
    this.isloggedin.next(false)
    localStorage.clear()
  }

  getUserInfofromStorage(){
    return localStorage.getItem("uinfo")
  }
}
