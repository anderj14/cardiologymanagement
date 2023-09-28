import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/shared/Models/patient';
import { PatientService } from '../patient.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.scss']
})
export class PatientDetailsComponent implements OnInit{
  patient?: Patient;

  constructor(private patientService: PatientService, private activateRoute: ActivatedRoute){}

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct(){
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if(id) this.patientService.getPatient(+id).subscribe({
      next: patient => this.patient = patient,
      error: error => console.log(error)
    })
  }
  
  calculateAge(dob: string | undefined): number | undefined {
    if (dob) {
      const today = new Date();
      const birthDate = new Date(dob);
      let age = today.getFullYear() - birthDate.getFullYear();

      const monthDifference = today.getMonth() - birthDate.getMonth();
      if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
        age--;
      }
      return age;
    }
    return undefined;
  }

}
