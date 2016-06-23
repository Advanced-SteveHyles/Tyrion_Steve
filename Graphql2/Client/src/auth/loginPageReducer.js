import {
  LOGIN_REQUEST, LOGIN_SUCCESS, LOGIN_FAILURE
} from './actions'

const initialState = {
  pending: false,
  error: false
}

export default (state=initialState, action) => {
  switch (action.type) {

    case LOGIN_REQUEST:
      return {
        ...state,
        pending: true,
        error: null
      }

    case LOGIN_SUCCESS:
    // case LOGOUT:
      return {
        ...state,
        pending: false,
        error: null
      }

    case LOGIN_FAILURE:
      return {
        ...state,
        pending: false,
        error: action.error
      }

    default:
      return state
  }
}


