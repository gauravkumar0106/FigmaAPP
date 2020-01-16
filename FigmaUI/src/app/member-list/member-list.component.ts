import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { MembersServiceService } from '../_services/membersService.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  employees: any = {};

  constructor(public authService: AuthService,
              private router: Router,
              private memeberService: MembersServiceService) { }

  ngOnInit() {
    this.loadEmp();
  }


  loadEmp()
  {
    this.memeberService.getEmployees().subscribe(res => {
      this.employees = res;
      console.log(res);
     }
      );
  }
  signOut() {
    localStorage.removeItem('token');
    this.router.navigate(['/sign']);
    console.log('logged out');
  }

  delete(empId) {
    console.log(empId);
    if(!confirm('Are you sure you want to delete this employee?')) return;
    this.memeberService.deleteEmployee(empId).subscribe(res=>this.router.navigate(['/memberslist']));
    this.loadEmp();
  }

}
