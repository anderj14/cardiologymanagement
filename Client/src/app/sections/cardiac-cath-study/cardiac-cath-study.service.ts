import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { CardiacCathStudy } from 'src/app/shared/Models/cardiacCathStudy';

@Injectable({
  providedIn: 'root'
})
export class CardiacCathStudyService {
  
  baseUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getCardiacCathStudiesByPatientId(patientId: number): Observable<CardiacCathStudy[]> {
    return this.http.get<CardiacCathStudy[]>(
      `${this.baseUrl}CardiacCatheterizationStudy/patient/${patientId}/cardiacCathStudies`
    );
  }

  getCardiacCathStudyByPatientId(patientId: number, cardiacCathStudyId: number): Observable<CardiacCathStudy> {
    return this.http.get<CardiacCathStudy>(
      `${this.baseUrl}CardiacCatheterizationStudy/patient/${patientId}/cardiacCathStudies/${cardiacCathStudyId}`
    )
  }

}
