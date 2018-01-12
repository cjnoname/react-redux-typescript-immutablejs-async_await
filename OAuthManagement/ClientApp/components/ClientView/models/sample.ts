import { Record } from 'immutable';
import { Client } from './client';

interface ISample {
    clientId?: string;
    token?: string;
    client: Client;
}

const sampleInitial = Record<ISample>({
    clientId: undefined,
    token: "",
    client: new Client()
})

export class Sample extends sampleInitial {}