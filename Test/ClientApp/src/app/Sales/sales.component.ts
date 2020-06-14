import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { DataService } from '../data.service';
import { SaleModel } from '../Models/SaleModel';
import { NgbdDropdown } from '../DropBox/dropdown.component';

@Component({
  selector: 'app-Highcharts',
  templateUrl: `./sales.component.html`,
  providers: [DataService]
})

export class SaleHighchartsComponent implements OnInit{
  public log = [];
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.trigger$.subscribe(() => this.myMethod()); 
  }

  public loadSales() {
    this.dataService.getSales();
     
  }
  myMethod() {
    this.log.push(new Date());
  }
}
