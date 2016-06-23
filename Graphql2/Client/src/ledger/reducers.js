import { FETCH_LEDGER_REQUEST, FETCH_LEDGER_SUCCESS, FETCH_LEDGER_FAILURE } from './actions'

const initialState = { ledger: [] }

export default function update(state = initialState, action) {
    if (action.type === FETCH_LEDGER_REQUEST) {
        return { ...initialState, loading: true }
    }
    if (action.type === FETCH_LEDGER_FAILURE) {
        return { ...initialState, error: action.error }
    }
    if (action.type === FETCH_LEDGER_SUCCESS) {
        return { 
            ...action.response
        }
    }

    return state
}