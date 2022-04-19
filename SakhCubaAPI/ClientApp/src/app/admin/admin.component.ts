import { Component, OnInit } from '@angular/core';
import { AdminApplication } from '../../assets/application';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  applications: AdminApplication[] = [];

  constructor(private httpService: AdminService) { }

  ngOnInit(): void {
  }

  loadApplications(){
    this.httpService.getAllApplications().subscribe((data: any) => this.applications = data,
      error => console.log(error));
  }
  //ИСПРАВЬ НА БЭКЭНДЕ ОТПРАВКУ АНКЕТ - СДЕЛАЙ НОВУЮ МОДЕЛЬ, КОТОРАЯ НЕ ПАДАЕТ В РЕКУРСИЮ С РЕШЕНИЯМИ
}
