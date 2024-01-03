import { Component, OnInit } from '@angular/core';
import { IPatient, PatientFormValues } from 'src/app/shared/Models/patient';
import { PatientService } from '../patient.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminPatientService } from '../admin-patient.service';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.scss']
})
export class EditPatientComponent implements OnInit {

  patient!: IPatient;
  patientFormValues!: PatientFormValues;

  constructor(
    private adminPatientService: AdminPatientService,
    private patientService: PatientService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.patientFormValues = new PatientFormValues();
  }

  ngOnInit(): void {
    if (this.route.snapshot.url[0].path == 'edit') {
      this.loadPatient();
    }
  }

  loadPatient() {
    const id = this.route.snapshot.paramMap.get('id');
    this.patientService.getPatient(+id!).subscribe((response: any) => {
      this.patient = response;
      this.patientFormValues = { ...response };
      console.log(response);

    });
  }
}
