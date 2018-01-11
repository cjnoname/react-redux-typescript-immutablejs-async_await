import { Record } from 'immutable';

interface IClient {
    clientId: string;
}

const clientInitial = Record<IClient>({
    clientId: ""
})

export class Client extends clientInitial {}

interface ISample {
    clientId: string | null;
    token: string | null;
    client: Client | null;
}

const sampleInitial = Record<ISample>({
    clientId: null,
    token: "",
    client: new Client()
})

export class Sample extends sampleInitial {}

interface ISampleState {
    isLoading: boolean;
    sample: Sample;
}

const sampleStateInitial = Record<ISampleState>({
    isLoading: true,
    sample: new Sample()
})

export class SampleState extends sampleStateInitial {}
