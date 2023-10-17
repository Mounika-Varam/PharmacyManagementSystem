import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedResponse } from 'src/app/models/auth-models/authenticated-response.model';
import { UserLogin } from 'src/app/models/auth-models/user-login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  invalidLogin?: boolean;
  credentials: UserLogin = {
    username: '',
    password: ''
  };

  response: AuthenticatedResponse = {
    jwtToken : "",
    userId: '',
    role: '',
  }

  constructor(private router: Router, 
    private http: HttpClient, 
    private jwtHelper: JwtHelperService,
    private snackbar: MatSnackBar) { }
  ngOnInit(): void {
   
  }

  login(form: NgForm){
    if (form.valid) {
      this.http.post<AuthenticatedResponse>("https://localhost:7079/api/auth/login", this.credentials, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
            // console.log(response, response.jwtToken)
          const token = response.jwtToken;
          const userId = response.userId;
          const role = response.role;
          // console.log(token, userId, role);
          localStorage.setItem("jwt", token); 
          localStorage.setItem("userId", userId); 
          localStorage.setItem("role", role); 

          // console.log(localStorage.getItem("jwt"));
          this.invalidLogin = false; 
          this.snackbar.open('Logged In Successfully', undefined, {duration: 2000});
          this.router.navigate(["/home"]);
        },
        error: (err: HttpErrorResponse) => this.invalidLogin = true

      });
    }
  }

}
