import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form:FormGroup;
  isError:boolean = false;
  isLoading = false;

  constructor(private fb:FormBuilder,
    private authService:AuthService,
    private router: Router) { 
      this.form = this.fb.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
      });
    }

  ngOnInit(): void {
  }

  login() {
    const val = this.form.value;
    this.isLoading = true;

    if (val.email && val.password) {
      this.authService.login(val.email, val.password)
        .subscribe(
          () => {
            this.router.navigateByUrl('/admin');
          },
          error => {
            console.log(error);
            this.isError = true;
            this.isLoading = false;
          }
        )
    }
  }
}
