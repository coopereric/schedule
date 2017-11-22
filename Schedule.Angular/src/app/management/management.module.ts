import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { ManagementComponent } from './management.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { UserComponent } from './user/user.component';
import { SidebarComponent } from '../sidebar/sidebar.component';

export const managementRoutes: Routes = [
  {
    path: 'management', component: ManagementComponent,
    children: [
      { path: 'schedules', component: ScheduleComponent },
      { path: 'users', component: UserComponent }
    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(managementRoutes)
  ],
  declarations: 
  [
    ManagementComponent, 
    ScheduleComponent, 
    SidebarComponent,
    UserComponent
  ],
  exports: [ManagementComponent]
})
export class ManagementModule { }
