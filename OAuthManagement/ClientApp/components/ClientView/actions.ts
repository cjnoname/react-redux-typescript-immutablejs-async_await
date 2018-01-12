import { Sample } from './models';
import { fetchSample } from './workers/sample';

export enum ActionTypes {
    FETCH_SAMPLE_STARTED,
    FETCH_SAMPLE_SUCCEEDED,
    FETCH_SAMPLE_FAILED
}

export interface FetchSampleStarted {
    type: ActionTypes.FETCH_SAMPLE_STARTED;
}

export interface FetchSampleSucceeded {
    type: ActionTypes.FETCH_SAMPLE_SUCCEEDED;
    sample: Sample;
}

export interface FetchSampleFailed {
    type: ActionTypes.FETCH_SAMPLE_FAILED;
}

export type KnownAction = FetchSampleStarted | FetchSampleSucceeded | FetchSampleFailed;

export const actionCreators = {
    fetchSample
};
