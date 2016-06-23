import { FETCH_SUMMARYMATTER_REQUEST, FETCH_SUMMARYMATTER_SUCCESS, FETCH_SUMMARYMATTER_FAILURE } from './actions'

const initialState = { debt: {}, feeEarner: { url : {} }, supervisor: {  url : {} } }

export default function update (state =  initialState, action)
{
    if (action.type === FETCH_SUMMARYMATTER_REQUEST)
    {
        return { ...initialState, loading: true }
    }
    if (action.type === FETCH_SUMMARYMATTER_FAILURE)
    {
        return { ...initialState, error: action.error }
    }
    if (action.type === FETCH_SUMMARYMATTER_SUCCESS)
    {
        return { 
            ...action.response
         }
    }
    
    return state
}