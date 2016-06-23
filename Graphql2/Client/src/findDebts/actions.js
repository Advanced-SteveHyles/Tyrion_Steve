import { API_CALL } from '../middleware/api'

export const FETCH_DEBTS_REQUEST = 'FETCH_DEBTS_REQUEST'
export const FETCH_DEBTS_SUCCESS = 'FETCH_DEBTS_SUCCESS'
export const FETCH_DEBTS_FAILURE = 'FETCH_DEBTS_FAILURE'

export const getDebts = (searchString) => {
    var matterContext = `matters(reference:"` + searchString + `")`
    if (searchString === undefined || searchString === "") {
        matterContext = `matters`
    }

    return ({
        type: API_CALL,
        query: `{
                    client(id:"`+ CLIENTIDENTIFIER + `") {
                        reference,
                        name,` +
        matterContext + ` {
                            reference,
                            description
                            ourReference                            
                        }
                    }
                }`,
        selector: query => query.client.matters,
        onRequest: FETCH_DEBTS_REQUEST,
        onSuccess: FETCH_DEBTS_SUCCESS,
        onFailure: FETCH_DEBTS_FAILURE
    })
}
