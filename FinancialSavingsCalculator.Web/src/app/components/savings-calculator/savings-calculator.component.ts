import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BaseChartDirective } from 'ng2-charts';
import { SavingsCalculatorService } from '../../services/savings-calculator.service';
import { SavingsModel } from '../../models/savings.model';
import {
  Chart,
  ChartOptions,
  ChartType,
  ChartDataset,
  registerables,
} from 'chart.js';

// Register the required chart types
Chart.register(...registerables);

interface YearlySavingsResult {
  year: number;
  totalAmount: number;
  depositedAmount: number;
  interestEarned: number;
  totalInterestEarned: number;
}

@Component({
  selector: 'app-savings-calculator',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule, BaseChartDirective],
  templateUrl: './savings-calculator.component.html',
  styleUrls: ['./savings-calculator.component.css'],
  providers: [SavingsCalculatorService],
})
export class SavingsCalculatorComponent {
  initialAmount: number = 0;
  monthlyContribution: number = 0;
  apy: number = 0;
  years: number = 1;
  totalSavings: number | null = null;
  yearlySavingsResults: YearlySavingsResult[] = [];
  filterYear: number | null = null;
  selectedYear: number | null = null;
  currentPage: number = 0;
  pageSize: number = 10;

  // Line chart data
  lineChartData: ChartDataset[] = [];
  lineChartLabels: string[] = [];
  lineChartOptions: ChartOptions = {
    responsive: true,
  };
  lineChartColors: Array<any> = [
    {
      backgroundColor: 'rgba(0, 123, 255, 0.3)',
      borderColor: 'rgba(0, 123, 255, 1)',
    },
    {
      backgroundColor: 'rgba(255, 193, 7, 0.3)',
      borderColor: 'rgba(255, 193, 7, 1)',
    },
    {
      backgroundColor: 'rgba(40, 167, 69, 0.3)',
      borderColor: 'rgba(40, 167, 69, 1)',
    },
  ];
  lineChartLegend = true;
  lineChartType: ChartType = 'line';

  // Bar chart data
  barChartData: ChartDataset[] = [];
  barChartLabels: string[] = [];
  barChartOptions: ChartOptions = {
    responsive: true,
  };
  barChartColors: Array<any> = [
    {
      backgroundColor: 'rgba(0, 123, 255, 0.3)',
      borderColor: 'rgba(0, 123, 255, 1)',
    },
    {
      backgroundColor: 'rgba(255, 193, 7, 0.3)',
      borderColor: 'rgba(255, 193, 7, 1)',
    },
  ];
  barChartLegend = true;
  barChartType: ChartType = 'bar';

  constructor(private savingsCalculatorService: SavingsCalculatorService) {}

  calculateSavings() {
    const savingsModel: SavingsModel = {
      initialAmount: this.initialAmount,
      monthlyDeposit: this.monthlyContribution,
      annualPercentageYield: this.apy,
      years: this.years,
    };

    this.savingsCalculatorService.calculateSavings(savingsModel).subscribe(
      (response: YearlySavingsResult[]) => {
        this.yearlySavingsResults = response;
        this.totalSavings = response.reduce(
          (acc, result) => acc + result.totalAmount,
          0
        );
        this.selectYear(response[0].year);
        this.updateCharts();
      },
      (error) => {
        console.error('Error calculating savings:', error);
      }
    );
  }

  get displayedYears(): number[] {
    const start = this.currentPage * this.pageSize;
    return this.yearlySavingsResults
      .slice(start, start + this.pageSize)
      .map((result) => result.year);
  }

  get maxPage(): number {
    return Math.ceil(this.yearlySavingsResults.length / this.pageSize) - 1;
  }

  prevPage() {
    if (this.currentPage > 0) {
      this.currentPage--;
    }
  }

  nextPage() {
    if (this.currentPage < this.maxPage) {
      this.currentPage++;
    }
  }

  selectYear(year: number) {
    this.selectedYear = year;
  }

  get selectedYearResult(): YearlySavingsResult {
    return this.yearlySavingsResults.find(
      (result) => result.year === this.selectedYear
    )!;
  }

  filteredResults() {
    if (this.filterYear) {
      return this.yearlySavingsResults.filter(
        (result) => result.year === this.filterYear
      );
    }
    return this.yearlySavingsResults;
  }

  updateCharts() {
    const years = this.yearlySavingsResults.map((result) =>
      result.year.toString()
    );
    const totalAmounts = this.yearlySavingsResults.map(
      (result) => result.totalAmount
    );
    const depositedAmounts = this.yearlySavingsResults.map(
      (result) => result.depositedAmount
    );
    const interestEarned = this.yearlySavingsResults.map(
      (result) => result.interestEarned
    );

    this.lineChartLabels = years;
    this.lineChartData = [
      { data: totalAmounts, label: 'Total Amount' },
      { data: depositedAmounts, label: 'Deposited Amount' },
      { data: interestEarned, label: 'Interest Earned' },
    ];

    this.barChartLabels = years;
    this.barChartData = [
      { data: depositedAmounts, label: 'Total Deposited' },
      { data: interestEarned, label: 'Total Interest Earned' },
    ];
  }
}
