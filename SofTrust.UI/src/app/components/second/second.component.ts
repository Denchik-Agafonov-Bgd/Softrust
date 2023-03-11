import { Component } from '@angular/core';
import { DataOutput } from 'src/app/models/dataOutput';
import { DataOutputService } from 'src/app/services/dataOutput';

@Component({
  selector: 'app-second',
  templateUrl: './second.component.html',
  styleUrls: ['./second.component.css']
})
export class SecondComponent {
  dataOutput: DataOutput = new DataOutput;

  constructor(
    private dataOutputService: DataOutputService
  ) {}

  ngOnInit(): void {
    this.GetInfo();
  }

  async GetInfo(){

    this.dataOutputService
    .getDataOutput()
    .subscribe((result: DataOutput) => (this.dataOutput = result));
  }
}
