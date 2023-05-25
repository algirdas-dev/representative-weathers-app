export class ObservationAverage {
    constructor(observationDate: string, airTemperature: number){
        this.airTemperature = airTemperature;
        this.observationDate = observationDate;
    }
    
    airTemperature: number = 0;
    observationDate: string = '';
}
