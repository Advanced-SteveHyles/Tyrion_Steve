import React from 'react'
import { connect } from 'react-redux'

import { fetchPlanetsIfNeeded } from './actions'
import selector from './selectors'


import Loading from '../components/Loading'
import Error from '../components/Error'


const SummaryPlanets = React.createClass({
    componentWillMount: function () {
        this.props.dispatch(fetchPlanetsIfNeeded)
    },

	render: function () {
        
        if (this.props.loading)
                return Loading()

        if (this.props.error)
                return Error(this.props.error)

                
        return (
            <div>            
                <h1>Planets</h1>

                <ul>

                {this.props.planetList.map(function(planet) {
                    <li key={planet.name}>{planet.name}</li>                
                }
                )
                }
                                    
                </ul>           

                <h1>End Of Planets</h1>     
             </div>
        )
}
}
)

export default connect(selector)(SummaryPlanets)