import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { NotificationService } from './notification.service';
const urls = {
  signIn:'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyCdeeDMM9LpTFvKr4E1_pjA5lXtI4tCMUU', signUp:'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyCdeeDMM9LpTFvKr4E1_pjA5lXtI4tCMUU',
}

export interface IUserData{
  idToken:string;
  email:string;
  refreshToken:string;
  expiresIn:string;
  localId:string;
}
export interface IUserCredentials{
  email:string,
  password:string,
  returnSecureToken:boolean;
}
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http:HttpClient,private notiService:NotificationService) { }

  private catch(errData){
    const message = errData.error.error.message;
    this.notiService.toggleLoading();
    switch (message) {
      case 'EMAIL_EXISTS':
        this.notiService.showError('Email already exists!');
        break;
      default:
        this.notiService.showError('An error occured! Try again!')
        break;
    }
  }

  public signUp(email,password){
    const userCreds:IUserCredentials = {
      email,
      password,
      returnSecureToken:true
    }
    this.notiService.toggleLoading();
    this.http.post<IUserData>(urls.signUp,userCreds).subscribe(res => {
      console.log(res);
      this.notiService.toggleLoading();
      this.notiService.showSuccess('Succesfully registered!');
    },errData =>this.catch(errData));
  }

  public signIn(email,password){
    const userCreds:IUserCredentials = {
      email,
      password,
      returnSecureToken:true
    }
    this.notiService.toggleLoading();
    this.http.post<IUserData>(urls.signIn,userCreds).subscribe(res => {
      this.notiService.toggleLoading();
      this.notiService.showSuccess('Succesfully logged in!');
    },errData =>this.catch(errData));
  }
}
