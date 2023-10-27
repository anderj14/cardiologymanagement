import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Diagnostic } from 'src/app/shared/Models/diagnostic';

@Injectable({
  providedIn: 'root'
})
export class DiagnosticService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  // 'https://localhost:5001/api/Diagnostic/patient/1/diagnostics' \
  getDiagnosticsByPatientId(patientId: number): Observable<Diagnostic[]> {
    return this.http.get<Diagnostic[]>(
      `${this.baseUrl}diagnostic/patient/${patientId}/diagnostics`
    );
  }

  getDiagnosticByPatientId(patientId: number, diagnosticId: number): Observable<Diagnostic> {
    return this.http.get<Diagnostic>(
      `${this.baseUrl}diagnostic/patient/${patientId}/diagnostics/${diagnosticId}`
    );
  }
}

