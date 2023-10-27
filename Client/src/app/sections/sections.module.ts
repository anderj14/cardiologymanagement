import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentModule } from './appointment/appointment.module';
import { BloodTestModule } from './blood-test/blood-test.module';
import { CoreModule } from '../core/core.module';
import { CardiacCathStudyModule } from './cardiac-cath-study/cardiac-cath-study.module';
import { DiagnosticsModule } from './diagnostics/diagnostics.module';
import { EchocardiogramModule } from './echocardiogram/echocardiogram.module';
import { DiseaseHistoryModule } from './disease-history/disease-history.module';
import { ElectrocardiogramModule } from './electrocardiogram/electrocardiogram.module';
import { HolterStudyModule } from './holter-study/holter-study.module';
import { MedicalHistoryModule } from './medical-history/medical-history.module';
import { PhysicalExaminationModule } from './physical-examination/physical-examination.module';
import { StressTestModule } from './stress-test/stress-test.module';
import { TreatmentModule } from './treatment/treatment.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AppointmentModule,
    BloodTestModule,
    CoreModule,
    CardiacCathStudyModule,
    DiagnosticsModule,
    EchocardiogramModule,
    DiseaseHistoryModule,
    ElectrocardiogramModule,
    HolterStudyModule,
    MedicalHistoryModule,
    PhysicalExaminationModule,
    StressTestModule,
    TreatmentModule
  ]
})
export class SectionsModule { }
