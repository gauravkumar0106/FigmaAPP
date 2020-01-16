import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './signIn/signIn.component';
import { AuthService } from './_services/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MemberComponent } from './member/member.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { MembersServiceService } from './_services/membersService.service';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
   declarations: [
      AppComponent,
      SignInComponent,
      HomeComponent,
      RegisterComponent,
      MemberListComponent,
      MemberComponent,
      NavbarComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      MembersServiceService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
