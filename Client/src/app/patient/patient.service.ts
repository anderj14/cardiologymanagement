import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Patient } from '../shared/Models/patient';
import { Pagination } from '../shared/Models/pagination';
import { PatientParams } from '../shared/Models/patientParams';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getPatients(patientParams: PatientParams) {
    let params = new HttpParams();

    params = params.append('sort', patientParams.sort);
    params = params.append('pageIndex', patientParams.pageNumber);
    params = params.append('pageSize', patientParams.pageSize);
    if (patientParams.search) params = params.append('search', patientParams.search);

    return this.http.get<Pagination<Patient[]>>(this.baseUrl + 'patients?pageSize=3', { params });
  }

  getPatient(id: number){
    return this.http.get<Patient>(this.baseUrl + 'patients/' + id);
  }
}
