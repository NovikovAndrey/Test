import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { DataService } from '../data.service';
import { SaleModel } from '../Models/SaleModel';
//import { NgbdDropdown } from '../DropBox/dropdown.component';

@Component({
  selector: 'app-Highcharts',
  templateUrl: `./sales.component.html`,
  //providers: [DataService]
})

export class SaleComponent implements OnInit{
  public log = [];

  //
  sales: SaleModel[];
  title = 'app';
  Y1 = 'Sum (In thousands)';
  ColumnLegend = 'Sum $/K';
  LineLegend = 'Sales';
  XArgs: string[];
  Column: number[];
  Line: number[];
  //

  constructor(private dataService: DataService) { }

  ngOnInit() {
    //this.loadSales();
    this.dataService.trigger$.subscribe(() => this.myMethod()); 
  }

  public loadSales() {
    this.XArgs = new Array<string>();
    this.Column = new Array<number>();
    this.Line = new Array<number>();
    this.dataService.getSales().subscribe((data: SaleModel[]) => {
      this.sales = data;
      for (var i = 0, len = this.sales.length; i < len; i++) {
        this.XArgs[i] = this.sales[i].dateSale.toString();
        this.Column[i] = +(this.sales[i].amountDollars / 1000).toFixed(2);
        this.Line[i] = this.sales[i].sale;
      }
      Highcharts.chart('SalesChart', {
        chart: { zoomType: 'xy' },
        title: { text: this.title },
        xAxis: { categories: this.XArgs, crosshair: true },
        yAxis: [
          { // Primary yAxis
            title: {
              text: this.Y1,
              style: {
                color: Highcharts.getOptions().colors[1]
              }
            }
          },
          { // Secondary yAxis
            title: {
              text: '',
              style: {
                color: Highcharts.getOptions().colors[0]
              }
            },
            labels: {
              style: {
                color: Highcharts.getOptions().colors[0]
              }
            },
            opposite: true
          }
        ],
        legend: {
          layout: 'vertical',
          align: 'right',
          x: -100,
          verticalAlign: 'top',
          y: 0,
          floating: true
        },
        series: [
          {
            name: this.ColumnLegend,
            type: 'column',
            data: this.Column,
          },
          {
            name: this.LineLegend,
            type: 'spline',
            yAxis: 1,
            data: this.Line,
          }
        ],
        tooltip: {
          shared: true
        }
      });
    });
     
  }
  myMethod() {

    this.log.push(new Date());
  }
}
