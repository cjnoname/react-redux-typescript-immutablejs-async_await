import server from '../../shared/server'

export const saveOAuth = (data: any) => server.post("oauth/save", data);
