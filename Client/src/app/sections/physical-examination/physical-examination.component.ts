import { Component, OnInit } from '@angular/core';
import { PhysicalExaminationService } from './physical-examination.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';
import { PhysicalExamination } from 'src/app/shared/Models/physicalExamination';

@Component({
  selector: 'app-physical-examination',
  templateUrl: './physical-examination.component.html',
  styleUrls: ['./physical-examination.component.scss']
})
export class PhysicalExaminationComponent implements OnInit {

  physicalExamination!: PhysicalExamination[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private physicalExaminationService: PhysicalExaminationService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadPhysicalExaminationsByPatientId();
  }

  getPhysicalExaminationsByPatientId() {
    if (this.patientId) {
      this.physicalExaminationService.getPhysicalExaminationsByPatientId(this.patientId)
        .subscribe(physicalExamination => {
          this.physicalExamination = physicalExamination;
        });
    }
  }

  loadPhysicalExaminationsByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];

      if (this.patientId) {
        this.getPhysicalExaminationsByPatientId();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }

}
