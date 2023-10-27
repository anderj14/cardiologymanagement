import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Echocardiogram } from 'src/app/shared/Models/echocardiogram';

@Injectable({
  providedIn: 'root'
})
export class EchocardiogramService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getEchocardiogramsByPatientId(patientId: number): Observable<Echocardiogram[]> {
    return this.http.get<Echocardiogram[]>(`${this.baseUrl}echocardiogram/patient/${patientId}/echocardiograms`);
  }
  // https://localhost:5001/api/Echocardiogram/patient/1/echocardiogram/1
  // [HttpGet("patient/{patientId}/echocardiograms/{echocardiogramId}")]


  getEchocardiogramByPatientId(patientId: number, echocardiogramId: number): Observable<Echocardiogram> {
    return this.http.get<Echocardiogram>(
      `${this.baseUrl}echocardiogram/patient/${patientId}/echocardiograms/${echocardiogramId}`
      );
  }

}
