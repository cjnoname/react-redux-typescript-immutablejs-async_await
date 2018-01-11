import { Action, Reducer } from 'redux';
import { KnownAction } from './actions';
import { OAuthState } from './models';
import { ActionTypes } from './actions';

export const OAuthReducer: Reducer<OAuthState> = (state: OAuthState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case ActionTypes.SAVE_OAUTH:
            console.log("success!" + action.data);
    }

    return state || new OAuthState();
};