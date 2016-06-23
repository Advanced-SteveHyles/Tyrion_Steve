import { APP_INIT } from '../appInit'
import {
  LOGIN_SUCCESS, LOGIN_FAILURE, LOGOUT, USERNAME_ASSIGNED
} from '../auth/actions'

const TOKEN_STORAGE_KEY = 'debtsToken'
const USERNAME_STORAGE_KEY = 'debtsCurrentUser'

export default () => next => action => {
  switch (action.type) {
    case APP_INIT: {
      let token = localStorage.getItem(TOKEN_STORAGE_KEY)
      if (token)
        next({ type: LOGIN_SUCCESS, response: JSON.parse(token) })
        
      let username = localStorage.getItem(USERNAME_STORAGE_KEY)
      if (username)
        next({ type: USERNAME_ASSIGNED, username: username })        
      
      break
    }

    case LOGIN_SUCCESS: {
      let token = action.response
      localStorage.setItem(TOKEN_STORAGE_KEY, JSON.stringify(token))
      break
    }

    case LOGIN_FAILURE:
    case LOGOUT:
      localStorage.removeItem(TOKEN_STORAGE_KEY)
      localStorage.removeItem(USERNAME_STORAGE_KEY)
      break
      
    case USERNAME_ASSIGNED: {
      let username = action.username
      localStorage.setItem(USERNAME_STORAGE_KEY, username)
      break
    }
    
  }
  next(action)
}
