import { Component, OnInit } from '@angular/core';
import { PhysicalExaminationService } from '../physical-examination.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';
import { PhysicalExamination } from 'src/app/shared/Models/physicalExamination';

@Component({
  selector: 'app-physical-examination-details',
  templateUrl: './physical-examination-details.component.html',
  styleUrls: ['./physical-examination-details.component.scss']
})
export class PhysicalExaminationDetailsComponent implements OnInit {


  physicalExamination!: PhysicalExamination;
  physicalExaminationId: number | undefined;
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private physicalExaminationService: PhysicalExaminationService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadPhysicalExaminationByPatientId();
  }

  getPhysicalExaminationByPatientId(patientId: number, phisicalExaminationId: number) {
    this.physicalExaminationService.getPhysicalExaminationByPatientId(patientId, phisicalExaminationId)
      .subscribe(physicalExamination => {
        this.physicalExamination = physicalExamination;
      });
  }

  loadPhysicalExaminationByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.physicalExaminationId = +params['physicalexaminationId'];

      if (this.physicalExaminationId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
      if (this.patientId && this.physicalExaminationId) {
        this.getPhysicalExaminationByPatientId(this.patientId, this.physicalExaminationId);
      }
    });
  }
}
