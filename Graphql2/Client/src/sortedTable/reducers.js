import {TABLE_SORT} from './actions'

const initialState = { }

export default function update (state =  initialState, action) {
    if (action.type === TABLE_SORT){
        console.log(action)
        return { table: action.table, header: action.header, row: action.row, direction: action.direction }
    }
    return state;
}