import { NgModule }                from '@angular/core';
import { CommonModule }            from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Routes, RouterModule }    from '@angular/router';
import { ReactiveFormsModule }     from '@angular/forms';

import { DataTableModule, 
  DialogModule, ScheduleModule, 
  DropdownModule, ButtonModule } from 'primeng/primeng';

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
    RouterModule.forChild(managementRoutes),
    ReactiveFormsModule,
    DataTableModule,
    DialogModule,
    ScheduleModule,
    ButtonModule,
    DropdownModule,
    BrowserAnimationsModule
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
