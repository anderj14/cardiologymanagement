import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Appointment } from 'src/app/shared/Models/appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  baseUrl = 'https://localhost:5001/api/';


  constructor(private http: HttpClient) { }


  getAppointmentsByPatientId(patientId: number): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.baseUrl}appointment/patient/${patientId}/appointments`);
  }

  getAppointmentByPatientId(patientId: number, appointmentId: number): Observable<Appointment> {
    return this.http.get<Appointment>(`${this.baseUrl}appointment/patient/${patientId}/appointments/${appointmentId}`);
  }

}
