import Lokka from 'lokka';
import Transport from 'lokka-transport-http';

function fetch(query, token) {
    const headers = {'Authorization':'Bearer ' + token}
    return new Lokka({
        transport: new Transport(DEBTSAPIURI, {headers})
    }).query(query);
}
 
export const API_CALL = "API_CALL"

export default store => next => action => {
    if (action.type !== API_CALL)
        return next(action)

    if (action.onRequest)
        next({
            type: action.onRequest,
            request: action
        })

    return fetch(action.query, store.getState().token.access_token)
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