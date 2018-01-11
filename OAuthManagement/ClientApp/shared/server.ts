// import { getUser } from "./security";

const sharedHeaders = {
  Accept: "application/json",
  "Content-Type": "application/json"
}

enum HttpMethods {
  GET = "GET",
  POST = "POST",
  PUT = "PUT",
  PATCH = "PATCH",
  DELETE = "DELETE"
}

//   const user = getUser();
//   if (user.accessToken) {
//     headers.Authorization = `Bearer ${user.accessToken}`;
//   }
//   return headers;
// }

function buildURL(path: string) {
  if (path.indexOf("?") > 0) {
    return `api/${path}&nocache=${Math.random()}`;
  }
  return `/api/${path}?nocache=${Math.random()}`;
}

function get(path: string, options = {}) {
  return doFetch(path, null, HttpMethods.GET, options);
}

function post(path: string, data: any, options = {}) {
  return doFetch(path, data, HttpMethods.POST, options);
}

function put(path: string, data: any, options = {}) {
  return doFetch(path, data, HttpMethods.PUT, options);
}

function del(path: string, data: any, options = {}) {
  return doFetch(path, data, HttpMethods.DELETE, options);
}

function doFetch(path: string, data: any, method: HttpMethods, options = {}) {
  return fetch(buildURL(path), {
      method: method,
      headers: {
        ...options,
        ...sharedHeaders
      },
      body: data ? JSON.stringify(data) : null
    }
  );
}

export default {
  buildURL,
  get,
  post,
  put,
  delete: del
};
