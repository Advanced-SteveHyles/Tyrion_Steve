// var jQuery = require('jquery')
// window.jQuery = jQuery
// window.$ = jQuery
// require('bootstrap')

import React, { Component } from 'react'
import { Link } from 'react-router'
import * as Routes from '../routes'

class Navbar extends Component {
   render() {
       return (
           <nav className="navbar navbar-default">
                <div className="container-fluid">
                    <div className="navbar-header">
                        <button type="button" className="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span className="sr-only">Toggle navigation</span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                        </button>
                        <a className="navbar-brand" href="#">Smith Partnership</a>
                    </div>

                    <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul className="nav navbar-nav">
                            <li><Link to={Routes.root}>Debts</Link></li>
                            <li><Link to={Routes.login}>Login/Logout</Link></li>
                        </ul>
                    </div>                
                </div>
            </nav>
       );
   } 
}

export default Navbar