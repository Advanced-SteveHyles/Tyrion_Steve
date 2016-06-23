import { FETCH_SUMMARYNEXTACTION_REQUEST, FETCH_SUMMARYNEXTACTION_SUCCESS, FETCH_SUMMARYNEXTACTION_FAILURE } from './actions'

const initialState = { milestones: [] }

export default function update (state =  initialState, action)
{
    if (action.type === FETCH_SUMMARYNEXTACTION_REQUEST)
    {
        return { ...initialState, loading: true }
    }
    if (action.type === FETCH_SUMMARYNEXTACTION_FAILURE)
    {
        return { ...initialState, error: action.error }
    }
    if (action.type === FETCH_SUMMARYNEXTACTION_SUCCESS)
    {
        return { 
            ...action.response
         }
    }
    
    return state
}