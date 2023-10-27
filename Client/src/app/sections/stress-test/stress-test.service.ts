import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StressTest } from 'src/app/shared/Models/stressTest';

@Injectable({
  providedIn: 'root'
})
export class StressTestService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getStressTestsByPatientId(patientId: number): Observable<StressTest[]> {
    return this.http.get<StressTest[]>(
      `${this.baseUrl}stresstest/patient/${patientId}/stresstests`
    );
  }

  loadStressTestByPatientId(patientId: number, stressTestId: number): Observable<StressTest> {
    return this.http.get<StressTest>(
      `${this.baseUrl}stresstest/patient/${patientId}/stresstests/${stressTestId}`
    );
  }
}
