import { Component, OnInit } from '@angular/core';
import { DiseaseHistory } from 'src/app/shared/Models/diseaseHistory';
import { DiseaseHistoryService } from './disease-history.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-disease-history',
  templateUrl: './disease-history.component.html',
  styleUrls: ['./disease-history.component.scss']
})
export class DiseaseHistoryComponent implements OnInit {

  diseaseHistory!: DiseaseHistory[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private diseaseHistoryService: DiseaseHistoryService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadDiseasesHistory();
  }

  loadDiseasesHistory() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];
      if (this.patientId) {
        this.getDiseasesHistory();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }

  getDiseasesHistory() {
    if (this.patientId) {
      this.diseaseHistoryService.getDiseasesHistoryByPatientId(this.patientId)
        .subscribe(diseaseHistory => {
          this.diseaseHistory = diseaseHistory;
        });
    }
  }

}
