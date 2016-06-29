import { FETCH_PLANETS_REQUEST, FETCH_PLANETS_FAILURE, FETCH_PLANETS_SUCCESS } from './actions'

const initialState = { planetList: {}  }

export default function update (state =  initialState, action)
{
    if (action.type === FETCH_PLANETS_REQUEST)
    {
        return { ...initialState, loading: true }
    }
    if (action.type === FETCH_PLANETS_FAILURE)
    {
        return { ...initialState, error: action.error }
    }    
    if (action.type === FETCH_PLANETS_SUCCESS)
    {
        return { 
             ...action.response
         }
    }
    
    return state
}