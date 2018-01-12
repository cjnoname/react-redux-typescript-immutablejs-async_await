import { Record } from 'immutable';
import { Sample } from './sample';

interface ISampleState {
    isLoading: boolean;
    sample: Sample;
}

const sampleStateInitial = Record<ISampleState>({
    isLoading: true,
    sample: new Sample()
})

export class SampleState extends sampleStateInitial {}