import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { News } from 'src/assets/news';
import { AdminService } from '../Services/admin.service';

@Component({
  selector: 'app-admin-news-view',
  templateUrl: './admin-news-view.component.html',
  styleUrls: ['./admin-news-view.component.css']
})
export class AdminNewsViewComponent implements OnInit {

  news!: News;
  ifError: boolean = false;
  ifClientError: boolean = false;

  constructor(private route:ActivatedRoute,
    private router: Router,
    private adminService: AdminService) { }

  ngOnInit(): void {
    if (this.news == null){
      this.route.data.subscribe((data) => {
        this.news = data.oneNews;
      });
    }
  }

  sendNews(){
    this.adminService.putNews(this.news).subscribe({
      error: err => {
        console.log(err);
        this.ifError = true;
        if (err == Error){
          this.ifClientError = true;
        }
      },
      complete: () => this.router.navigateByUrl('admin/news')
    });
  }

  deleteNews(){
    this.adminService.deleteNews(this.news.id).subscribe({
      error: err => {
        console.log(err);
        this.ifError = true;
        if (err == Error){
          this.ifClientError = true;
        }
      },
      complete: () => this.router.navigateByUrl('admin/news')
    });
  }

}
