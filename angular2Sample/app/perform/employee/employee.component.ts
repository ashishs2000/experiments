import { Component, OnInit,} from '@angular/core';

@Component({
  selector: 'employee',
  template: `
    <h1>Employee</h1>    
  `,
})
export class EmployeeComponent implements OnInit {
  public ngOnInit() {
    console.log('Hello from Employee Component');
  }
}