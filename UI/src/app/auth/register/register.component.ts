import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Gender } from 'src/app/Enums/gender.enum';
import { UserRegistration } from 'src/app/models/auth-models/user-registration.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  invalidLogin?: boolean;
  credentials: UserRegistration = {
    username: '',
    password: '',
    fullName: '',
    phoneNumber: '',
    gender: Gender.Male,
    role: ''
  };

  roles: string[] = ["Doctor"];
  gender: Gender[] = [
    Gender.Male,
    Gender.Female,
    Gender.Other
  ]

  constructor(private router: Router, 
    private http: HttpClient, 
    private jwtHelper: JwtHelperService,
    private snackbar: MatSnackBar) { 
      
    }
  ngOnInit(): void {
   
  }

  register(form: NgForm){
    if (form.valid) {
      console.log(this.credentials);
      this.http.post<string>("https://localhost:7079/api/auth/register", this.credentials, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response) => {
          // console.log(response);
          this.snackbar.open('Registered Successfully, You can login now', undefined, {duration: 2000});
          this.invalidLogin = false;
          this.router.navigate(["/login"]);
        },
        error: (err: HttpErrorResponse) => {
          this.invalidLogin = true;
        }
      });
    }
  }

  getGenderName(method: Gender): string {
    switch (method) {
      case Gender.Female:
        return 'Female';
      case Gender.Male:
        return 'Male';
      case Gender.Other:
        return 'Other';
      default:
        return '';
    }
  }
}
