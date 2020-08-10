import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { NotificationService } from 'src/app/services/notification.service';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private notiService:NotificationService, private authService:AuthenticationService, private router:Router) { }

  ngOnInit(): void {
  }
  onSubmit(form:NgForm){
    if (form.controls.email.errors?.required) {
      this.notiService.showError('Username has to be more than 3 symbols');
      return;
    }else if(form.controls.password.errors?.required){
      this.notiService.showError('Password has to be more than 6 symbols');
      return;
    }
    this.authService.signIn(form.value.email,form.value.password);
    form.reset();
    this.router.navigate(['home']);
  }
}
