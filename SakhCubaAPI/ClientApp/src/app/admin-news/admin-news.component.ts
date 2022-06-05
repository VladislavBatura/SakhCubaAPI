import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { News } from 'src/assets/news';
import { AdminService } from '../Services/admin.service';

@Component({
  selector: 'app-admin-news',
  templateUrl: './admin-news.component.html',
  styleUrls: ['./admin-news.component.css']
})

export class AdminNewsComponent implements OnInit {

  imageSrc: string = '';
  newsArray: News[] = [];
  newsToCreate: News = new News(0, '', new Date(), '', '');

  constructor(private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal,
    private adminService: AdminService) { }

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.newsArray = data.newsGet;
    });
  }

  redirectToView(id: number){
    this.router.navigate(['admin/news/', id]);
  }

  async handleImageUpload(e: any){
    await this.convertImageToBase64(e);
  }

  private async convertImageToBase64(input:any){
    var reader = new FileReader();
    var file : File = input.dataTransfer ? input.dataTransfer.files[0] : input.target.files[0];
    var pattern = /image-*/;

    if (!file.type.match(pattern)){
      alert('invalid format');
      return;
    }
      
    reader.onload = this._handleReaderLoader.bind(this);
    reader.onerror = error => console.log(error);

    reader.readAsDataURL(file);
  }

  private _handleReaderLoader(e : any) {
    var reader = e.target;
    this.imageSrc = reader.result;
    this.newsToCreate.image = this.imageSrc;
    console.log("image successully encoded");
  }

  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  sendNewsToServer(modal: any){
    let newsToServer = new News(this.newsToCreate.id,
       this.newsToCreate.title,
        this.newsToCreate.date,
         this.newsToCreate.body,
          this.newsToCreate.image);
    console.log(newsToServer);
    this.adminService.postNews(newsToServer).subscribe({
      error: err => {
        console.log(err);
        //this.ifError = true;
        if (err == Error){
         // this.ifClientError = true;
        }
      },
      complete: () => modal.close()
    });
  }
}
