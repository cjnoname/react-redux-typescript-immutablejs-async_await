import { Action, Reducer, ActionCreator } from 'redux';
import { KnownAction, ActionTypes } from './actions';
import { SampleState, Sample } from './models';

export const ClientViewReducer: Reducer<SampleState> = (state: SampleState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case ActionTypes.REQUEST_SAMPLE: {
            state = state.set("isLoading", true);
            return state;
        }
        case ActionTypes.RECEIVE_SAMPLE: {
            state = state
                    .set("sample", new Sample(action.sample))
                    .set("isLoading", false);
            return state;
        }
    }
    return state || new SampleState();
};