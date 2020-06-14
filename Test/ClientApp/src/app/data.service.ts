import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { SaleModel } from './Models/SaleModel';
//import * as Highcharts from 'highcharts';

@Injectable()
export class DataService {
  private urlSales = "/api/HistorySale";
  private urlNames = "api/DateGroupType";
  GroupPeriod = 'Day';
  DT1 = '1900-01-01';
  DT2 = '9999-12-31';



  private _trigger = new Subject<void>();
  get trigger$() {
    return this._trigger.asObservable();
  }
  public triggerOnMyButton() {
    this._trigger.next();
  }

  constructor(private http: HttpClient) { }

  getNames() {
    return this.http.get(this.urlNames);
  }
  setGroupPeriod(Group: string) {
    this.GroupPeriod = Group;
    this.triggerOnMyButton();
    //this.getSales();
  }
  setTimePeriodAll(DT1: string, DT2: string) {
    this.DT1 = DT1;
    this.DT2 = DT2;
    this.getSales();
  }
  setTimePeriodStart(DT1: string) {
    this.DT1 = DT1;
    this.getSales();
  }
  setTimePeriodEnd(DT2: string) {
    this.DT2 = DT2;
    this.getSales();
  }

  getSales() {
    //this.XArgs = new Array<string>();
    //this.Column = new Array<number>();
    //this.Line = new Array<number>();
    return this.http.get(this.urlSales + '/group=' + this.GroupPeriod + '&StartDT=' + this.DT1 + '&EndDT=' + this.DT2);
  }
}
