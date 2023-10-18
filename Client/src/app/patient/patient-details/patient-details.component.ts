import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/shared/Models/patient';
import { PatientService } from '../patient.service';
import { ActivatedRoute } from '@angular/router';
import { DiseaseHistory } from 'src/app/shared/Models/diseaseHistory';
import { Appointment } from 'src/app/shared/Models/appointment';
import { BloodTest } from 'src/app/shared/Models/bloodTest';
import { CardiacCathStudy } from 'src/app/shared/Models/cardiacCathStudy';
import { Diagnostic } from 'src/app/shared/Models/diagnostic';
import { Echocardiogram } from 'src/app/shared/Models/echocardiogram';
import { Electrocardiogram } from 'src/app/shared/Models/electrocardiogram';
import { HolterStudy } from 'src/app/shared/Models/holterStudy';
import { MedicalHistory } from 'src/app/shared/Models/medicalHistory';
import { PhysicalExamination } from 'src/app/shared/Models/physicalExamination';
import { StressTest } from 'src/app/shared/Models/stressTest';
import { Treatment } from 'src/app/shared/Models/treatment';
@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.scss']
})
export class PatientDetailsComponent implements OnInit {
  patient?: Patient;
  appointment!: Appointment[];
  bloodTest!: BloodTest[];
  cardiacCathStudy!: CardiacCathStudy[];
  diagnostic!: Diagnostic[];
  diseaseHistory!: DiseaseHistory[];
  echocardiogram!: Echocardiogram[];
  electrocardiogram!: Electrocardiogram[];
  holterStudy!: HolterStudy[];
  medicalHistory!: MedicalHistory[];
  physicalExamination!: PhysicalExamination[];
  stressTest!: StressTest[];
  treatment!: Treatment[];

  constructor(
    private patientService: PatientService,
    private route: ActivatedRoute,

  ) { }

  ngOnInit(): void {
    this.loadPatient();
  }

  // loadPatient() {
  //   const id = this.route.snapshot.paramMap.get('id');
  //   if (id) this.patientService.getPatient(+id).subscribe({
  //     next: patient => this.patient = patient,
  //     error: error => console.log(error)
  //   })
  // }


  // loadPatient() {
  //   this.route.params.subscribe((params) => {
  //     const patientId = +params['id'];

  //     //details patient by id
  //     this.patientService.getPatient(patientId).subscribe((patient) => {
  //       this.patient = patient;
  //     });

  //     // appointment of patient by id
  //     this.patientService.getAppointmentByPatientId(patientId).subscribe((appointments) => {
  //       this.appointments = appointments
  //     });
  //   });
  // }

  loadPatient() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.patientService.getPatient(+id).subscribe({
        next: patient => this.patient = patient,
        error: error => console.log(error)
      });

      this.patientService.getAppointmentByPatientId(+id).subscribe(appointments => {
        this.appointment = appointments;
      });

      this.patientService.getBloodTestByPatientId(+id).subscribe(bloodTest => {
        this.bloodTest = bloodTest;
      });

      this.patientService.getCardiacCathStudyByPatientId(+id).subscribe(cardiacCathStudy => {
        this.cardiacCathStudy = cardiacCathStudy;
      });

      this.patientService.getDiagnosticByPatientId(+id).subscribe(diagnostic => {
        this.diagnostic = diagnostic;
      });

      this.patientService.getDiseaseHistoryByPatientId(+id).subscribe(diseaseHistory => {
        this.diseaseHistory = diseaseHistory;
      });

      this.patientService.getEchocardiogramByPatientId(+id).subscribe(echocardiogram => {
        this.echocardiogram = echocardiogram;
      });

      this.patientService.getElectrocardiogramByPatientId(+id).subscribe(electrocardiogram => {
        this.electrocardiogram = electrocardiogram;
      });

      this.patientService.getHolterStudyByPatientId(+id).subscribe(holterStudy => {
        this.holterStudy = holterStudy;
      });

      this.patientService.getMedicalHistoryByPatientId(+id).subscribe(medicalHistory => {
        this.medicalHistory = medicalHistory;
      });

      this.patientService.getPhysicalExaminationByPatientId(+id).subscribe(physicalExamination => {
        this.physicalExamination = physicalExamination;
      });

      this.patientService.getStressTestByPatientId(+id).subscribe(stressTest => {
        this.stressTest = stressTest;
      });

      this.patientService.getTreatmentByPatientId(+id).subscribe(treatment => {
        this.treatment = treatment;
      });
    }
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
