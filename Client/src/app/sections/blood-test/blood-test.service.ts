import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { BloodTest } from 'src/app/shared/Models/bloodTest';

@Injectable({
  providedIn: 'root'
})
export class BloodTestService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getBloodTestsByPatientId(patientId: number): Observable<BloodTest[]> {
    return this.http.get<BloodTest[]>(
      `${this.baseUrl}bloodtest/patient/${patientId}/bloodTests`
    );
  }

  getBloodTestByPatientId(patientId: number, bloodTestId: number): Observable<BloodTest> {
    return this.http.get<BloodTest>(
      `${this.baseUrl}bloodTest/patient/${patientId}/bloodTests/${bloodTestId}`
      );
  }

}
