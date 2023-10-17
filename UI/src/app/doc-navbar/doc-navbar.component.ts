import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-doc-navbar',
  templateUrl: './doc-navbar.component.html',
  styleUrls: ['./doc-navbar.component.css']
})
export class DocNavbarComponent {

  constructor(private jwtHelper: JwtHelperService, private router: Router, private snackbar: MatSnackBar) {

  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    // console.log(localStorage.getItem("jwt"));
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
  public logOut = () => {
    localStorage.removeItem("jwt");
    this.snackbar.open('Logged Out', undefined, {duration: 2000});
    this.router.navigate(['/login']);
  }


  isAdmin(){
    const role = localStorage.getItem("role");
    // console.log(role);
    if(role === "admin" || role === "Admin" || role === "ADMIN"){
          return true;
    }
    return false;
  }
}
