import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

@Injectable()
export class MembersServiceService {
baseUrl = 'http://localhost:5000/api/user/';
employees: any;

constructor(private http: HttpClient) { }

getToken() {
    return localStorage.getItem('token');
}
getEmployees() {
    return this.http.get(this.baseUrl + 'employees', {headers:
    new HttpHeaders().set('Authorization', 'Bearer ' + this.getToken())});
}

getEmployee(empId) {
    return this.http.get(this.baseUrl + 'employees/' + empId, {headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.getToken())});
}

updateEmployee(empId, emp) {
    return this.http.put(this.baseUrl + 'employees/' + empId, emp, {headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.getToken())});
}

createEmployee(emp) {
    return this.http.post(this.baseUrl + 'employees/add' , emp, {headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.getToken())});
}

deleteEmployee(empId) {
    return this.http.delete(this.baseUrl + 'delete/' + empId, {headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.getToken())});
}

}


