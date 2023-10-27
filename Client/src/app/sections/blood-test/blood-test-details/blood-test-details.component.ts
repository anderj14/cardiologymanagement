import { Component, OnInit } from '@angular/core';
import { BloodTestService } from '../blood-test.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';
import { BloodTest } from 'src/app/shared/Models/bloodTest';

@Component({
  selector: 'app-blood-test-details',
  templateUrl: './blood-test-details.component.html',
  styleUrls: ['./blood-test-details.component.scss']
})
export class BloodTestDetailsComponent implements OnInit {
  bloodTest: BloodTest | undefined;

  patientId: number | undefined;
  bloodTestId: number | undefined;
  patientName: string | undefined;

  constructor(
    private bloodTestService: BloodTestService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadBloodTestByPatientId();
  }

  getBloodTestByPatientId(patientId: number, bloodTestId: number) {
    this.bloodTestService.getBloodTestByPatientId(patientId, bloodTestId).subscribe(bloodTest => {
      this.bloodTest = bloodTest;
    })
  }
  
  loadBloodTestByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.bloodTestId = +params['bloodTestId'];

      if (this.bloodTestId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if (this.patientId && this.bloodTestId) {
        this.getBloodTestByPatientId(this.patientId, this.bloodTestId);
      }
    });
  }



}
