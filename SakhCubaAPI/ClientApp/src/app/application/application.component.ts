import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Application } from 'src/assets/application';
import { ApplicationService } from '../application.service';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.css']
})
export class ApplicationComponent implements OnInit {

  constructor(private httpService: ApplicationService) { }

  ngOnInit(): void {
  }

  application: Application = new Application("", "", "");
  done: boolean = false;

  onSubmit(form: NgForm){
    this.httpService.postData(this.application)
      .subscribe((data:any) => {this.done = true;},
      error => console.log(error));
  }
}
