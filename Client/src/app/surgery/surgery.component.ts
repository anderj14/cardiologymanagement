import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Surgery } from '../shared/Models/surgery';
import { SurgeryParams } from '../shared/Models/surgeryParams';
import { SurgeryService } from './surgery.service';

@Component({
  selector: 'app-surgery',
  templateUrl: './surgery.component.html',
  styleUrls: ['./surgery.component.scss']
})
export class SurgeryComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;
  surgeries!: Surgery[];

  surgeryParams = new SurgeryParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Date Ascending', value: 'dateAsc' },
    { name: 'Date Descending', value: 'dateDesc' }
  ]

  totalCount = 0;

  constructor(private surgeryService: SurgeryService) { }

  ngOnInit(): void {
    this.getSurgeries();
  }

  getSurgeries() {
    this.surgeryService.getSurgeries(this.surgeryParams).subscribe({
      next: response => {
        console.log(response);

        this.surgeries = response.data;
        this.surgeryParams.pageNumber = response.pageIndex;
        this.surgeryParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    });
  }

  onSortSelected(event: any) {
    this.surgeryParams.sort = event.target.value;
    this.getSurgeries();
  }

  onPageChanged(event: any) {
    if (this.surgeryParams.pageNumber !== event.page) {
      this.surgeryParams.pageNumber = event.page;
      this.getSurgeries();
    }
  }

  onSearch() {
    this.surgeryParams.search = this.searchTerm?.nativeElement.value;
    this.surgeryParams.pageNumber = 1;
    this.getSurgeries();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.surgeryParams = new SurgeryParams();
    this.getSurgeries();
  }


}
