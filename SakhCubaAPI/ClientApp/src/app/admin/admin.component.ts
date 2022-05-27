import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminApplication } from '../../assets/application';
import { AdminService } from '../Services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  applications: AdminApplication[] = [];

  constructor(private httpService: AdminService,
    private route:ActivatedRoute,
    private router:Router)
    { }

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      console.log(data);
      this.applications = data.adminGet;
    });
  }

  loadApplications(){
    this.httpService.getAllApplications().subscribe((data: any) => this.applications = data,
      error => console.log(error));
  }

  redirectToView(id:number){
    this.router.navigate(['/admin/', id]);
  }
}
