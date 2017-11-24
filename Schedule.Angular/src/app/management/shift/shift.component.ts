import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { SelectItem } from 'primeng/primeng';
import { ApiService } from '../../api.service';
import { Time } from '@angular/common/src/i18n/locale_data_api';

@Component({
  selector: 'app-shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ShiftComponent implements OnInit {

  selectedShift: SelectItem[];

  display: boolean    = false;
  isNewShift: boolean = false;

  shift: any;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }

  showDialog(){
    this.display    = true;
    this.shift      = new Shift();
    this.isNewShift = true;
  }

  save(){

  }


  delete(){
    
  }
}

class Shift {
  date?: string;
  timeIn?: string;
  timeOut?: string;
  lunchStart?: Time;
  lunchEnd?: Time;
};