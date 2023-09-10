import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Patient } from './Models/patient';
import { Pagination } from './Models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Client';
  patients!: Patient[];

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get<Pagination<Patient[]>>('https://localhost:5001/api/patients').subscribe({
      next: response => this.patients = response.data,
      error: error => console.log(error),
      complete: () => {
        console.log('request complete');
        console.log('extra statment');
      }      
    });
  }
}
