import { Component, OnInit } from '@angular/core';
import { ExperimentService } from 'src/app/services/experiment.service';
import { Device } from 'src/app/models/device';
import { map } from 'rxjs';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css'],
})
export class StatisticsComponent implements OnInit {
  buttonColorExperimentDevices: Device[] = [];
  priceExperimentDevices: Device[] = [];

  // constructor(private experimentService: ExperimentService) {}

  // ngOnInit(): void {
  //   // this.getButtonColorExperimentDevices();
  //   // this.getPriceExperimentDevices();
  // }

  // getButtonColorExperimentDevices() {
  //   this.experimentService.getAllDevices().subscribe((data: Device[]) => {
  //     this.buttonColorExperimentDevices = data.filter(
  //       (device) => device.experiment.name === 'button-color'
  //     );
  //   });
  // }

  // getPriceExperimentDevices() {
  //   this.experimentService.getAllDevices().subscribe((data: Device[]) => {
  //     this.priceExperimentDevices = data.filter(
  //       (device) => device.experiment.name === 'price'
  //     );
  //   });
  // }
  buttonColorExperimentDevicesCountedByOptions: {
    name: string;
    count: number;
  }[] = [];
  priceExperimentDevicesCountedByOptions: { name: string; count: number }[] =
    [];

  constructor(private experimentService: ExperimentService) {}

  ngOnInit(): void {
    this.getButtonColorExperimentDevices();
    this.getPriceExperimentDevices();
  }

  getButtonColorExperimentDevices() {
    this.experimentService.getAllDevices().subscribe((data: Device[]) => {
      this.buttonColorExperimentDevices = data.filter(
        (device) => device.experiment.name === 'button-color'
      );
      const buttonColorCounts = this.getCountsByOptionName(
        this.buttonColorExperimentDevices
      );
      this.buttonColorExperimentDevicesCountedByOptions = buttonColorCounts;
    });
  }

  getPriceExperimentDevices() {
    this.experimentService.getAllDevices().subscribe((data: Device[]) => {
      this.priceExperimentDevices = data.filter(
        (device) => device.experiment.name === 'price'
      );
      const priceCounts = this.getCountsByOptionName(
        this.priceExperimentDevices
      );
      this.priceExperimentDevicesCountedByOptions = priceCounts;
    });
  }

  getCountsByOptionName(devices: Device[]): { name: string; count: number }[] {
    const optionCounts: { [key: string]: number } = {};

    devices.forEach((device) => {
      const optionName = device.experiment.option;
      if (optionCounts[optionName]) {
        optionCounts[optionName]++;
      } else {
        optionCounts[optionName] = 1;
      }
    });

    const counts = [];
    for (const name of Object.keys(optionCounts)) {
      counts.push({ name, count: optionCounts[name] });
    }
    return counts;
  }
}
