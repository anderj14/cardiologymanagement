import { Component, OnInit } from '@angular/core';
import { HolterStudy } from 'src/app/shared/Models/holterStudy';
import { HolterStudyService } from './holter-study.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-holter-study',
  templateUrl: './holter-study.component.html',
  styleUrls: ['./holter-study.component.scss']
})
export class HolterStudyComponent implements OnInit {

  holterStudy!: HolterStudy[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private holterStudyService: HolterStudyService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadHolterStudiesByPatientId()
  }

  getHolterStudiesByPatientId() {
    if (this.patientId) {
      this.holterStudyService.getHolterStudiesByPatientId(this.patientId)
        .subscribe(holterStudy => {
          this.holterStudy = holterStudy;
        });
    }
  }

  loadHolterStudiesByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];

      if (this.patientId) {
        this.getHolterStudiesByPatientId();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }
}
