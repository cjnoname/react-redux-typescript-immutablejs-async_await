export interface IException {
    httpCode: number,
    message: string
}

export const isException = (object: any): object is IException => {
    return 'httpCode' in object && 'message' in object;
}

export const isSucceed = (response: Response) => {
    return response.status === 200 || response.status == 201;
}

export const isFailed = (response: Response) => {
    return response.status !== 200 && response.status !== 201;
}

export const isBadRequest = (response: Response) => {
    return response.status === 400;
}
