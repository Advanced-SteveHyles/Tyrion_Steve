import { FETCH_SUMMARYLEDGER_REQUEST, FETCH_SUMMARYLEDGER_SUCCESS, FETCH_SUMMARYLEDGER_FAILURE } from './actions'

const initialState = { debt: { } }

export default function update (state =  initialState, action)
{
    if (action.type === FETCH_SUMMARYLEDGER_REQUEST)
    {
        return { ...initialState, loading: true }
    }
    if (action.type === FETCH_SUMMARYLEDGER_FAILURE)
    {
        return { ...initialState, error: action.error }
    }
    if (action.type === FETCH_SUMMARYLEDGER_SUCCESS)
    {
        return { 
            ...action.response
         }
    }
    
    return state
}