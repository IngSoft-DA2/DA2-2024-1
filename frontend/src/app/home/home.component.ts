import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ImportersService } from '../services/importers.service';

interface Items {
  name: string;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, SidebarComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  constructor(
    private _importerService: ImportersService,
  ) {}

  items: Items[] = [
    { name: 'Item 1' },
    { name: 'Item 2' },
    { name: 'Item 3' },
    { name: 'Item 4' },
    { name: 'Item 5' },
  ];
  test: string = 'test string';

  getImporters() {
    this._importerService.getImporters().subscribe((response) => {
      console.log('response', response);
    })
  }
}
