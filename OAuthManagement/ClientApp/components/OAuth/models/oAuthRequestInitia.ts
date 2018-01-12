import { Record } from 'immutable';

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