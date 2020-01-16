import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router, public authService: AuthService) { }

  ngOnInit() {
  }

  signOut() {
    localStorage.removeItem('token');
    this.router.navigate(['/sign']);
    console.log('logged out');
  }

}
