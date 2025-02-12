import { TestBed } from '@angular/core/testing';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SavingsModel } from '../models/savings.model';

@Injectable({
  providedIn: 'root',
})
export class SavingsCalculatorService {
  private apiUrl = 'https://localhost:32768/Calculations/CalculateSavings'; // Replace with your API URL

  constructor(private http: HttpClient) {}

  calculateSavings(savingsModel: SavingsModel): Observable<any> {
    return this.http.post<any>(this.apiUrl, savingsModel, {
      headers: {
        'Content-Type': 'application/json',
        accept: 'text/plain',
      },
    });
  }
}
