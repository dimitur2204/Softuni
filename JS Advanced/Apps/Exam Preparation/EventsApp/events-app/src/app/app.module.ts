import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { NotFound404Component } from './components/not-found404/not-found404.component';
import { EventComponent } from './components/events/event/event.component';
import { EventsComponent } from './components/events/events.component';
import { CreateEventComponent } from './components/events/create-event/create-event.component';
import { EditEventComponent } from './components/events/edit-event/edit-event.component';
import { EventDetailsComponent } from './components/events/event-details/event-details.component';
import { SignUpComponent } from './components/user/sign-up/sign-up.component';
import { SignInComponent } from './components/user/sign-in/sign-in.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { LoadingComponent } from './components/utils/loading/loading.component';
import { SuccessComponent } from './components/utils/success/success.component';
import { ErrorComponent } from './components/utils/error/error.component';
import {AppRoutingModule} from './modules/routing/routing.module';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    HeaderComponent,
    NotFound404Component,
    EventComponent,
    EventsComponent,
    CreateEventComponent,
    EditEventComponent,
    EventDetailsComponent,
    SignUpComponent,
    SignInComponent,
    ProfileComponent,
    LoadingComponent,
    SuccessComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
