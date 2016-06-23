import React from 'react'
import { connect } from 'react-redux'
import { hashHistory } from 'react-router'
import selector from './LoggedInAppSelector'

import Navbar from '../components/Navbar'

const LoggedInApp = React.createClass({

  componentWillMount: function () {
    if (!this.props.isAuthenticated)
      hashHistory.push('/login')
  },

  componentWillReceiveProps: function (newProps) {
    if (!isTokenExpired(newProps))
      hashHistory.push('/login')
  },


  render: function () {
    return (
      <div className='logged-in-app'>
        <Navbar/>
        <div className="sitePad">
          {this.props.children}
        </div>
      </div>
    )
  }
})

const isTokenExpired = (state) => {
  return {
    isAuthenticated: state.token !== null
  }
}

export default connect(selector)(LoggedInApp)
