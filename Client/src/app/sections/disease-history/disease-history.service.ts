import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { DiseaseHistory } from 'src/app/shared/Models/diseaseHistory';

@Injectable({
  providedIn: 'root'
})
export class DiseaseHistoryService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDiseasesHistoryByPatientId(patientId: number): Observable<DiseaseHistory[]> {
    return this.http.get<DiseaseHistory[]>(
      `${this.baseUrl}diseasehistory/patient/${patientId}/diseaseshistories`
    );
  }

  getDiseaseHistoryByPatientId(patientId: number, diseaseHistoryId: number): Observable<DiseaseHistory> {
    return this.http.get<DiseaseHistory>(
      `${this.baseUrl}diseasehistory/patient/${patientId}/diseaseshistories/${diseaseHistoryId}`
    );
  }
}
