import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Echocardiogram } from 'src/app/shared/Models/echocardiogram';

@Injectable({
  providedIn: 'root'
})
export class EchocardiogramService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getEchocardiogramsByPatientId(patientId: number): Observable<Echocardiogram[]> {
    return this.http.get<Echocardiogram[]>(`${this.baseUrl}echocardiogram/patient/${patientId}/echocardiograms`);
  }

  getEchocardiogramByPatientId(patientId: number, echocardiogramId: number): Observable<Echocardiogram> {
    return this.http.get<Echocardiogram>(
      `${this.baseUrl}echocardiogram/patient/${patientId}/echocardiograms/${echocardiogramId}`
      );
  }

}
