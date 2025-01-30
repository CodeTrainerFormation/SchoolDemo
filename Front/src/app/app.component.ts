import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Bonjour tout le monde';

  items = [
    "item1",
    "item2",
    "item3"
  ]

  addItem(){
    this.items.push("new item");
  }
}
