import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { FullComponent } from './pages/full/full.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { CommonModule } from '@angular/common';
import { MembersComponent } from './pages/members/members.component';
import { ClaimsComponent } from './pages/claims/claims.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AddClaimComponent } from './pages/add-claim/add-claim.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ClaimDetailsComponent } from './pages/claim-details/claim-details.component';
import { ApiInterceptorInterceptor } from './api-interceptor.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    FullComponent,
    NavbarComponent,
    SidebarComponent,
    MembersComponent,
    ClaimsComponent,
    DashboardComponent,
    AddClaimComponent,
    ProfileComponent,
    ClaimDetailsComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: ApiInterceptorInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
