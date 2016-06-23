
import React, { Component } from 'react'
import Navbar from './Navbar'

class App extends Component {
    render() {
        return (
            <div>
                <div>
                    {this.props.children}
                </div>
                <footer className="text-center">
                    &copy; One Advanced - Team Krakenface&reg; 2016
                </footer>
            </div>
        )
    }
};

export default App