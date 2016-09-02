import React from 'react'
import { connect } from 'react-redux'
import { hashHistory } from 'react-router'
import { login, logout, usernameAssigned } from './actions'

const mapStateToProps = (state) => ({
    isAuthenticated: state.loggedInUser.token !== null,
    login: state.login
})


const LoginPage = React.createClass({
  componentWillMount: function () {
    this.props.dispatch(logout())
  },

  componentWillReceiveProps: function (newProps) {
    if (newProps.isAuthenticated)
      hashHistory.push('/')
  },


  render: function () {
    const { dispatch, isAuthenticated } = this.props
    return (
      <div className="loginPad">
        <form className="form-signin" onSubmit={e => AuthenticateUser(e, dispatch, isAuthenticated) }>
          <h2 className="form-signin-heading">Please sign in</h2>
          <label htmlFor="username" className="sr-only">Username</label>
          <input type="text" id="username" className="form-control" placeholder="Username" required="" autoFocus={focus}></input>
          <label htmlFor="password" className="sr-only">Password</label>
          <input type="password" id="password" className="form-control" placeholder="Password" required=""></input>
          <button className="btn btn-lg btn-primary btn-block" type="submit" id="login">Sign in</button>
          
          <div className='form-group topMargin'>
            <div>
              {
                this.props.login.error ? (<div id="loginErrorText" className="alert alert-danger">{this.props.login.error}</div>) : null
              }
            </div>
          </div>
        </form>
        
      </div>
    )
  }
});

const AuthenticateUser = (e, dispatch, isAuthenticated) => {
  e.preventDefault()
  const username = document.getElementById("username").value
  const password = document.getElementById("password").value
  if (!isAuthenticated)
    dispatch(login(username, password))
}

export default connect(mapStateToProps)(LoginPage)