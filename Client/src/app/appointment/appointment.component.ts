import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { Appointment } from '../shared/Models/appointment';
import { AppointmentService } from '../sections/appointment/appointment.service';
import { AppointmentParams } from '../shared/Models/appointmentParams';
import { AppointmentStatus } from '../shared/Models/appointmentStatus';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;
  appointments!: Appointment[];
  appointmentsStatuses!: AppointmentStatus[];

  appointmentParams = new AppointmentParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Date Ascending', value: 'dateAsc' },
    { name: 'Date Descending', value: 'dateDesc' },
  ];

  totalCount = 0;

  constructor(
    private appointmentService: AppointmentService,
  ) { }

  ngOnInit(): void {
    this.getAppointments();
    this.getAppointmentStatus();
  }
  onDateSelected(selectedDate: Date): void {
    this.appointmentParams.date = selectedDate.toISOString(); // Ajusta el formato de fecha según tus necesidades
    this.onSearch();
  }

  getAppointments() {
    this.appointmentService.getAppointments(this.appointmentParams).subscribe({
      next: response => {
        console.log(response);

        this.appointments = response.data;
        this.appointmentParams.pageNumber = response.pageIndex,
          this.appointmentParams.pageSize = response.pageSize,
          this.totalCount = response.count;
      },
      error: error => console.log(error)
    });
  }

  onSortSelected(event: any) {
    this.appointmentParams.sort = event.target.value;
    this.getAppointments();
  }

  onPageChanged(event: any) {
    if (this.appointmentParams.pageNumber !== event.page) {
      this.appointmentParams.pageNumber = event.page;
      this.getAppointments();
    }
  }

  onSearch() {
    this.appointmentParams.search = this.searchTerm?.nativeElement.value;
    this.appointmentParams.pageNumber = 1;
    this.getAppointments();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.appointmentParams = new AppointmentParams();
    this.getAppointments();
  }

  getAppointmentStatus() {
    this.appointmentService.getAppointmentStatus().subscribe({
      next: response => this.appointmentsStatuses = [{ id: 0, appointmentStatusName: 'All' }, ...response],
      error: error => console.log(error)
    });
  }

  onAppointmentStatusSelected(appointmentStatusId: number) {
    this.appointmentParams.appointmentStatusId = appointmentStatusId;
    this.appointmentParams.pageNumber = 1;
    this.getAppointments();
  }

  showPopup = false;

  togglePopup() {
    this.showPopup = !this.showPopup;
  }

  closePopup() {
    this.showPopup = false;
  }
  stopPropagation(event: Event) {
    event.stopPropagation();
  }
}

