import { Component, OnInit, OnDestroy } from '@angular/core';
import {NotificationService} from '../../../services/notification.service';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit, OnDestroy {
  public message;
  public shown = 'none';
  private sub:Subscription;
  constructor(private notificationService:NotificationService) { }


  ngOnInit(): void {
    this.sub = this.notificationService.errorSubject.subscribe(message => {
      this.message = message;
      this.shown = 'block';
    });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
 hide(){
  this.shown = 'none';
  }
}
