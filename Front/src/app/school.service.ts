import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { School } from './school';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  private apiUrl = 'https://schoolapi2025.azurewebsites.net/api';

  constructor(
    private http: HttpClient
  ){}

  getSchools(): Observable<School[]>{
    return this.http.get<School[]>(`${this.apiUrl}/school`);
  }

  getSchool(id: number): Observable<School>{
    return this.http.get<School>(`${this.apiUrl}/school/${id}`);
  }

  addSchool(school: School): Observable<School>{
    return this.http.post<School>(`${this.apiUrl}/school/`, school);
  }

  updateSchool(school: School): Observable<any>{
    return this.http.put<School>(`${this.apiUrl}/school/${school.schoolID}`, school);
  }

  deleteSchool(id: number): Observable<School>{
    return this.http.delete<School>(`${this.apiUrl}/school/${id}`);
  }

}
