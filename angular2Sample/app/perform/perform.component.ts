import { Component, OnInit, } from '@angular/core';

@Component({
  selector: 'detail',
  template: `
    <h1>Hello from Detail</h1>
    <span>
      <a [routerLink]=" ['./employee'] ">Employee</a>
    </span>
    <router-outlet></router-outlet>
  `,
})
export class PerformComponent implements OnInit {
  public ngOnInit() {
    console.log('Perform Component');
  }

}