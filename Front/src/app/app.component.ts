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

  currentSchool: School = { name: "unknown", schoolID: 0 }

  constructor(
    private service: SchoolService
  ){}

  ngOnInit(): void {
    this.getSchools();
  }

  private getSchools(){
    // all schools
    this.service.getSchools()
                .subscribe(schools => this.schools = schools);

    // school with id 1
    this.service.getSchool(1) // id = 1
                .subscribe(school => this.currentSchool = school);
  }

  addNewSchool(){
    let school: School = {
      name: "Hexagone Cannes"
    };

    this.service.addSchool(school).subscribe(() => this.getSchools());
  }

  updateSchool1(){
    let school: School = {
      schoolID: 1,
      name: "Hexagone Clermont Turing22"
    };

    this.service.updateSchool(school).subscribe(() => this.getSchools());
  }

  removeSchool3(){
    this.service.deleteSchool(3).subscribe(() => this.getSchools());
  }
}
