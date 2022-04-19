import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { admin } from 'src/assets/Adressess';
import { AdminApplication } from '../assets/application';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  getAllApplications(){
    return this.http.get(admin);
  }

  getOneApplication(id:number){
    return this.http.get(admin + id);
  }

  putApplication(app:AdminApplication){
    return this.http.put(admin, app);
  }

  deleteApplication(id:number){
    return this.http.delete(admin + id);
  }
}
