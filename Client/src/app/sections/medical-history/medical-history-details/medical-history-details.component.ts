import { Component, OnInit } from '@angular/core';
import { MedicalHistoryService } from '../medical-history.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';
import { MedicalHistory } from 'src/app/shared/Models/medicalHistory';

@Component({
  selector: 'app-medical-history-details',
  templateUrl: './medical-history-details.component.html',
  styleUrls: ['./medical-history-details.component.scss']
})
export class MedicalHistoryDetailsComponent implements OnInit {

  medicalHistory!: MedicalHistory;
  patientId: number | undefined;
  medicalHistoryId: number | undefined;
  patientName: string | undefined;

  constructor(
    private medicalHistoryService: MedicalHistoryService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadMedicalHistoryByPatientId();
  }

  getMedicalHistoryByPatientId(patientId: number, medicalHistoryId: number) {
    this.medicalHistoryService.getMedicalHistoryByPatientId(patientId, medicalHistoryId)
      .subscribe(medicalHistory => {
        this.medicalHistory = medicalHistory;
      });
  }

  loadMedicalHistoryByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.medicalHistoryId = +params['medicalhistoryId'];

      if (this.medicalHistoryId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
      if (this.patientId && this.medicalHistoryId) {
        this.getMedicalHistoryByPatientId(this.patientId, this.medicalHistoryId);
      }
    });
  }
}
