import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/shared/Models/appointment';
import { AppointmentService } from './appointment.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})

export class AppointmentComponent implements OnInit {
  appointments: Appointment[] = [];
  patientId: number | undefined;
  patientName: string | undefined;

  constructor(
    private appointmentService: AppointmentService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.patientId = params['id'];
      if (this.patientId) {
        this.loadAppointments();

        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }
    });
  }

  loadAppointments() {
    if (this.patientId) {
      this.appointmentService.getAppointmentsByPatientId(this.patientId).subscribe(appointments => {
        this.appointments = appointments;
      });
    }
  }
}
