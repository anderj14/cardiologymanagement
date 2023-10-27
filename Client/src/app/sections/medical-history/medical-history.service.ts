import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MedicalHistory } from 'src/app/shared/Models/medicalHistory';

@Injectable({
  providedIn: 'root'
})
export class MedicalHistoryService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  // https://localhost:5001/api/MedicalHistory/patient/1/medicalHistories
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
