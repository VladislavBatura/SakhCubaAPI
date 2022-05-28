import { AfterViewInit, Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminApplication, AdminApplicationView } from '../../assets/application';
import { AdminService } from '../Services/admin.service';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.css']
})
export class AdminViewComponent implements OnInit, AfterViewInit {

  application!: AdminApplicationView;
  ifError: boolean = false;
  ifClientError: boolean = false;

  @ViewChild('dropdown') dropdown!: ElementRef<HTMLInputElement>;
  @ViewChild('decisionParagraph') decisionParagraph!: ElementRef<HTMLInputElement>;

  constructor(private route: ActivatedRoute,
    private adminService:AdminService,
    private router:Router,
    private renderer: Renderer2) { }

  ngOnInit(): void {
    if (this.application == null){
      this.route.data.subscribe((data) => {
        console.log(data);
        this.application = data.adminGetOne;
      });
    }
  }

  ngAfterViewInit(): void {
    this.setDecision(this.application.decisionId, this.application.decision);
  }

  setDecision(decisionId: number, decision: string){
    this.application.decisionId = decisionId;
    this.application.decision = decision;
    switch(decisionId){
      case 2:
        this.setBackgroundColor('green');
        break;
      case 3:
        this.setBackgroundColor('blue');
        break;
      case 4:
        this.setBackgroundColor('#ee4646');
        break;
    }
    this.renderer.setStyle(this.dropdown.nativeElement, 'color', 'white');
    this.renderer.setStyle(this.decisionParagraph.nativeElement, 'color', 'white');
  }

  setBackgroundColor(color:string){
    this.renderer.setStyle(this.dropdown.nativeElement, 'background', color);
    this.renderer.setStyle(this.decisionParagraph.nativeElement, 'background', color);
  }

  sendApplication(){
    this.adminService.putApplication(this.application).subscribe({
      error: err => {
        console.log(err);
        this.ifError = true;
        if (err == Error){
          this.ifClientError = true;
        }
      },
      complete: () => this.router.navigateByUrl('admin')
    });
  }

  deleteApplication(){
    this.adminService.deleteApplication(this.application.id).subscribe({
      error: err => {
        console.log(err);
        this.ifError = true;
        if (err == Error){
          this.ifClientError = true;
        }
      },
      complete: () => this.router.navigateByUrl('admin')
    });
  }

}
