import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/patient/patient.service';
import { StressTestService } from '../stress-test.service';
import { ActivatedRoute } from '@angular/router';
import { StressTest } from 'src/app/shared/Models/stressTest';

@Component({
  selector: 'app-stress-test-details',
  templateUrl: './stress-test-details.component.html',
  styleUrls: ['./stress-test-details.component.scss']
})
export class StressTestDetailsComponent implements OnInit {

  stressTest!: StressTest;
  stressTestId: number | undefined;
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private stressTestService: StressTestService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadStressTestByPatientId();
  }

  getStressTestByPatientId(patientId: number, stressTestId: number) {
    this.stressTestService.loadStressTestByPatientId(patientId, stressTestId)
      .subscribe(stressTest => {
        this.stressTest = stressTest;
      });
  }

  loadStressTestByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.stressTestId = +params['stresstestId'];

      if (this.patientId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName
        });
      }
      if (this.patientId, this.stressTestId) {
        this.getStressTestByPatientId(this.patientId, this.stressTestId);
      }
    });
  }

}
