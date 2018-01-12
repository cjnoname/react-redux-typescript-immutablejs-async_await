import { Action, Reducer } from 'redux';
import { KnownAction } from './actions';
import { OAuthState } from './models';
import { ActionTypes } from './actions';
import { saveOAuthStarted, saveOAuthSucceeded, saveOAuthFailed } from './workers/saveOauth';

export const OAuthReducer: Reducer<OAuthState> = (state: OAuthState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case ActionTypes.SAVE_OAUTH_STARTED: { return saveOAuthStarted(state, action) };
        case ActionTypes.SAVE_OAUTH_SUCCEEDED: { return saveOAuthSucceeded(state) };
        case ActionTypes.SAVE_OAUTH_FAILED: { return saveOAuthFailed(state); }
    }
    return state || new OAuthState();
};
