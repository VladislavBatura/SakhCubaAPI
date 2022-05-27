import { Injectable } from '@angular/core';
import { Application } from 'src/assets/application';
import { HttpClient } from '@angular/common/http';
import { applicationPost, index, indexNews } from '../../assets/Adressess';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  constructor(private http: HttpClient) { }

  postData(application: Application){
    return this.http.post(applicationPost, application);
  }

  getIndex() {
    return this.http.get(index);
  }

  getIndexNews() {
    return this.http.get(indexNews);
  }

  getOneNews(id: number) {
    return this.http.get(indexNews + id);
  }
}
