import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@NgModule({
  declarations: [HomeComponent, SidebarComponent],
  exports: [HomeComponent],
  imports: [CommonModule],
})
export class HomeModule {}
