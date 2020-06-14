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

@NgModule({
  declarations: [
    AppComponent,
    HighchartsChartComponent,
    SaleComponent,
    NgbdDatepickerAdapter,
    NgbdDropdown
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule
  ],
  exports: [
    NgbdDropdown,
    NgbdDatepickerAdapter
  ],
  providers: [DataService],
  bootstrap: [AppComponent, NgbdDropdown, NgbdDatepickerAdapter]
})
export class AppModule { }
