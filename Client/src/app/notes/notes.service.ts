import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { NoteParams } from '../shared/Models/noteParams';
import { Pagination } from '../shared/Models/pagination';
import { Note } from '../shared/Models/note';
import { NoteStatus } from '../shared/Models/noteStatus';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient
  ) { }

  getNotes(noteParams: NoteParams) {
    let params = new HttpParams();

    if (noteParams.noteStatusId > 0) params = params.append('noteStatusId', noteParams.noteStatusId);
    params = params.append('sort', noteParams.sort);
    params = params.append('pageIndex', noteParams.pageNumber.toString());
    params = params.append('pageSize', noteParams.pageSize.toString());
    if (noteParams.search) params = params.append('search', noteParams.search);

    return this.http.get<Pagination<Note[]>>(`${this.baseUrl}notes`, { params });
  }

  getNote(id: number) {
    return this.http.get<Note>(`${this.baseUrl}notes/${id}`);
  }

  getNoteStatus() {
    return this.http.get<NoteStatus[]>(`${this.baseUrl}notestatuses`);
  }
}
