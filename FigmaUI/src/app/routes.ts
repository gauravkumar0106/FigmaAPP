import { Routes } from '@angular/router';
import { SignInComponent } from './signIn/signIn.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MemberComponent } from './member/member.component';
import { AuthGuard } from './_guards/auth.guard';


export const appRoutes: Routes = [
    {path: '', component: SignInComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
          {path: 'memberslist', component: MemberListComponent},
          {path: 'member/new', component: MemberComponent},
          {path: 'member/:id', component: MemberComponent}
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
