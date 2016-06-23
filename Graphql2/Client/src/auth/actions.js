import { AUTH_CALL } from '../middleware/authapi'

export const LOGIN_REQUEST = 'LOGIN_REQUEST'
export const LOGIN_SUCCESS = 'LOGIN_SUCCESS'
export const LOGIN_FAILURE = 'LOGIN_FAILURE'
export const USERNAME_ASSIGNED = 'USERNAME_ASSIGNED'

export const login = (username, password) => ({
  type: AUTH_CALL,
  endpoint: DEBTSAUTHURI,
  method: 'post',
  headers: {
      "Accept": "application/json",
      "Content-Type": "application/x-www-form-urlencoded"
  },
  body: {
    username: username,
    password: password,
    grant_type: 'password'
  },
  onRequest: LOGIN_REQUEST,
  onSuccess: LOGIN_SUCCESS,
  onFailure: LOGIN_FAILURE
})

export const LOGOUT = 'LOGOUT'

export const logout = () => ({
  type: LOGOUT
})

export const usernameAssigned = (username) => ({
  type: USERNAME_ASSIGNED,
  username: username
})