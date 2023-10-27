import { Component, OnInit } from '@angular/core';
import { MedicalHistory } from 'src/app/shared/Models/medicalHistory';
import { MedicalHistoryService } from './medical-history.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-medical-history',
  templateUrl: './medical-history.component.html',
  styleUrls: ['./medical-history.component.scss']
})
export class MedicalHistoryComponent implements OnInit {

  medicalhistory!: MedicalHistory[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private medicalHistoryService: MedicalHistoryService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadMedicalHistoriesByPatientId();
  }

  getMedicalHistoriesByPatientId() {
    if (this.patientId) {
      this.medicalHistoryService.getMedicalHistoriesByPatientId(this.patientId)
        .subscribe(medicalhistory => {
          this.medicalhistory = medicalhistory;
        });
    }
  }

  loadMedicalHistoriesByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];

      if (this.patientId) {
        this.getMedicalHistoriesByPatientId();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }
}
