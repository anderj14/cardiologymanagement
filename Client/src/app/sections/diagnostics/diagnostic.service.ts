import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Diagnostic } from 'src/app/shared/Models/diagnostic';

@Injectable({
  providedIn: 'root'
})
export class DiagnosticService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

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

