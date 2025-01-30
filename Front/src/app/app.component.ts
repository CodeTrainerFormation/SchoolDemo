import { Component, OnInit } from '@angular/core';
import { SchoolService } from './school.service';
import { School } from './school';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  
  // title = 'Bonjour tout le monde';
  // items = [
  //   "item1",
  //   "item2",
  //   "item3"
  // ]


  schools: School[] = [];

  constructor(
    private service: SchoolService
  ){}

  ngOnInit(): void {
    this.service.getSchools()
                .subscribe(schools => this.schools = schools);
  }

  addItem(){
    // this.items.push("new item");
  }
}
