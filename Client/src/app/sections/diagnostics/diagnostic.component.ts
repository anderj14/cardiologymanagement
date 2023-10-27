import { Component, OnInit } from '@angular/core';
import { Diagnostic } from 'src/app/shared/Models/diagnostic';
import { DiagnosticService } from './diagnostic.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-diagnostic',
  templateUrl: './diagnostic.component.html',
  styleUrls: ['./diagnostic.component.scss']
})
export class DiagnosticComponent implements OnInit {

  diagnostic!: Diagnostic[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private diagnosticService: DiagnosticService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadDiagnosticsByPatientId();
  }

  getDiagnosticsByPatientId() {
    if (this.patientId) {
      this.diagnosticService.getDiagnosticsByPatientId(this.patientId)
        .subscribe(diagnostic => {
          this.diagnostic = diagnostic;
        });
    }
  }

  loadDiagnosticsByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];

      if (this.patientId) {
        this.getDiagnosticsByPatientId();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }
}
