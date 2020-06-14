import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';


@Component({
  selector: 'app-comp2',
  templateUrl: './comp2.component.html',
  //styleUrls: ['./comp2.component.css']
})
export class Comp2Component implements OnInit {
  public log = [];

  constructor(
    private dataService: DataService,
  ) { }

  ngOnInit() {
    this.dataService.trigger$.subscribe(() => this.myMethod());
  }

  myMethod() {
    this.log.length = 0;
    this.log.push(new Date());
  }

}
