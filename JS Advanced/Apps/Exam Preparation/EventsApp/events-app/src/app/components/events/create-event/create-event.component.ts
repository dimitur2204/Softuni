import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {EventsService} from '../../../services/events.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import {Event} from '../event.model';
@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {

  constructor(private authService:AuthenticationService,
    private eventsService:EventsService) { }

  ngOnInit(): void {
  }
  onSubmit(form:NgForm){
    const formValues = form.value;
    const name = formValues.name;
    const date = formValues.date;
    const desc = formValues.description;
    const imageURL = formValues.imageURL;
    const event = new Event(
      name,
      date,
      desc,
      imageURL,
      this.authService.user.value.id);
      form.reset();
    this.eventsService.addEvent(event);
  }
}
