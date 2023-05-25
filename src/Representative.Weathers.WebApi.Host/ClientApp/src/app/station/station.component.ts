import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ObservationAverage } from 'src/models/observation-average';
import { Station } from 'src/models/station';
import { StationService } from 'src/servers/station.service';

@Component({
  selector: 'app-station',
  templateUrl: './station.component.html',
  styleUrls: ['./station.component.css']
})
export class StationComponent implements OnInit {
  stations: Station[] = [];
  observationAverages: ObservationAverage[] = [];
  stationFilterForm: FormGroup;

  constructor(private _stationService: StationService, readonly fb: FormBuilder = new FormBuilder()) {
    this.stationFilterForm= this.fb.group({
      'code': new FormControl('',Validators.required)
    });
   }

  ngOnInit(): void {
    this._getStations();
  }

  private _getStations = (): void => {
    this._stationService.get().subscribe(
      stations => this.stations = stations,
    )
  }

  getObservations = (stationCode:string): void => {
    if(!this.stationFilterForm.valid)
    {
      return;
    }

    this._stationService.getObservations(stationCode).subscribe(
      observations => {
        let dailyData: any = {};
        observations.forEach((item) => {
          
          const date = new Date(item.observationTimeUtc);
          console.log(date.toISOString().split('T')[0]);
          let dateString = date.toISOString().split('T')[0];

          const airTemperature = item.airTemperature;
        
          if (!dailyData[dateString]) {
            dailyData[dateString] = {
              total: 0,
              count: 0,
            };
          }
        
          dailyData[dateString].total += item.airTemperature;
          dailyData[dateString].count += 1;
        });

        this.observationAverages = [];
        Object.keys(dailyData).forEach((date) => {
          let averangeTemperature = dailyData[date].total / dailyData[date].count;
          this.observationAverages.push(
            new ObservationAverage(date, averangeTemperature)
          );
        });
      }
    )
  }
}
