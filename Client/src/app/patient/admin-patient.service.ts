import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/app/environments/environment';
import { PatientFormValues } from 'src/app/shared/Models/patient';

@Injectable({
  providedIn: 'root'
})
export class AdminPatientService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createPatient(patient: PatientFormValues) {
    return this.http.post(this.baseUrl + 'patients', patient);
  }

  updatePatient(patient: PatientFormValues, id: number) {
    return this.http.put(this.baseUrl + 'patients/' + id, patient);
  }

  deletePatient(id: number) {
    return this.http.delete(this.baseUrl + 'patients/' + id);
  }
}
