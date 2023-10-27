import { Component, OnInit } from '@angular/core';
import { EchocardiogramService } from '../echocardiogram.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';
import { Echocardiogram } from 'src/app/shared/Models/echocardiogram';

@Component({
  selector: 'app-echocardiogram-details',
  templateUrl: './echocardiogram-details.component.html',
  styleUrls: ['./echocardiogram-details.component.scss']
})
export class EchocardiogramDetailsComponent implements OnInit {

  echocardiogram!: Echocardiogram;
  patientId: number | undefined;
  echocardiogramId: number | undefined;
  patientName: string | undefined;

  constructor(
    private echcoardiogramService: EchocardiogramService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }
  ngOnInit(): void {
    this.loadEchocardiogramByPatientId();
  }

  getEchocardiogramByPatientId(patientId: number, echocardiogramId: number) {
    this.echcoardiogramService.getEchocardiogramByPatientId(patientId, echocardiogramId)
      .subscribe(echocardiogram => {
        this.echocardiogram = echocardiogram;
      });
  }

  loadEchocardiogramByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.echocardiogramId = +params['echocardiogramId'];

      if (this.echocardiogramId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if(this.patientId && this.echocardiogramId) {
        this.getEchocardiogramByPatientId(this.patientId, this.echocardiogramId);
      }
    })
  }
}
