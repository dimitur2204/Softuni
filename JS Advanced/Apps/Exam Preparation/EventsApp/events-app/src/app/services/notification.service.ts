import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  public succesSubject = new Subject<string>();
  public errorSubject = new Subject<string>();
  public loadingSubject = new Subject<void>();
  constructor() { }
  showSuccess(message){
    this.succesSubject.next(message);
  }
  showError(message){
    this.errorSubject.next(message);
  }
  toggleLoading(){
    this.loadingSubject.next();
  }
}
