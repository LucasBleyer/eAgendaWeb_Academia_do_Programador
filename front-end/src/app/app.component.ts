import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'front-end';

  constructor(titulo: Title){
    titulo.setTitle("Home | eAgenda");
  }
}
