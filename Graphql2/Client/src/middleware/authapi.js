import 'isomorphic-fetch';
 
export const AUTH_CALL = "AUTH_CALL"

const EncodeBody = (obj) => {
    var str = [];
        for(var p in obj)
        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
        return str.join("&");
}

const convertToJson = (response) => {
  return (response.status === 204) ? {} : response.text().then((text) => {
    try {
      return JSON.parse(text)
    } catch (e) {
      return { data: text }
    }
  })
}

const status = (response) =>
  (response.ok)
    ? Promise.resolve(response)
    : Promise.reject(new Error("User Invalid"))

export default store => next => action => {
    if (action.type !== AUTH_CALL)
        return next(action)

    if (action.onRequest)
        next({
            type: action.onRequest,
            request: action
        })

    return fetch(
                action.endpoint, 
                {
                    method: action.method || 'post',
                    headers: action.headers,
                    body:    EncodeBody(action.body)
                })
        .then(status)
        .then(convertToJson)
        .then(action.selector)
        .then(results => {
            if (action.onSuccess)
                next({
                    type: action.onSuccess,
                    response: results,
                    request: action
                })
        })
        .catch(error => {
            if (action.onFailure)
                next({
                    type: action.onFailure,
                    error: error.message || 'Something bad happened',
                    request: action
                })
        })
}