import { AppThunkAction } from '../../../store';
import { addTask } from 'domain-task';
import * as Api from '../apis';
import { OAuthState, OAuthRequest } from '../models';
import { KnownAction, ActionTypes, SaveOAuthStarted } from '../actions';
import { IException, isException, isBadRequest } from '../../../shared/error';

export const saveOAuth = (data: OAuthRequest): AppThunkAction<KnownAction> => async dispatch => {
    try {
        const response = await Api.saveOAuth(data);
        console.log(response);
        if (isBadRequest(response)) {
            throw { httpCode: response.status, message: await response.json()} as IException;
        }
        const error = await response.json();
        console.log(error);
        dispatch({ type: ActionTypes.SAVE_OAUTH_STARTED , data: data });
    } catch(e) {
        if (isException(e)) {
            console.log(e.httpCode, e.message);
            dispatch({ type: ActionTypes.SAVE_OAUTH_FAILED });
        }
        else {
            //jump to exception page
            console.log("e!:", e);
        }
    }
}

export const saveOAuthStarted = (state: OAuthState, action: SaveOAuthStarted) => {
    console.log("success!" + action.data);
    return state;
}

export const saveOAuthSucceeded = (state: OAuthState) => state;

export const saveOAuthFailed = (state: OAuthState) => state;
