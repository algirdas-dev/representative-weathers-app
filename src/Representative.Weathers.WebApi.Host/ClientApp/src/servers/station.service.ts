import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Station } from 'src/models/station';
import { environment } from 'src/environments/environment';
import { Observation } from 'src/models/observation';

@Injectable({
  providedIn: 'root'
})
export class StationService {
  constructor(private http: HttpClient) { }
  
  get():Observable<Station[]>{
    return this.http.get<Station[]>(`${environment.apiUrl}/api/v1/stations`);
  }

  getObservations(code:string):Observable<Observation[]>{
    return this.http.get<Observation[]>(`${environment.apiUrl}/api/v1/stations/${code}/observations`);
  }
}
