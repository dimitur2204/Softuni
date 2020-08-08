import { Component, OnInit, OnDestroy } from '@angular/core';
import { NotificationService } from 'src/app/services/notification.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-success',
  templateUrl: './success.component.html',
  styleUrls: ['./success.component.css']
})
export class SuccessComponent implements OnInit, OnDestroy {

  public shown:string = 'none';
  public message:string = '';
  private sub:Subscription;
  constructor(private notiService:NotificationService) { }

  ngOnInit(): void {
    this.notiService.succesSubject.subscribe((message) => {
      this.message = message;
      this.shown = 'block';
      setTimeout(() => {
        this.shown = 'none';
      },3500)
    })
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
