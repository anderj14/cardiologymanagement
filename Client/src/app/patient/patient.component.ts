import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Patient } from '../shared/Models/patient';
import { PatientService } from './patient.service';
import { PatientParams } from '../shared/Models/patientParams';
import { ActivatedRoute } from '@angular/router';
import { DiseaseHistoryService } from '../sections/disease-history/disease-history.service';
import { DiseaseHistory } from '../shared/Models/diseaseHistory';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})

export class PatientComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;
  patients!: Patient[];
  patient: Patient | null = null;

  diseaseHistories !: DiseaseHistory[];
  patientParams = new PatientParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Birth Of Date: Descending', value: 'dobDesc' },
    { name: 'Birth Of Date: Ascending', value: 'dobAsc' },
  ];
  totalCount = 0;


  constructor(
    private patientService: PatientService,
    private route: ActivatedRoute,
    private diseaseHistoryService: DiseaseHistoryService
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

  getDiseaseHistories(){
    this.route.paramMap.subscribe((params) => {
      const patientId = parseInt(params.get('id') || '0', 10);

      if (patientId) {
        // Obtener datos del paciente
        this.patientService.getPatient(patientId).subscribe((patient) => {
          this.patient =patient
        });

        this.diseaseHistoryService.getDiseaseHistories(patientId).subscribe((histories) => {
          this.diseaseHistories = histories;
        })
      }
    })
  }

}
