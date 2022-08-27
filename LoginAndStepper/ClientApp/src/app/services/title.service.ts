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
}
