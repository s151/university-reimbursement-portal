import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { DashboardComponent } from '../pages/dashboard/dashboard.component';
import { MembersComponent } from '../pages/members/members.component';
import { ClaimsComponent } from '../pages/claims/claims.component';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    CommonModule,
    BrowserModule
  ]
})
export class MainModule { }
