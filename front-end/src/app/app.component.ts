import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  template : `
    <app-navbar></app-navbar>
  `
})
export class AppComponent {

  constructor(titulo: Title){
    titulo.setTitle("Home | eAgenda");
  }
}
