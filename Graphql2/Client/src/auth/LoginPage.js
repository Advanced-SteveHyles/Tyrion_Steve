import React from 'react'
import { connect } from 'react-redux'
import { hashHistory } from 'react-router'
import loginPageSelector from './loginPageSelector'
import { login, logout, usernameAssigned } from './actions'



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
    var colors = ['Red','Yellow','Orange'];
    return (
      <div className="sitePad">        
        <form className="form-signin" onSubmit={e => AuthenticateUser(e, dispatch, isAuthenticated) }>
        <h2>TextBefore</h2>
        <DropdownList data={colors}> 
        </DropdownList>
        <h1>TextAfter</h1>

          <h2 className="form-signin-heading">Please sign in</h2>
          <label for="username" className="sr-only">Username</label>
          <input type="text" id="username" className="form-control" placeholder="Username" required="" autofocus=""></input>
          <label for="password" className="sr-only">Password</label>
          <input type="password" id="password" className="form-control" placeholder="Password" required=""></input>
          <div className="checkbox">
            <label>
              <input type="checkbox" value="remember-me"/> Remember me
            </label>
          </div>
          <button className="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
          
          <div className='form-group topMargin'>
            <div>
              {
                this.props.error ? (<div className="alert alert-danger">{this.props.error}</div>) : null
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
  if (username) 
    dispatch(usernameAssigned(username))
}

export default connect(loginPageSelector)(LoginPage)