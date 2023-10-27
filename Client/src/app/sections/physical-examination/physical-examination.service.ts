import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PhysicalExamination } from 'src/app/shared/Models/physicalExamination';

@Injectable({
  providedIn: 'root'
})
export class PhysicalExaminationService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getPhysicalExaminationsByPatientId(patientId: number): Observable<PhysicalExamination[]> {
    return this.http.get<PhysicalExamination[]>(
      `${this.baseUrl}physicalexamination/patient/${patientId}/physicalexaminations`
    );
  }

  getPhysicalExaminationByPatientId(patientId: number, physicalExaminationId: number): Observable<PhysicalExamination> {
    return this.http.get<PhysicalExamination>(
      `${this.baseUrl}physicalexamination/patient/${patientId}/physicalexaminations/${physicalExaminationId}`
    );
  }

}
