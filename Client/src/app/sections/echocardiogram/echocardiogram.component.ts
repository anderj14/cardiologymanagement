import { Component, OnInit } from '@angular/core';
import { Echocardiogram } from 'src/app/shared/Models/echocardiogram';
import { EchocardiogramService } from './echocardiogram.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-echocardiogram',
  templateUrl: './echocardiogram.component.html',
  styleUrls: ['./echocardiogram.component.scss']
})
export class EchocardiogramComponent implements OnInit {

  echocardiogram!: Echocardiogram[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private echocardiogramService: EchocardiogramService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadEchocardiogramsByPatientId();
  }

  getEchocardiogramsByPatientId() {
    if (this.patientId) {
      this.echocardiogramService.getEchocardiogramsByPatientId(this.patientId).subscribe(echocardiogram => {
        this.echocardiogram = echocardiogram;
      });
    }
  }

  loadEchocardiogramsByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];
      if (this.patientId) {
        this.getEchocardiogramsByPatientId();        

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }

}
