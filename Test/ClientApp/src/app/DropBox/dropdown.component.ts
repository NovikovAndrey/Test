import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'ngbd-dropdown',
  templateUrl: './dropdown.component.html',
})
export class NgbdDropdown implements OnInit{
  names: string[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadNames();
  }

  loadNames() {
    this.dataService.getNames()
      .subscribe((data: string[]) => {
        this.names = data;
      })
  };

  public GetGroup(increased: string) {
    this.dataService.setGroupPeriod(increased);
  };
}
