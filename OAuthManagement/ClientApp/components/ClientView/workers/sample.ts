import { AppThunkAction } from '../../../store';
import { KnownAction, ActionTypes, FetchSampleSucceeded } from '../actions';
import * as Api from "../apis";
import { SampleState, Sample } from '../models';
import { IException, isException, isFailed } from '../../../shared/error';

export const fetchSample = (): AppThunkAction<KnownAction> => async (dispatch, getState) => {
    dispatch({ type: ActionTypes.FETCH_SAMPLE_STARTED });
    try {
        const response = await Api.getList();
        if (isFailed(response)) {
            throw { httpCode: response.status, message: await response.json()} as IException;
        }
        const data = await response.json();
        console.log(data);
        dispatch({ type: ActionTypes.FETCH_SAMPLE_SUCCEEDED, sample: data as Sample });
    } catch(e) {
        if (isException(e)) {
            console.log(e.httpCode, e.message);
            dispatch({ type: ActionTypes.FETCH_SAMPLE_FAILED });
        }
        else {
            //jump to exception page
            console.log("e!:", e);
        }
    }
}

export const fetchSampleStarted = (state: SampleState) => state.set("isLoading", true);

export const fetchSampleSucceeded = (state: SampleState, action: FetchSampleSucceeded) => 
         state
            .set("sample", new Sample(action.sample))
            .set("isLoading", false);

export const fetchSampleFailed = (state: SampleState) =>  state;
