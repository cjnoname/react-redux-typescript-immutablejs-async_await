import { Record } from 'immutable';

interface IClient {
    clientId: string;
}

const clientInitial = Record<IClient>({
    clientId: ""
})

export class Client extends clientInitial {}