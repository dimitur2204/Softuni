import { Component, OnInit } from '@angular/core';
import {NotificationService} from '../../../services/notification.service';
@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {
  public message;
  public shown = 'none';
  constructor(private notificationService:NotificationService) { }

  ngOnInit(): void {
    this.notificationService.errorSubject.subscribe(message => {
      this.message = message;
      this.shown = 'block';
    });
  }
 hide(){
  this.shown = 'none';
  }
}
