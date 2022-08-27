import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { TitleVm } from '../models/title-vm';

@Injectable({
  providedIn: 'root'
})
export class TitleService {

  _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
   }

  get() {
    return this.http.get<TitleVm[]>(`${this._baseUrl}title`);
  }

  post(model: TitleVm) {
    return this.http.post<void>(`${this._baseUrl}title`, model);
  }

  put(model: TitleVm) {
    return this.http.put<void>(`${this._baseUrl}title`, model);
  }
}
