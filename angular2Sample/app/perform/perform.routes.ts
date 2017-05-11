import { PerformComponent } from './perform.component';
import { EmployeeComponent } from './employee/employee.component';

export const routes = [
  { path: '', children: [
    { path: '', component: PerformComponent },
    { path: 'employee',  component: EmployeeComponent }
  ]},
];