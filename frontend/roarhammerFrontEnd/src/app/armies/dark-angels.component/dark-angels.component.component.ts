import {Component, OnInit} from '@angular/core';
import { DarkAngelsService} from "../../services/dark-angels.service.service";

@Component({
  selector: 'app-dark-angels',
  templateUrl: './dark-angels.component.component.html',
  styleUrl: './dark-angels.component.component.css'
})
export class DarkAngelsComponent implements OnInit {

  units: any[] = [];

  constructor(private darkAngelsService: DarkAngelsService) {
  }

  ngOnInit() {
    this.darkAngelsService.getUnits().subscribe((data: any) => {
      this.units = data;
    })
  }

}
