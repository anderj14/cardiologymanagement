import { Component, OnInit } from '@angular/core';
import { Diagnostic } from 'src/app/shared/Models/diagnostic';
import { DiagnosticService } from '../diagnostic.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-diagnostic-details',
  templateUrl: './diagnostic-details.component.html',
  styleUrls: ['./diagnostic-details.component.scss']
})
export class DiagnosticDetailsComponent implements OnInit {

  diagnostic!: Diagnostic;
  patientId: number | undefined;
  diagnosticId: number | undefined;
  patientName: string | undefined;

  constructor(
    private diagnosticService: DiagnosticService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }


  ngOnInit(): void {
    this.loadDiagnosticByPatientId();
  }

  getDiagnosticByPatientId(patientId: number, diagnosticId: number) {
    this.diagnosticService.getDiagnosticByPatientId(patientId, diagnosticId)
    .subscribe(diagnostic => {
      this.diagnostic = diagnostic;
    });
  }

  loadDiagnosticByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.diagnosticId = +params['diagnosticId'];

      if (this.diagnosticId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if (this.patientId && this.diagnosticId) {
        this.getDiagnosticByPatientId(this.patientId, this.diagnosticId);
      }
    });
  }

}
