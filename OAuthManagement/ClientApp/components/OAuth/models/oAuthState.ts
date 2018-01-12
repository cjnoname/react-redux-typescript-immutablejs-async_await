import { Record } from 'immutable';

interface IOAuthState {
    isLoading: boolean;
}

const oAuthStateInitial = Record<IOAuthState>({
    isLoading: false
})

export class OAuthState extends oAuthStateInitial {}