import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Appointment } from 'src/app/shared/Models/appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.baseUrl}appointments`);
  }

  getAppointmentsByPatientId(patientId: number): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.baseUrl}appointment/patient/${patientId}/appointments`);
  }

  getAppointmentByPatientId(patientId: number, appointmentId: number): Observable<Appointment> {
    return this.http.get<Appointment>(`${this.baseUrl}appointment/patient/${patientId}/appointments/${appointmentId}`);
  }

}
