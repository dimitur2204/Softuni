import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ITheme } from './interfaces/theme';


@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  constructor(private http:HttpClient) { }

  getThemes():Observable<ITheme[]>{
    return this.http.get<ITheme[]>(environment.apiUrl + '/themes');
  }
}
