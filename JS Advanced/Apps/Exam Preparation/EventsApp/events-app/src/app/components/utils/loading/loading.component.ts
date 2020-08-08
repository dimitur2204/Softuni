import { Component, OnInit, OnDestroy } from '@angular/core';
import { NotificationService } from 'src/app/services/notification.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit, OnDestroy {

  public shown = 'none';
  private sub:Subscription;
  constructor(private notiService:NotificationService) { }

  ngOnInit(): void {
    this.notiService.loadingSubject.subscribe(() => {
      if (this.shown == 'none') {
        this.shown = 'block';
      }else{
        this.shown = 'none';
      }
    })
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
