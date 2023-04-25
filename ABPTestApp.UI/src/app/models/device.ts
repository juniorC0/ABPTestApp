import { Experiment } from './experiment';

export interface Device {
  token: string;
  experimentId: number;
  experiment: Experiment;
  id: number;
  creationDate: Date;
}
