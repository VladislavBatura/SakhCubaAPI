import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { login } from 'src/assets/Adressess';
import { UserApp } from '../assets/UserApp';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import {shareReplay, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient){}

  login(email:string, password:string) {
    const user : UserApp = new UserApp(email, password);
    return this.http.post(login, user).pipe(tap(res => this.setSession(res)), shareReplay());
  }

  private setSession(authResult : any) {
    const expiresAt = moment().add(authResult.ExpiresIn, 'second');

    localStorage.setItem('id_token', authResult.IdToken);
    localStorage.setItem('expires_at', JSON.stringify(expiresAt.valueOf()));
  }

  logOut() {
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
  }

  public isLoggedIn(){
    return moment().isBefore(this.getExpiration());
  }

  isLoggedOut(){
    return !this.isLoggedIn();
  }

  getExpiration(){
    const expiration = localStorage.getItem('expires_at');
    const expiresAt = JSON.parse(expiration!);
    return moment(expiresAt);
  }
}
