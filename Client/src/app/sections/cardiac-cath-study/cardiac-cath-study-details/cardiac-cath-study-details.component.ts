import { Component, OnInit } from '@angular/core';
import { CardiacCathStudy } from 'src/app/shared/Models/cardiacCathStudy';
import { CardiacCathStudyService } from '../cardiac-cath-study.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-cardiac-cath-study-details',
  templateUrl: './cardiac-cath-study-details.component.html',
  styleUrls: ['./cardiac-cath-study-details.component.scss']
})
export class CardiacCathStudyDetailsComponent implements OnInit{
  cardiacCathStudy!: CardiacCathStudy;

  patientId: number | undefined;
  cardiacCathStudyId: number | undefined;
  patientName: string | undefined;

  constructor(
    private cardiacCathStudyService: CardiacCathStudyService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadCardiacCathStudyByPatientId();
  }

  getCardiacCathStudyByPatientId(patientId: number, cardiacCathStudyId: number) {
    this.cardiacCathStudyService.getCardiacCathStudyByPatientId(patientId, cardiacCathStudyId).subscribe(cardiacCathStudy => {
      this.cardiacCathStudy = cardiacCathStudy;
    });
  }
  
  loadCardiacCathStudyByPatientId() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.cardiacCathStudyId = +params['cardiacCathStudyId'];

      if(this.cardiacCathStudyId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if(this.patientId && this.cardiacCathStudyId) {
        this.getCardiacCathStudyByPatientId(this.patientId, this.cardiacCathStudyId);
      }
    })
  }

}
