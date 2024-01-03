import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientFormValues } from 'src/app/shared/Models/patient';
import { AdminPatientService } from '../admin-patient.service';

@Component({
  selector: 'app-edit-patient-form',
  templateUrl: './edit-patient-form.component.html',
  styleUrls: ['./edit-patient-form.component.scss']
})
export class EditPatientFormComponent implements OnInit{
  @Input() patient!: PatientFormValues;

  constructor(
    private route: ActivatedRoute,
    private adminPatientService: AdminPatientService,
    private router: Router
  ) {}

  ngOnInit(): void {
    
  }

  onSubmit(patient: PatientFormValues) {
    const id = this.route.snapshot.paramMap.get('id');
    if (this.route.snapshot.url[0].path === 'edit') {
      const updatePatient = { ...this.patient, patient };
      this.adminPatientService.updatePatient(updatePatient, +id!).subscribe((response: any) => {
        this.router.navigate(['/patients']);
      });
    } else {
      const newPatient = { ...patient };
      this.adminPatientService.createPatient(newPatient).subscribe((response: any) => {
        this.router.navigate(['/patients']);
      });
    }
  }
}
