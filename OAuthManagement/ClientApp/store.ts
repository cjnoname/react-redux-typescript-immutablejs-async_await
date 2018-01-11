import { OAuthState } from './components/OAuth/models';
import { OAuthReducer } from './components/OAuth/reducers';
import { SampleState } from './components/ClientView/models';
import { ClientViewReducer } from './components/ClientView/reducers';

// The top-level state object
export interface ApplicationState {
    clientView: SampleState;
    oAuth: OAuthState;
}

// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    clientView: ClientViewReducer,
    oAuth: OAuthReducer
};

// This type can be used as a hint on action creators so that its 'dispatch' and 'getState' params are
// correctly typed to match your store.
export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
