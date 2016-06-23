import { FETCH_SUMMARYHEADER_REQUEST, FETCH_SUMMARYHEADER_SUCCESS, FETCH_SUMMARYHEADER_FAILURE } from './actions'

const initialState = { debtor: {} }

export default function update(state = initialState, action) {
    if (action.type === FETCH_SUMMARYHEADER_REQUEST) {
        return { ...initialState, loading: true }
    }
    if (action.type === FETCH_SUMMARYHEADER_FAILURE) {
        return { ...initialState, error: action.error }
    }
    if (action.type === FETCH_SUMMARYHEADER_SUCCESS) {
        return { 
            ...action.response
        }
    }

    return state
}