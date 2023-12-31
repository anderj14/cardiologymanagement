import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pagination } from '../shared/Models/pagination';
import { IPatient } from '../shared/Models/patient';
import { PatientParams } from '../shared/Models/patientParams';
import { Appointment } from '../shared/Models/appointment';
import { BloodTest } from '../shared/Models/bloodTest';
import { CardiacCathStudy } from '../shared/Models/cardiacCathStudy';
import { Diagnostic } from '../shared/Models/diagnostic';
import { DiseaseHistory } from '../shared/Models/diseaseHistory';
import { Echocardiogram } from '../shared/Models/echocardiogram';
import { Electrocardiogram } from '../shared/Models/electrocardiogram';
import { HolterStudy } from '../shared/Models/holterStudy';
import { MedicalHistory } from '../shared/Models/medicalHistory';
import { PhysicalExamination } from '../shared/Models/physicalExamination';
import { StressTest } from '../shared/Models/stressTest';
import { Treatment } from '../shared/Models/treatment';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  baseUrl = environment.apiUrl;
  patientParams = new PatientParams();

  constructor(private http: HttpClient) { }

  getPatients(patientParams: PatientParams): Observable<Pagination<IPatient[]>> {
    let params = new HttpParams();

    params = params.append('sort', patientParams.sort);
    params = params.append('pageIndex', patientParams.pageNumber.toString());
    params = params.append('pageSize', patientParams.pageSize.toString());
    if (patientParams.search) params = params.append('search', patientParams.search);

    return this.http.get<Pagination<IPatient[]>>(this.baseUrl + 'patients', { params });
  }

  setPatientParams(params: PatientParams) {
    this.patientParams = params;
  }

  getPatientParams() {
    return this.patientParams;
  }

  getPatient(id: number): Observable<IPatient> {
    return this.http.get<IPatient>(this.baseUrl + 'patients/' + id);
  }

  getAppointmentByPatientId(patientId: number): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(this.baseUrl + 'appointment/patient/' + patientId + '/appointments');
  }

  getBloodTestByPatientId(patientId: number): Observable<BloodTest[]> {
    return this.http.get<BloodTest[]>(this.baseUrl + 'bloodtest/patient/' + patientId + '/bloodtests');
  }

  getCardiacCathStudyByPatientId(patientId: number): Observable<CardiacCathStudy[]> {
    return this.http.get<CardiacCathStudy[]>(this.baseUrl + 'CardiacCatheterizationStudy/patient/' + patientId + '/cardiaccathstudies')
  }

  getDiagnosticByPatientId(patientId: number): Observable<Diagnostic[]> {
    return this.http.get<Diagnostic[]>(this.baseUrl + 'diagnostic/patient/' + patientId + '/diagnostics');
  }

  getDiseaseHistoryByPatientId(patientId: number): Observable<DiseaseHistory[]> {
    return this.http.get<DiseaseHistory[]>(this.baseUrl + 'DiseaseHistory/patient/' + patientId + '/diseasesHistories');
  }

  getEchocardiogramByPatientId(patientId: number): Observable<Echocardiogram[]> {
    return this.http.get<Echocardiogram[]>(this.baseUrl + 'echocardiogram/patient/' + patientId + '/echocardiograms');
  }

  getElectrocardiogramByPatientId(patientId: number): Observable<Electrocardiogram[]> {
    return this.http.get<Electrocardiogram[]>(this.baseUrl + 'electrocardiogram/patient/' + patientId + '/electrocardiograms');
  }

  getHolterStudyByPatientId(patientId: number): Observable<HolterStudy[]> {
    return this.http.get<HolterStudy[]>(this.baseUrl + 'holterstudy/patient/' + patientId + '/holterstudies');
  }

  getMedicalHistoryByPatientId(patientId: number): Observable<MedicalHistory[]> {
    return this.http.get<MedicalHistory[]>(this.baseUrl + 'medicalhistory/patient/' + patientId + '/medicalhistories');
  }

  getPhysicalExaminationByPatientId(patientId: number): Observable<PhysicalExamination[]> {
    return this.http.get<PhysicalExamination[]>(this.baseUrl + 'physicalexamination/patient/' + patientId + '/physicalexaminations');
  }

  getStressTestByPatientId(patientId: number): Observable<StressTest[]> {
    return this.http.get<StressTest[]>(this.baseUrl + 'stresstest/patient/' + patientId + '/stresstests');
  }

  getTreatmentByPatientId(patientId: number): Observable<Treatment[]> {
    return this.http.get<Treatment[]>(this.baseUrl + 'treatment/patient/' + patientId + '/treatments');
  }
}
