import { Record } from 'immutable';

export interface OAuthRequest {
    clientId: string;
    clientSecret: string;
    clientName: string;
    placeCode: string;
    chainCode: string;
}

interface IOAuthState {
    isLoading: boolean;
}

const oAuthStateInitial = Record<IOAuthState>({
    isLoading: false
})

export class OAuthState extends oAuthStateInitial {}

interface IOAuthRequestInitial {
    clientId: string;
    clientSecret: string;
    clientName: string;
    placeCode: string;
    chainCode: string;
}

const oAuthRequestInitial = Record<IOAuthRequestInitial>({
    clientId: "",
    clientSecret: "",
    clientName: "",
    placeCode: "",
    chainCode: ""
})

export class OAuthRequestState extends oAuthRequestInitial {}