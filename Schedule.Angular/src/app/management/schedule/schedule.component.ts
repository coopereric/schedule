import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { FormGroup, 
    FormBuilder, 
    Validators }         from '@angular/forms';
import { SelectItem }    from 'primeng/primeng';

import { ApiService } from '../../api.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ScheduleComponent implements OnInit {
    events: any[];
    users:  any[];
    header:   any;
  
    editScheduleForm: FormGroup;
    selectedUser: any;
  
    display: boolean       = false;
    isNewSchedule: boolean = false;

  constructor(private fb: FormBuilder, private apiService: ApiService) {
      this.editScheduleForm = this.fb.group({
          date: ['', Validators.required],
          user: ['', Validators.required],
          timeIn: '',
          timeOut: ''
      });
   }

  ngOnInit() {
    this.header = {
        left: 'prev,next today',
        center: 'title',
        right: 'month,agendaWeek,agendaDay'
    };

    this.users = [
        {'userName': 'Eric Cooper', 'id': '123'},
        {'userName': 'Abigail Cooper', 'id': '1234'}
    ];

    this.events = [
      {
          "title": "All Day Event",
          "start": "2017-11-01"
      },
      {
          "title": "Long Event",
          "start": "2017-11-07",
          "end": "2017-11-10"
      },
      {
          "title": "Repeating Event",
          "start": "2017-11-09T16:00:00"
      },
      {
          "title": "Repeating Event",
          "start": "2017-11-16T16:00:00"
      },
      {
          "title": "Conference",
          "start": "2017-11-11",
          "end": "2017-11-13"
      }
  ];
  }

  showCreateDialog(){
    this.display        = true;
    this.isNewSchedule  = true;
  }
}
