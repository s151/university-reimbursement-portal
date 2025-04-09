import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { FullComponent } from './pages/full/full.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { MembersComponent } from './pages/members/members.component';
import { ClaimsComponent } from './pages/claims/claims.component';
import { AddClaimComponent } from './pages/add-claim/add-claim.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ClaimDetailsComponent } from './pages/claim-details/claim-details.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {path:'',component:LoginComponent,pathMatch:'full'},
  {path:'register',component:RegisterComponent},
  {path:'',
  component:FullComponent,
  canActivate: [AuthGuard],
  children:[
    {
      path:'dashboard',
      component:DashboardComponent
    },
    {
      path:'members',
      component:MembersComponent
    },
    {
      path:'claims',
      component:ClaimsComponent
    },
    {
      path:'add-claim',
      component:AddClaimComponent
    },
    {
      path:'details/:id',
      component:ClaimDetailsComponent
    },
    {
      path:'profile',
      component:ProfileComponent
    }
  ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
