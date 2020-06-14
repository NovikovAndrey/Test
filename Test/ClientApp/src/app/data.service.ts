import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable()
export class DataService {
  private _trigger = new Subject<void>();
  get trigger$() {
    return this._trigger.asObservable();
  }
  public triggerOnMyButton() {
    this._trigger.next();
  }

  constructor() { }

}
