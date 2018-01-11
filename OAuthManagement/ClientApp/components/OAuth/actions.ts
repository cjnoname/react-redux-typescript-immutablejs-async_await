import { AppThunkAction } from '../../store';
import { OAuthRequest } from './models';
import { addTask } from 'domain-task';
import * as Api from './apis';

export enum ActionTypes {
    SAVE_OAUTH = 'SAVE_OAUTH'
}

export interface SaveOAuthAction {
    type: ActionTypes.SAVE_OAUTH;
    data: OAuthRequest;
}

export type KnownAction = SaveOAuthAction;

export const actionCreators = {
    saveData: (data: OAuthRequest): AppThunkAction<KnownAction> => async dispatch => {
        try {
            const response = await Api.saveOAuth(data);
            console.log(response);
            const error = await response.json();
            console.log(error);
            dispatch({ type: ActionTypes.SAVE_OAUTH , data: data });
        }catch(e) {
            console.log(1231231231);
            console.log("e!:", e);
        }
    }
};