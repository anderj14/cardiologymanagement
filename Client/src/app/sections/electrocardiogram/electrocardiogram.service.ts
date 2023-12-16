import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Electrocardiogram } from 'src/app/shared/Models/electrocardiogram';

@Injectable({
  providedIn: 'root'
})
export class ElectrocardiogramService {

  baseUrl = environment.apiUrl;

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
