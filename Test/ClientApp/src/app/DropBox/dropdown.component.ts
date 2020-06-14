import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { DataService } from '../data.service';
import { SaleHighchartsComponent } from '../Sales/sales.component';

@Component({
  selector: 'ngbd-dropdown',
  templateUrl: './dropdown.component.html',
})
export class NgbdDropdown implements OnInit{
  names: string[];
  comp: SaleHighchartsComponent;
  count: string;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadNames();
  }

  loadNames() {
    this.dataService.getNames()
      .subscribe((data: string[]) => {
        this.names = data;
      }
      )
  };

  public GetGroup(increased: string) {
    this.dataService.triggerOnMyButton();
    //this.dataService.setGroupPeriod(increased);
  };
}
