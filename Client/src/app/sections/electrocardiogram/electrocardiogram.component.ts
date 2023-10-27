import { Component, OnInit } from '@angular/core';
import { Electrocardiogram } from 'src/app/shared/Models/electrocardiogram';
import { ElectrocardiogramService } from './electrocardiogram.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-electrocardiogram',
  templateUrl: './electrocardiogram.component.html',
  styleUrls: ['./electrocardiogram.component.scss']
})
export class ElectrocardiogramComponent implements OnInit {

  electrocardiogram!: Electrocardiogram[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private electrocardiogramService: ElectrocardiogramService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadElectrocardiogramByPatientId();
  }

  getElectrocardiogramsByPatientId() {
    if (this.patientId) {
      this.electrocardiogramService.getElectrocardiogramsByPatientId(this.patientId)
        .subscribe(electrocardiogram => {
          this.electrocardiogram = electrocardiogram;
        });
    }
  }

  loadElectrocardiogramByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];

      if (this.patientId) {
        this.getElectrocardiogramsByPatientId();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }

}
