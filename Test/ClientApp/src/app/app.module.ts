//import { BrowserModule } from '@angular/platform-browser';
//import { NgModule } from '@angular/core';
//import { FormsModule } from '@angular/forms';
//import { HttpClientModule } from '@angular/common/http';
//import { RouterModule } from '@angular/router';
//import { AppComponent } from './app.component';

//import { Comp1Component } from './comp1/comp1.component';
//import { Comp2Component } from './comp2/comp2.component';
//import { DataService } from './data.service';
//@NgModule({
//  declarations: [
//    AppComponent,
//    Comp1Component,
//    Comp2Component

//  ],
//  imports: [
//    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
//    HttpClientModule,
//    FormsModule,
//  ],
//  providers: [DataService],
//  bootstrap: [AppComponent]
//})
//export class AppModule { }
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { SaleComponent } from './Sales/sales.component';
import { HighchartsChartComponent } from 'highcharts-angular';
import { NgbdDropdown } from './DropBox/dropdown.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from './data.service';
import { NgbdDatepickerAdapter } from './DatePickers/datepicker.component';

import { Comp2Component } from './comp2/comp2.component';

@NgModule({
  declarations: [
    AppComponent,
    HighchartsChartComponent,
    SaleComponent,
    NgbdDatepickerAdapter,
    NgbdDropdown,
    Comp2Component
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    //RouterModule.forRoot([
    //  { path: '', component: SaleHighchartsComponent, pathMatch: 'full' },
    //])
  ],
  exports: [
    NgbdDropdown,
    NgbdDatepickerAdapter
  ],
  providers: [DataService],
  bootstrap: [AppComponent, NgbdDropdown, NgbdDatepickerAdapter]
})
export class AppModule { }
