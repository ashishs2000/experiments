import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { PerformComponent } from './perform.component'
import { routes } from './perform.routes';


@NgModule({
  declarations: [
    PerformComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
})
export class ChildDetailModule {
  public static routes = routes;
}
