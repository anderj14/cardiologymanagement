import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppointmentService } from 'src/app/sections/appointment/appointment.service';
import { Appointment } from 'src/app/shared/Models/appointment';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.scss']
})
export class AppointmentDetailsComponent implements OnInit {
  appointment!: Appointment;

  constructor(
    private appointmentService: AppointmentService,
    private activateRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadAppointment();
  }

  loadAppointment() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.appointmentService.getAppointment(+id).subscribe({
        next: appointment => this.appointment = appointment,
        error: error => console.log(error)
      });
    }
  }
}
