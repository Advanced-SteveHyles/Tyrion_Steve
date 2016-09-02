import {
  LOGIN_SUCCESS, LOGIN_FAILURE, LOGOUT
} from './actions'

const initialState = { token: null}

export default (state=initialState, action) => {
  switch (action.type) {
    case LOGIN_SUCCESS:
      return action.response

    case LOGIN_FAILURE:
    case LOGOUT:
      return initialState

    default:
      return state
  }
}
