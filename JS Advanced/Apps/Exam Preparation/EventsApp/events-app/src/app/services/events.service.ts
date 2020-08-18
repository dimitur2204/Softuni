import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthenticationService } from './authentication.service';
import { Event } from '../components/events/event.model';

const BASE_URL = 'https://softuniexamapp-64413.firebaseio.com';
@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor(
    private http:HttpClient,
    private authService:AuthenticationService) {
   }
  addEvent(event:Event){
    this.http.post<{name}>(BASE_URL + '/events.json',event).subscribe(res => {
      event.id = res.name;
    });
  }
  getEvents(){
    return this.http.get<Event[]>(BASE_URL + '/events.json');
  }
  getEventById(id:string){
    return this.http.get<Event>(BASE_URL + `/events/${id}.json`);
  }
}
