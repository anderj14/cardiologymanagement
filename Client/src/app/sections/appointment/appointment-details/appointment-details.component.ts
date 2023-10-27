import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../appointment.service';
import { ActivatedRoute } from '@angular/router';
import { Appointment } from 'src/app/shared/Models/appointment';
import { PatientService } from 'src/app/patient/patient.service';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.scss']
})
export class AppointmentDetailsComponent implements OnInit {
  appointment: Appointment | undefined;

  patientId: number | undefined;
  appointmentId: number | undefined;
  patientName: string | undefined

  constructor(
    private appointmentService: AppointmentService,
    private route: ActivatedRoute,
    private patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.loadAppointmentDetails();
  }

  getAppointmentDetails(patientId: number, appointmentId: number) {
    this.appointmentService.getAppointmentByPatientId(patientId, appointmentId).subscribe(appointment => {
      this.appointment = appointment;
    });
  }

  loadAppointmentDetails() {
    this.route.params.subscribe(params => {
      this.patientId = +params['patientId'];
      this.appointmentId = +params['appointmentId'];
      if (this.patientId) {
        this.patientService.getPatient(this.patientId).subscribe(patient => {
          this.patientName = patient.patientName;
        });
      }

      if (this.patientId && this.appointmentId) {
        this.getAppointmentDetails(this.patientId, this.appointmentId);
      }
    });
  }
}
