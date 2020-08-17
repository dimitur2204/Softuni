import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

import {User} from '../components/user/user.model';
import { NotificationService } from './notification.service';
import { Router } from '@angular/router';
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

  public user:BehaviorSubject<User> = new BehaviorSubject<User>(null);

  constructor(private http:HttpClient
    ,private notiService:NotificationService,
    private router:Router) { }

  private catch(errData){
    const message = errData.error.error.message;
    this.notiService.toggleLoading();
    switch (message) {
      case 'EMAIL_EXISTS':
        this.notiService.showError('Email already exists!');
        break;
        case 'EMAIL_NOT_FOUND':
        this.notiService.showError('Invalid Email!');
        break;
        case 'INVALID_PASSWORD':
        this.notiService.showError('Invalid Password!');
        break;
        case 'USER_DISABLED':
        this.notiService.showError('Your account has been disabled!');
        break;
      default:
        this.notiService.showError('An error occured! Try again!')
        break;
    }
  }

  private authenticateUser(res:IUserData){
    this.autoSignOut(Number(res.expiresIn) * 1000);
    const expirationDate = new Date(new Date().getTime() + Number(res.expiresIn) * 1000);
    const userCreated = new User(res.email,res.localId,res.idToken,expirationDate);
    localStorage.setItem('user',JSON.stringify(userCreated));
    this.user.next(userCreated);
    this.router.navigate(['/']);
  }

  public signUp(email,password){
    const userCreds:IUserCredentials = {
      email,
      password,
      returnSecureToken:true
    }
    this.notiService.toggleLoading();
    this.http.post<IUserData>(urls.signUp,userCreds).subscribe(res => {
      this.authenticateUser(res);
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
      this.authenticateUser(res);
      this.notiService.toggleLoading();
      this.notiService.showSuccess('Succesfully logged in!');
    },errData =>this.catch(errData));
  }
  public autoSignIn(){
    const userString:string = localStorage.getItem('user');
    if (!userString){
      return;
    } 
    const user:User = JSON.parse(userString);
    if(new Date(user.expirationDate).getTime() > new Date().getTime()) {
      this.user.next(user);
      return;
    }
    this.user.next(null);
  }
  public signOut(){
    this.notiService.showSuccess('Successfully logged out!');
    localStorage.removeItem('user');
    this.user.next(null);
  }
  private autoSignOut(ms){
    setTimeout(this.signOut,ms);
  }
}
