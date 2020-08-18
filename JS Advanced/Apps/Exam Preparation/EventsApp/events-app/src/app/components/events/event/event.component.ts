import { Component, OnInit, Input } from '@angular/core';
import {Event} from '../event.model';
@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {

  @Input('event') event:Event;
  constructor() { }

  ngOnInit(): void {
  }

}
