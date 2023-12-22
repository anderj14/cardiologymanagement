import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SurgeryParams } from '../shared/Models/surgeryParams';
import { Pagination } from '../shared/Models/pagination';
import { Surgery } from '../shared/Models/surgery';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SurgeryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getSurgeries(surgeryParams: SurgeryParams) {
    let params = new HttpParams();

    if (surgeryParams.patientId > 0) params = params.append('patientId', surgeryParams.patientId);
    params = params.append('sort', surgeryParams.sort);
    params = params.append('pageIndex', surgeryParams.pageNumber.toString());
    params = params.append('pageSize', surgeryParams.pageSize.toString());
    if (surgeryParams.search) params = params.append('search', surgeryParams.search);

    return this.http.get<Pagination<Surgery[]>>(`${this.baseUrl}cardiologysurgeries`, { params });
  }

  getSurgery(id: number): Observable<Surgery> {
    return this.http.get<Surgery>(`${this.baseUrl}cardiologysurgeries/${id}`);
  }
}
