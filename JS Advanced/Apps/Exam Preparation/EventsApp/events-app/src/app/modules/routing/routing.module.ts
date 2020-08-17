import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/components/home/home.component';
import { NotFound404Component } from 'src/app/components/not-found404/not-found404.component';
import { SignUpComponent } from 'src/app/components/user/sign-up/sign-up.component';
import { SignInComponent } from 'src/app/components/user/sign-in/sign-in.component';
import { ProfileComponent } from 'src/app/components/user/profile/profile.component';
import { CreateEventComponent } from 'src/app/components/events/create-event/create-event.component';

const routes:Routes = [
  {path:'', component:HomeComponent},
  {path:'home', component:HomeComponent}, 
  {path:'signUp', component:SignUpComponent}, 
  {path:'signIn', component:SignInComponent}, 
  {path:'organize', component:CreateEventComponent}, 
  {path:'profile', component:ProfileComponent}, 
  {path: '404', component:NotFound404Component },
  {path: '**', redirectTo: '/404'},
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports:[RouterModule]
})
export class AppRoutingModule { }
