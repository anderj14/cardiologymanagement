import { Component, OnInit } from '@angular/core';
import { DiseaseHistory } from 'src/app/shared/Models/diseaseHistory';
import { DiseaseHistoryService } from '../disease-history.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-disease-history-details',
  templateUrl: './disease-history-details.component.html',
  styleUrls: ['./disease-history-details.component.scss']
})
export class DiseaseHistoryDetailsComponent implements OnInit {
  diseaseHistory!: DiseaseHistory;

  patientId: number | undefined;
  diseaseHistoryId: number | undefined;
  patientName: string | undefined;

  constructor(
    private diseaseHistoryService: DiseaseHistoryService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadDiseaseHistoryByPatientId();
  }

  getDiseaseHistoryByPatientId(patientId: number, diseaseHistoryId: number) {
    this.diseaseHistoryService.getDiseaseHistoryByPatientId(patientId, diseaseHistoryId)
      .subscribe(diseaseHistory => {
        this.diseaseHistory = diseaseHistory;
      });
  }

  loadDiseaseHistoryByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.diseaseHistoryId = +params['diseasehistoryId'];

      if (this.patientId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if (this.patientId && this.diseaseHistoryId) {
        this.getDiseaseHistoryByPatientId(this.patientId, this.diseaseHistoryId);
      }
    });
  }

}
