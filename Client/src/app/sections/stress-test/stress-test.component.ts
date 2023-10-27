import { Component, OnInit } from '@angular/core';
import { StressTestService } from './stress-test.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';
import { StressTest } from 'src/app/shared/Models/stressTest';

@Component({
  selector: 'app-stress-test',
  templateUrl: './stress-test.component.html',
  styleUrls: ['./stress-test.component.scss']
})
export class StressTestComponent implements OnInit {

  stressTest!: StressTest[];
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

  getStressTestByPatientId() {
    if (this.patientId) {
      this.stressTestService.getStressTestsByPatientId(this.patientId)
        .subscribe(stressTest => {
          this.stressTest = stressTest
        });
    }
  }

  loadStressTestByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['id'];
    });

    if (this.patientId) {
      this.getStressTestByPatientId();

      this.patientService.getPatient(this.patientId).subscribe(patient => {
        this.patientName = patient.patientName;
      });
    }
  }
}
