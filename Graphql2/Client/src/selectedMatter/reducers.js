import { SET_MATTER_REFERENCE } from './actions'

const initialState = {reference: ""}

export default function update (state =  initialState, action)
{
    if (action.type === SET_MATTER_REFERENCE)
    {
        return {reference:  action.reference}
    }

    return state
}