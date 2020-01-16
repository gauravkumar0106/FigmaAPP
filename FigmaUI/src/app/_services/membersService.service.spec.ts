/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MembersServiceService } from './membersService.service';
import {  HttpClient,HttpHandler } from '@angular/common/http';
describe('Service: MembersService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MembersServiceService,HttpClient, HttpHandler]
    });
  });

  it('should ...', inject([MembersServiceService], (service: MembersServiceService) => {
    expect(service).toBeTruthy();
  }));
});
