import { Component, OnInit } from '@angular/core';
import { EventsService } from 'src/app/services/events.service';
import {Event} from './event.model';
@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  public events:Event[] = [];
  constructor(private eventsService:EventsService) { }

  ngOnInit(): void {
    this.eventsService.getEvents().subscribe(events => {
      for (let i = 0; i < Object.values(events).length; i++) {
        const id = Object.keys(events)[i];
        const event:Event = {...Object.values(events)[i]};
        event.id = id;
        this.events.push(event);
      }
    });
  }

}
