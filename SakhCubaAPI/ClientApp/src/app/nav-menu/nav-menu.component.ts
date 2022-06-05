import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLogged = false;
  _authService: AuthService;

  constructor(authService: AuthService)
  {
    this._authService = authService;
  }

  ngOnInit(){
    if (this._authService.isLoggedIn()){
      this.isLogged = true;
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
    console.log(this._authService.isLoggedIn());
    if (this._authService.isLoggedIn()){
      this.isLogged = true;
      console.log("logged");
    }
  }
}
