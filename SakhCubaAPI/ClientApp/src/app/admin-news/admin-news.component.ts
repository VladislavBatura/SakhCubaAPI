import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-news',
  templateUrl: './admin-news.component.html',
  styleUrls: ['./admin-news.component.css']
})

export class AdminNewsComponent implements OnInit {

  imageSrc: string = '';

  constructor() { }

  ngOnInit(): void {
    
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
    console.log("image successully encoded");
  }
}
