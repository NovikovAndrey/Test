import { Component, Injectable } from '@angular/core';
import { NgbCalendar, NgbDateAdapter, NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from '../data.service';
import { strict } from 'assert';

@Injectable()
export class CustomDateParserFormatter extends NgbDateParserFormatter {
  
  readonly DELIMITER = '/';

  parse(value: string): NgbDateStruct | null {
    if (value) {
      let date = value.split(this.DELIMITER);
      return {
        day: parseInt(date[1], 10),
        month: parseInt(date[0], 10),
        year: parseInt(date[2], 10)
      };
    }
    return null;
  }

  format(date: NgbDateStruct | null): string {
    return date ? date.month + this.DELIMITER + date.day + this.DELIMITER + date.year : '';
  }
}

@Component({
  selector: 'ngbd-datepicker',
  templateUrl: './datepicker.component.html',
  providers: [
    { provide: NgbDateParserFormatter, useClass: CustomDateParserFormatter }
  ]
})

export class NgbdDatepickerAdapter {
  model2: string;
  model1: string;
  DPFirst: NgbDateStruct;
  DPSecond: NgbDateStruct;
  readonly DELIMITER = '-';
  newmonth: string;
  newday: string;
  constructor(private dataService: DataService) {
   
  }

  dateSelectDPFirst(DT1:any) {
    this.DPFirst = DT1;
    this.ValidPeriod();
    //ValidPeriod(this.DPFirst, this.DPSecond);
  }

  dateSelectDPSecond(DT2: any) {
    this.DPSecond = DT2;
    this.ValidPeriod();
  }

  format(date: NgbDateStruct | null): string {
    if (date.month < 10) {
      this.newmonth = ('0' + date.month);
    }
    else { this.newmonth = date.month.toString() }
    if (date.day < 10) {
      this.newday = ('0' + date.day);
    }
    else { this.newday = date.day.toString() }
    return date ? date.year + this.DELIMITER + this.newmonth + this.DELIMITER + this.newday : '';
  }

  ValidPeriod() {
    if (this.DPFirst != null && this.DPSecond != null) {
      if ((this.DPFirst.year < this.DPSecond.year) || (this.DPFirst.month < this.DPSecond.month && this.DPFirst.year == this.DPSecond.year) || (this.DPFirst.day <= this.DPSecond.day && this.DPFirst.month == this.DPSecond.month && this.DPFirst.year == this.DPSecond.year)) {
        this.dataService.setTimePeriodAll(this.format(this.DPFirst), this.format(this.DPSecond));
      }
      else {
        this.Replace();
      }
    }
    else {
      if (this.DPFirst && this.DPSecond == null) {
        this.dataService.setTimePeriodStart(this.format(this.DPFirst));
      }
      else {
        if (this.DPFirst==null && this.DPSecond) {
          this.dataService.setTimePeriodEnd(this.format(this.DPSecond));
        }
      }
    }
  }
  Replace() {
    var DPTemp = this.DPFirst;
    var modelTemp = this.model1;
    this.DPFirst = this.DPSecond;
    this.model1 = this.model2;
    this.DPSecond = DPTemp;
    this.model2 = modelTemp;
    this.ValidPeriod();
  }
}
