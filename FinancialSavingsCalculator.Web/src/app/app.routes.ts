import { Routes } from '@angular/router';
import { SavingsCalculatorComponent } from './components/savings-calculator/savings-calculator.component';

export const routes: Routes = [
  { path: 'savings-calculator', component: SavingsCalculatorComponent },
  { path: '', redirectTo: '/savings-calculator', pathMatch: 'full' },
  // other routes
];
