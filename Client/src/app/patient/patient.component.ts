
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Patient } from '../shared/Models/patient';
import { PatientService } from './patient.service';
import { PatientParams } from '../shared/Models/patientParams';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})

export class PatientComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;
  patients!: Patient[];

  patientParams = new PatientParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Birth Of Date: Descending', value: 'dobDesc' },
    { name: 'Birth Of Date: Ascending', value: 'dobAsc' },
  ];
  totalCount = 0;


  constructor(
    private patientService: PatientService,
  ) { }

  ngOnInit(): void {
    this.getPatients();
  }

  getPatients() {
    this.patientService.getPatients(this.patientParams).subscribe({
      next: response => {
        this.patients = response.data;
        this.patientParams.pageNumber = response.pageIndex,
          this.patientParams.pageSize = response.pageSize,
          this.totalCount = response.count;
      },
      error: error => console.log(error)
    });
  }

  onSortSelected(event: any) {
    this.patientParams.sort = event.target.value;
    this.getPatients();
  }

  onPageChanged(event: any) {
    if (this.patientParams.pageNumber !== event.page) {
      this.patientParams.pageNumber = event.page;
      this.getPatients();
    }
  }

  onSearch() {
    this.patientParams.search = this.searchTerm?.nativeElement.value;
    this.patientParams.pageNumber = 1;
    this.getPatients();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.patientParams = new PatientParams();
    this.getPatients();
  }

}
