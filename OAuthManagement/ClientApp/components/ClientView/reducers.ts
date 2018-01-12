import { Action, Reducer, ActionCreator } from 'redux';
import { KnownAction, ActionTypes } from './actions';
import { fetchSampleStarted, fetchSampleSucceeded, fetchSampleFailed } from './workers/sample';
import { SampleState, Sample } from './models';

export const ClientViewReducer: Reducer<SampleState> = (state: SampleState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case ActionTypes.FETCH_SAMPLE_STARTED: { return fetchSampleStarted(state) };
        case ActionTypes.FETCH_SAMPLE_SUCCEEDED: { return fetchSampleSucceeded(state, action) };
        case ActionTypes.FETCH_SAMPLE_FAILED: { return fetchSampleFailed(state) };
    }
    return state || new SampleState();
};
