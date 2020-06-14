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
  sales: SaleModel[];
  title = 'app';
  Y1 = 'Sum (In thousands)';
  ColumnLegend = 'Sum $/K';
  LineLegend = 'Sales';
  XArgs: string[];
  Column: number[];
  Line: number[];
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
    return this.http.get(this.urlSales + '/group=' + this.GroupPeriod + '&StartDT=' + this.DT1 + '&EndDT=' + this.DT2).subscribe((data: SaleModel[]) => {
      this.sales = data;
    });
    //  for (var i = 0, len = this.sales.length; i < len; i++) {
    //    this.XArgs[i] = this.sales[i].dateSale.toString();
    //    this.Column[i] = +(this.sales[i].amountDollars / 1000).toFixed(2);
    //    this.Line[i] = this.sales[i].sale;
    //  }
    //  Highcharts.chart('SalesChart', {
    //    chart: { zoomType: 'xy' },
    //    title: { text: this.title },
    //    xAxis: { categories: this.XArgs, crosshair: true },
    //    yAxis: [
    //      { // Primary yAxis
    //        title: {
    //          text: this.Y1,
    //          style: {
    //            color: Highcharts.getOptions().colors[1]
    //          }
    //        }
    //      },
    //      { // Secondary yAxis
    //        title: {
    //          text: '',
    //          style: {
    //            color: Highcharts.getOptions().colors[0]
    //          }
    //        },
    //        labels: {
    //          style: {
    //            color: Highcharts.getOptions().colors[0]
    //          }
    //        },
    //        opposite: true
    //      }
    //    ],
    //    legend: {
    //      layout: 'vertical',
    //      align: 'right',
    //      x: -100,
    //      verticalAlign: 'top',
    //      y: 0,
    //      floating: true
    //    },
    //    series: [
    //      {
    //        name: this.ColumnLegend,
    //        type: 'column',
    //        data: this.Column,
    //      },
    //      {
    //        name: this.LineLegend,
    //        type: 'spline',
    //        yAxis: 1,
    //        data: this.Line,
    //      }
    //    ],
    //    tooltip: {
    //      shared: true
    //    }
    //  });
    //});;
  }
}
