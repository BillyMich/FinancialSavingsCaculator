import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { SavingsCalculatorComponent } from './app/components/savings-calculator/savings-calculator.component';
import { Routes } from '@angular/router';

const routes: Routes = [
  { path: 'savings-calculator', component: SavingsCalculatorComponent },
  { path: '', redirectTo: '/savings-calculator', pathMatch: 'full' },
  // other routes
];

bootstrapApplication(AppComponent, {
  providers: [provideRouter(routes), provideHttpClient()],
}).catch((err) => console.error(err));
