import React from 'react'
import { connect } from 'react-redux'

import { fetchHeaderIfNeeded } from './actions'
import selector from './selectors'

import Loading from '../components/Loading'
import Error from '../components/Error'

const SummaryHeader = React.createClass({
    componentWillMount: function() {
        this.props.dispatch(fetchHeaderIfNeeded())
    },    
    render: function () {
    if (this.props.loading)
      return Loading()

    if (this.props.error)
      // return Error(this.props.error)
      return Error("Unable to retrieve Debtor information")
      
        return (
            <header>
                <h1>
                    {this.props.debtor.name} - {this.props.description}
                </h1>
            </header>
        );
    }
});

export default connect(selector)(SummaryHeader)