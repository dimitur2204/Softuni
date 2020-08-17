import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NotificationService } from 'src/app/services/notification.service';
import {AuthenticationService} from '../../../services/authentication.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  constructor(private notiService:NotificationService, private authService:AuthenticationService, private router:Router) {
   }

  ngOnInit(): void {
  }
  onSubmit(form:NgForm){
    if (form.controls.email.errors?.required) {
      this.notiService.showError('Username has to be more than 3 symbols');
      return;
    }else if(form.controls.password.errors?.required){
      this.notiService.showError('Username has to be more than 6 symbols');
      return;
    }else if(form.value.rePassword !== form.value.password){
      this.notiService.showError('Passwords have to match');
      return;
    }
    this.authService.signUp(form.value.email,form.value.password);
    form.reset();
  }
}
