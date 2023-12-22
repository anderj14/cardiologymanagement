import { Component, OnInit } from '@angular/core';
import { Surgery } from 'src/app/shared/Models/surgery';
import { SurgeryService } from '../surgery.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-surgery-details',
  templateUrl: './surgery-details.component.html',
  styleUrls: ['./surgery-details.component.scss']
})
export class SurgeryDetailsComponent implements OnInit {
  surgery!: Surgery;

  constructor(
    private surgeryService: SurgeryService,
    private activateRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadSurgery();
  }

  loadSurgery() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.surgeryService.getSurgery(+id).subscribe({
        next: surgery => this.surgery = surgery,
        error: error => console.log(error)
      });
    }
  }
}
