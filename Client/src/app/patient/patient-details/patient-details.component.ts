import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/shared/Models/patient';
import { PatientService } from '../patient.service';
import { ActivatedRoute } from '@angular/router';
import { DiseaseHistory } from 'src/app/shared/Models/diseaseHistory';
import { DiseaseHistoryService } from 'src/app/sections/disease-history/disease-history.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.scss']
})
export class PatientDetailsComponent implements OnInit{
  patient?: Patient;
  diseaseHistories: DiseaseHistory[] | undefined;

  constructor(
    private patientService: PatientService, 
    private activateRoute: ActivatedRoute,
    private diseaseHistoryService: DiseaseHistoryService
    ){}

  ngOnInit(): void {
    this.loadProduct();
    this.loadDiseaseHistories(this.patient?.id || 0);

  }

  loadProduct(){
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if(id) this.patientService.getPatient(+id).subscribe({
      next: patient => this.patient = patient,
      error: error => console.log(error)
    })
  }

  loadDiseaseHistories(patientId: number) {
    this.diseaseHistoryService.getDiseaseHistories(patientId).subscribe({
      next: (histories) => {
        this.diseaseHistories = histories;
      },
      error: (error) => {
        console.log(error);
      },
    });
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
