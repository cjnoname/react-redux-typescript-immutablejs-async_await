import { AppThunkAction } from '../../store';
import { Sample } from './models';
import * as Api from "./apis";

export enum ActionTypes {
    REQUEST_SAMPLE = 'REQUEST_SAMPLE',
    RECEIVE_SAMPLE = 'RECEIVE_SAMPLE'
}

export interface RequestSampleAction {
    type: ActionTypes.REQUEST_SAMPLE;
}

export interface ReceiveSampleAction {
    type: ActionTypes.RECEIVE_SAMPLE;
    sample: Sample;
}

export type KnownAction = RequestSampleAction | ReceiveSampleAction;

export const actionCreators = {
    requestSample: (): AppThunkAction<KnownAction> => async (dispatch, getState) => {
        dispatch({ type: ActionTypes.REQUEST_SAMPLE });
        try {
            const response = await Api.getList();
            const data = await response.json();
            dispatch({ type: ActionTypes.RECEIVE_SAMPLE, sample: data as Sample });
        }catch(e) {
            console.log("e!:", e);
        }
    }
};