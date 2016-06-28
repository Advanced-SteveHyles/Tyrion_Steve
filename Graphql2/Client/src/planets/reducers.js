import { FETCH_PLANETS_REQUEST, FETCH_PLANETS_FAILURE, FETCH_PLANETS_SUCCESS } from './actions'

const initialState = { }


export default function update (state =  initialState, action)
{
    if (action.type === FETCH_PLANETS_REQUEST)
    {
        return { loading: true }
    }
    if (action.type === FETCH_PLANETS_FAILURE)
    {
        return { error: action.error }
    }
    
    if (action.type === FETCH_PLANETS_SUCCESS)
    {
        return { 
            planetList: action.response
         }
    }
    
    return state
}