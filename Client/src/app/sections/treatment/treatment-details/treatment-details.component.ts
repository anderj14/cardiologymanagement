import { Component, OnInit } from '@angular/core';
import { Treatment } from 'src/app/shared/Models/treatment';
import { TreatmentService } from '../treatment.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-treatment-details',
  templateUrl: './treatment-details.component.html',
  styleUrls: ['./treatment-details.component.scss']
})
export class TreatmentDetailsComponent implements OnInit {

  treatment!: Treatment;
  treatmentId: number | undefined;
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

  getTreatmentByPatientId(patientId: number, treatmentId: number) {
    this.treatmentService.getTreatmentByPatientId(patientId, treatmentId)
      .subscribe(treatment => {
        this.treatment = treatment;
      });
  }

  loadTreatmentByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.treatmentId = +params['treatmentId'];

      if (this.patientId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if (this.patientId && this.treatmentId) {
        this.getTreatmentByPatientId(this.patientId, this.treatmentId);
      }
    });
  }

}
