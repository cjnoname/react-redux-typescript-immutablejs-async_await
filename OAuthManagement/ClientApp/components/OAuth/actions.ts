import { OAuthRequest } from './models';
import { saveOAuth } from './workers/saveOAuth'

export enum ActionTypes {
    SAVE_OAUTH_STARTED,
    SAVE_OAUTH_SUCCEEDED,
    SAVE_OAUTH_FAILED
}

export interface SaveOAuthStarted {
    type: ActionTypes.SAVE_OAUTH_STARTED;
    data: OAuthRequest;
}

export interface SaveOAuthSucceeded {
    type: ActionTypes.SAVE_OAUTH_SUCCEEDED;
}

export interface SaveOAuthFailed {
    type: ActionTypes.SAVE_OAUTH_FAILED;
}

export type KnownAction = SaveOAuthStarted | SaveOAuthSucceeded | SaveOAuthFailed;

export const actionCreators = {
    saveOAuth
};