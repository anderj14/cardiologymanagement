import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardiacCathStudyComponent } from './cardiac-cath-study.component';
import { CardiacCathStudyDetailsComponent } from './cardiac-cath-study-details/cardiac-cath-study-details.component';
import { CardiacCathStudyRoutingModule } from './cardiac-cath-study-routing.module';
import { CoreModule } from 'src/app/core/core.module';
import { MaterialModule } from 'src/app/material/material/material.module';



@NgModule({
    declarations: [
        CardiacCathStudyComponent,
        CardiacCathStudyDetailsComponent
    ],
    imports: [
        CommonModule,
        CardiacCathStudyRoutingModule,
        CoreModule,
        MaterialModule
    ]
})
export class CardiacCathStudyModule { }
