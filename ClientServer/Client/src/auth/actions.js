import { AUTH_CALL } from '../middleware/authapi'

export const LOGIN_REQUEST = 'LOGIN_REQUEST'
export const LOGIN_SUCCESS = 'LOGIN_SUCCESS'
export const LOGIN_FAILURE = 'LOGIN_FAILURE'

export const login = (username, password) => ({
  type: AUTH_CALL,
  endpoint: AUTHURI,
  method: 'post',
  headers: {
      "Accept": "application/json",
      "Content-Type": "application/json"
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