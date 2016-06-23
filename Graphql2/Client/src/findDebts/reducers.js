import { FETCH_DEBTS_REQUEST, FETCH_DEBTS_FAILURE, FETCH_DEBTS_SUCCESS } from './actions'

const initialState = { }

export default function update (state =  initialState, action)
{
    if (action.type === FETCH_DEBTS_REQUEST)
    {
        return { loading: true }
    }
    if (action.type === FETCH_DEBTS_FAILURE)
    {
        return { error: action.error }
    }
    
    if (action.type === FETCH_DEBTS_SUCCESS)
    {
        return { 
            results: action.response
         }
    }
    
    return state
}