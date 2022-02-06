import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NgxNavbarModule } from 'ngx-bootstrap-navbar';

@NgModule({
  declarations: [NavBarComponent],
  imports: [CommonModule, NgxNavbarModule],
  exports: [NavBarComponent],
})
export class SharedModule {}
