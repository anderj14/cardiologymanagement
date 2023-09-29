import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DiseaseHistory } from 'src/app/shared/Models/diseaseHistory';

@Injectable({
  providedIn: 'root'
})
export class DiseaseHistoryService {

  private baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getDiseaseHistories(patientId: number): Observable<DiseaseHistory[]>{
    return this.http.get<DiseaseHistory[]>(this.baseUrl + 'patients/patientId/diseaseHistory');
  }
}