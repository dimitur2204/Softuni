import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public isLogged = false;
  public email:string;
  constructor(private authService:AuthenticationService) { }

  ngOnInit(): void {
    this.authService.user.subscribe(user => {
      if (user) {
        this.isLogged = true;
        this.email = user.email;
        return;
      }
      this.isLogged = false;
      this.email = '';
    })
  }
  onLogoutClicked(){
    this.authService.signOut();
  }
}
