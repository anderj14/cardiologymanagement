import { Component, OnInit } from '@angular/core';
import { HolterStudy } from 'src/app/shared/Models/holterStudy';
import { HolterStudyService } from '../holter-study.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-holter-study-details',
  templateUrl: './holter-study-details.component.html',
  styleUrls: ['./holter-study-details.component.scss']
})
export class HolterStudyDetailsComponent implements OnInit {

  holterStudy!: HolterStudy;
  patientId: number | undefined;
  holterStudyId: number | undefined;
  patientName: string | undefined;

  constructor(
    private holterStudyService: HolterStudyService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadHolterStudyByPatientId();
  }

  getHolterStudyByPatientId(patientId: number, holterStudyId: number) {
    this.holterStudyService.getHolterStudyByPatientId(patientId, holterStudyId)
      .subscribe(holterStudy => {
        this.holterStudy = holterStudy;
      });
  }


  loadHolterStudyByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.holterStudyId = +params['holterstudyId'];

      if (this.holterStudyId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
      if (this.patientId && this.holterStudyId) {
        this.getHolterStudyByPatientId(this.patientId, this.holterStudyId);
      }
    });
  }

}
