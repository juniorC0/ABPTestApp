import { Component } from '@angular/core';
import { Device } from './models/device';
import { ExperimentService } from './services/experiment.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'ABPTestApp.UI';
}
