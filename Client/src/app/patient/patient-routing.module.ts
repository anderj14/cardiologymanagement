
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientComponent } from './patient.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { AppointmentComponent } from '../sections/appointment/appointment.component';
import { BloodTestComponent } from '../sections/blood-test/blood-test.component';
import { CardiacCathStudyComponent } from '../sections/cardiac-cath-study/cardiac-cath-study.component';
import { DiagnosticComponent } from '../sections/diagnostics/diagnostic.component';
import { EchocardiogramComponent } from '../sections/echocardiogram/echocardiogram.component';
import { DiseaseHistoryComponent } from '../sections/disease-history/disease-history.component';
import { ElectrocardiogramComponent } from '../sections/electrocardiogram/electrocardiogram.component';
import { HolterStudyComponent } from '../sections/holter-study/holter-study.component';
import { MedicalHistoryComponent } from '../sections/medical-history/medical-history.component';
import { PhysicalExaminationComponent } from '../sections/physical-examination/physical-examination.component';
import { StressTestComponent } from '../sections/stress-test/stress-test.component';
import { TreatmentComponent } from '../sections/treatment/treatment.component';

const routes: Routes = [
  { path: '', component: PatientComponent },
  { path: ':id', component: PatientDetailsComponent },
  { path: ':id/appointments', component: AppointmentComponent },
  { path: ':id/bloodTests', component: BloodTestComponent },
  { path: ':id/cardiacCathStudies', component: CardiacCathStudyComponent },
  { path: ':id/diagnostics', component: DiagnosticComponent },
  { path: ':id/echocardiograms', component: EchocardiogramComponent },
  { path: ':id/diseaseshistory', component: DiseaseHistoryComponent },
  { path: ':id/electrocardiograms', component: ElectrocardiogramComponent },
  { path: ':id/holterstudies', component: HolterStudyComponent },
  { path: ':id/medicalhistories', component: MedicalHistoryComponent },
  { path: ':id/physicalexaminations', component: PhysicalExaminationComponent },
  { path: ':id/stresstests', component: StressTestComponent },
  { path: ':id/treatments', component: TreatmentComponent },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class PatientRoutingModule { }

