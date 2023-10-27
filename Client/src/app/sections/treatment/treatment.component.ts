import { Component, OnInit } from '@angular/core';
import { Treatment } from 'src/app/shared/Models/treatment';
import { TreatmentService } from './treatment.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-treatment',
  templateUrl: './treatment.component.html',
  styleUrls: ['./treatment.component.scss']
})
export class TreatmentComponent implements OnInit {

  treatment!: Treatment[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private treatmentService: TreatmentService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadTreatmentByPatientId();
  }

  getTreatmentsByPatientId() {
    if (this.patientId) {
      this.treatmentService.getTreatmentsByPatientId(this.patientId)
        .subscribe(treatment => {
          this.treatment = treatment;
        });
    }
  }

  loadTreatmentByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];
    });

    if (this.patientId) {
      this.getTreatmentsByPatientId();

      this.patientService.getPatient(this.patientId).subscribe(patient => {
        this.patientName = patient.patientName;
      });
    }
  }
}
