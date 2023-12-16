import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { MedicalHistory } from 'src/app/shared/Models/medicalHistory';

@Injectable({
  providedIn: 'root'
})
export class MedicalHistoryService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMedicalHistoriesByPatientId(patientId: number): Observable<MedicalHistory[]> {
    return this.http.get<MedicalHistory[]>(
      `${this.baseUrl}medicalhistory/patient/${patientId}/medicalhistories`
    );
  }

  getMedicalHistoryByPatientId(patientId: number, medicalHistoryId: number): Observable<MedicalHistory> {
    return this.http.get<MedicalHistory>(
      `${this.baseUrl}medicalhistory/patient/${patientId}/medicalhistories/${medicalHistoryId}`
    );
  }
}
