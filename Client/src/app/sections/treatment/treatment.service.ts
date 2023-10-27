import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Treatment } from 'src/app/shared/Models/treatment';

@Injectable({
  providedIn: 'root'
})
export class TreatmentService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getTreatmentsByPatientId(patientId: number): Observable<Treatment[]> {
    return this.http.get<Treatment[]>(
      `${this.baseUrl}treatment/patient/${patientId}/treatments`
    );
  }

  getTreatmentByPatientId(patientId: number, treatmentId: number): Observable<Treatment> {
    return this.http.get<Treatment>(
      `${this.baseUrl}treatment/patient/${patientId}/treatments/${treatmentId}`
    );
  }
}
