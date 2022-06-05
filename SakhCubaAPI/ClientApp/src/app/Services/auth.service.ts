import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { login } from 'src/assets/Adressess';
import { UserApp } from '../../assets/UserApp';
import {shareReplay, tap} from 'rxjs/operators';
import { Credentials } from 'src/assets/Credentials';

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
    /*let obj: Credentials = JSON.parse(authResult);

    let expiration = obj.ExpiresIn;
    let token = obj.idToken;*/

    localStorage.setItem('id_token', authResult.IdToken);
    localStorage.setItem('expires_at', authResult.ExpiresIn);
  }

  logOut() {
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
  }

  public isLoggedIn(){
    return !this.getExpiration();
  }

  isLoggedOut(){
    return !this.isLoggedIn();
  }

  getExpiration(){
    const expiration = localStorage.getItem('id_token');

    const expiry = (JSON.parse(atob(expiration!.split('.')[1]))).exp;
    return (Math.floor((new Date).getTime() / 1000)) >= expiry;
  }
}
