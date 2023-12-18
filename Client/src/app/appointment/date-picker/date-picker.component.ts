import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.scss']
})
export class DatePickerComponent {
  @Output() dateSelected: EventEmitter<Date> = new EventEmitter<Date>();

  currentDate: Date = new Date();

  selectDate(offset: number, unit: string): void {
    const newDate = new Date(this.currentDate);
    if (unit === 'day') {
      newDate.setDate(newDate.getDate() + offset);
    } else if (unit === 'month') {
      newDate.setMonth(newDate.getMonth() + offset);
    } else if (unit === 'year') {
      newDate.setFullYear(newDate.getFullYear() + offset);
    }
    const adjustedDate = new Date(newDate.getTime() - newDate.getTimezoneOffset() * 60000);

    this.currentDate = adjustedDate;
    this.emitSelectedDate();
  }


  private emitSelectedDate(): void {
    this.dateSelected.emit(new Date(this.currentDate));
  }

}
