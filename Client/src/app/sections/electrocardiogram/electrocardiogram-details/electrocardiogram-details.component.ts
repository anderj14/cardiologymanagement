import { Component, OnInit } from '@angular/core';
import { Electrocardiogram } from 'src/app/shared/Models/electrocardiogram';
import { ElectrocardiogramService } from '../electrocardiogram.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-electrocardiogram-details',
  templateUrl: './electrocardiogram-details.component.html',
  styleUrls: ['./electrocardiogram-details.component.scss']
})
export class ElectrocardiogramDetailsComponent implements OnInit {

  electrocardiogram!: Electrocardiogram;
  patientId: number | undefined;
  electrocardiogramId: number | undefined;
  patientName: string | undefined;

  constructor(
    private electrocardiogramService: ElectrocardiogramService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadElectrocardiogramByPatientId();
  }

  getElectrocardiogramByPatientId(patientId: number, electrocardiogramId: number) {
    this.electrocardiogramService.getElectrocardiogramByPatientId(patientId, electrocardiogramId)
      .subscribe(electrocardiogram => {
        this.electrocardiogram = electrocardiogram;
      });
  }

  loadElectrocardiogramByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.electrocardiogramId = +params['electrocardiogramId'];

      if (this.electrocardiogramId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if (this.patientId && this.electrocardiogramId) {
        this.getElectrocardiogramByPatientId(this.patientId, this.electrocardiogramId);
      }
    });
  }
}
