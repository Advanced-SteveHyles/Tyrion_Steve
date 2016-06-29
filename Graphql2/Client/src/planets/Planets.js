import React from 'react'
import { connect } from 'react-redux'
import selector from './selectors'
import { fetchPlanetsIfNeeded } from './actions'

const Planets = React.createClass({

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
                <h1>Planet</h1>

                <ul>

                {this.props.planetList.map(function(planet) {
                    <li key={planet.name}>{planet.name}</li>                
                }
                )
                }

                    
                </ul>
                

             </div>
        )
}
}
)

export default connect(selector)(Planets)