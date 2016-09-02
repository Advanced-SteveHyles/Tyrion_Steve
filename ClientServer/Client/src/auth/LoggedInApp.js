import React from 'react'
import { connect } from 'react-redux'
import { hashHistory } from 'react-router'
//import Navbar from '../Navbar/Navbar'

const mapStateToProps = (state) => ({
    isAuthenticated: state.loggedInUser.token !== null
})

const LoggedInApp = React.createClass({

  componentWillMount: function () {
    if (!this.props.isAuthenticated)
      hashHistory.push('/login')
  },

  render: function () {
    return (
      <div>
        <div>
          <a href={FIRMURL} target="_blank">
            <img className="companylogostyle"></img>
          </a>
          <img className="brandlogostyle pull-right"></img>          
        </div>
        "<Navbar/>"
        <div className="sitePad">
          {this.props.children}
        </div>
      </div>
    )
  }
})

export default connect(mapStateToProps)(LoggedInApp)
