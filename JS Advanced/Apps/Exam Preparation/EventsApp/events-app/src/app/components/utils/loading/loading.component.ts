import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit {

  public shown = 'none';
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

}
