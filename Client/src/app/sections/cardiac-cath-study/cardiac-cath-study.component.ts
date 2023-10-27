import { Component, OnInit } from '@angular/core';
import { CardiacCathStudy } from 'src/app/shared/Models/cardiacCathStudy';
import { CardiacCathStudyService } from './cardiac-cath-study.service';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-cardiac-cath-study',
  templateUrl: './cardiac-cath-study.component.html',
  styleUrls: ['./cardiac-cath-study.component.scss']
})
export class CardiacCathStudyComponent implements OnInit {

  cardiacCathStudy!: CardiacCathStudy[];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private cardiacCathStudyService: CardiacCathStudyService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadCardiacCathStudies();
  }

  getCardiacCathStudies() {
    if (this.patientId) {
      this.cardiacCathStudyService.getCardiacCathStudiesByPatientId(this.patientId).subscribe(cardiacCathStudy => {
        this.cardiacCathStudy = cardiacCathStudy;
      });
    }
  }

  loadCardiacCathStudies() {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];
      if (this.patientId) {
        this.getCardiacCathStudies();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }

}
