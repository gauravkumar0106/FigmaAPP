import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take,map } from 'rxjs/operators';
import { MembersServiceService } from '../_services/membersService.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {
 employee ={};
  id;

  constructor(private route: ActivatedRoute,
              private memeberService: MembersServiceService,
              private router: Router) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id) {
       this.memeberService.getEmployee(this.id)
       .pipe(take(1))
       .subscribe(res =>this.employee=res);
    }
  }

  save(employee) {
    if (this.id) {
      this.memeberService.updateEmployee(this.id,employee)
      .subscribe(res=>console.log(res));
    }
    else {
      this.memeberService.createEmployee(employee)
      .subscribe(res=>console.log(res));
    }

    this.router.navigate(['/memberslist']);
  }
  back() {
    this.router.navigate(['/memberslist']);
    
  }

}
