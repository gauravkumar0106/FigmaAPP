import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'signIn',
  templateUrl: './signIn.component.html',
  styleUrls: ['./signIn.component.css']
})
export class SignInComponent implements OnInit {
  model: any = {};
  registerMode = false;
  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
    localStorage.removeItem('token');
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in succesfully');
      this.router.navigate(['/memberslist']);
    }, error => {
      alert('Incorrect Username or Password');
      console.log('Failed to Login');
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  // logout() {
  //   localStorage.removeItem('token');
  //   console.log('logged out');
  // }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
