import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../application.service';
import { News } from '../../assets/news';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  constructor(private httpService: ApplicationService) { }

  news: News[] = [];

  ngOnInit(): void {
  }

  loadNews() : void {
    this.httpService.getIndexNews().subscribe((data: any) => this.news = data,
     error => console.log(error));
  }
}
