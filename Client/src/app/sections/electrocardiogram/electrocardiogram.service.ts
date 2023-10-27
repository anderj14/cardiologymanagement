import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Electrocardiogram } from 'src/app/shared/Models/electrocardiogram';

@Injectable({
  providedIn: 'root'
})
export class ElectrocardiogramService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getElectrocardiogramsByPatientId(patientId: number): Observable<Electrocardiogram[]> {
    return this.http.get<Electrocardiogram[]>(
      `${this.baseUrl}electrocardiogram/patient/${patientId}/electrocardiograms`
    );
  }

  getElectrocardiogramByPatientId(patientId: number, electrocardiogramId: number): Observable<Electrocardiogram> {
    return this.http.get<Electrocardiogram>(
      `${this.baseUrl}electrocardiogram/patient/${patientId}/electrocardiograms/${electrocardiogramId}`
    );
  }
}
