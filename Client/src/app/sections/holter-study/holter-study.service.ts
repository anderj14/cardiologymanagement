import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HolterStudy } from 'src/app/shared/Models/holterStudy';

@Injectable({
  providedIn: 'root'
})
export class HolterStudyService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getHolterStudiesByPatientId(patientId: number): Observable<HolterStudy[]> {
    return this.http.get<HolterStudy[]>(
      `${this.baseUrl}holterstudy/patient/${patientId}/holterstudies`
    );
  }

  getHolterStudyByPatientId(patientId: number, holterStudyId: number): Observable<HolterStudy> {
    return this.http.get<HolterStudy>(
      `${this.baseUrl}holterstudy/patient/${patientId}/holterstudies/${holterStudyId}`
    );
  }

}
