import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  isLogged: boolean = true;
  constructor() { }

  login(){
    this.isLogged = true;
  }

  logout(){
    this.isLogged = false;
  }
}
