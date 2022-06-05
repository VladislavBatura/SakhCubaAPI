import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { admin } from 'src/assets/Adressess';
import { AdminApplication } from '../../assets/application';
import { news } from '../../assets/Adressess';
import { News } from '../../assets/news';

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

  getAllNews(){
    return this.http.get(news);
  }

  getOneNews(id: number){
    return this.http.get(news + id);
  }

  putNews(newsModel: News){
    return this.http.put(news, newsModel);
  }

  deleteNews(id: number){
    return this.http.delete(news + id);
  }

  postNews(newsModel: News){
    return this.http.post(news, newsModel);
  }
}
