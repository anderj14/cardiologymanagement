import { Component, OnInit } from '@angular/core';
import { BloodTest } from 'src/app/shared/Models/bloodTest';
import { BloodTestService } from './blood-test.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-blood-test',
  templateUrl: './blood-test.component.html',
  styleUrls: ['./blood-test.component.scss']
})
export class BloodTestComponent implements OnInit {

  bloodTest!: BloodTest[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private bloodTestService: BloodTestService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadBloodTests();
  }

  getBloodTests() {
    if (this.patientId) {
      this.bloodTestService.getBloodTestsByPatientId(this.patientId).subscribe(bloodTest => {
        this.bloodTest = bloodTest;
      });
    }
  }

  loadBloodTests() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];
      if (this.patientId) {
        this.getBloodTests();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        })
      }
    })
  }
}
