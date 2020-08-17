import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

import { AuthenticationService } from './authentication.service';
import { Event } from '../components/events/event.model';

const BASE_URL = 'https://softuniexamapp-64413.firebaseio.com';
@Injectable({
  providedIn: 'root'
})
export class EventsService {

  public events:Subject<Event[]> = new Subject<Event[]>();
  private _events:Event[];
  constructor(
    private http:HttpClient,
    private authService:AuthenticationService) {
      this._events = [];
   }
  addEvent(event:Event){
    this.http.post(BASE_URL + '/events.json',event).subscribe(res => {
      console.log(res);
    });
  }
  getEvents(){
    return this.http.get<Event[]>(BASE_URL + '/events.json');
  }
  getEventById(id:string){

  }
}
