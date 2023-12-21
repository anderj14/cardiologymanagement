import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Appointment } from 'src/app/shared/Models/appointment';
import { AppointmentParams } from 'src/app/shared/Models/appointmentParams';
import { AppointmentStatus } from 'src/app/shared/Models/appointmentStatus';
import { Pagination } from 'src/app/shared/Models/pagination';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAppointments(appointmentParams: AppointmentParams) {
    let params = new HttpParams();

    if (appointmentParams.appointmentStatusId > 0) params = params.append('appointmentStatusId', appointmentParams.appointmentStatusId);
    params = params.append('sort', appointmentParams.sort);
    params = params.append('pageIndex', appointmentParams.pageNumber.toString());
    params = params.append('pageSize', appointmentParams.pageSize.toString());
    if(appointmentParams.search) params = params.append('search', appointmentParams.search);
    if(appointmentParams.date) params = params.append('date', appointmentParams.date);

    return this.http.get<Pagination<Appointment[]>>(`${this.baseUrl}appointment`, {params});
  }

  getAppointment(id: number): Observable<Appointment> {
    return this.http.get<Appointment>(`${this.baseUrl}appointment/${id}`);
  }

  getAppointmentsByPatientId(patientId: number): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.baseUrl}appointment/patient/${patientId}/appointments`);
  }

  getAppointmentByPatientId(patientId: number, appointmentId: number): Observable<Appointment> {
    return this.http.get<Appointment>(`${this.baseUrl}appointment/patient/${patientId}/appointments/${appointmentId}`);
  }

  getAppointmentStatus()
  {
    return this.http.get<AppointmentStatus[]>(`${this.baseUrl}appointmentStatuses`)
  }

}
