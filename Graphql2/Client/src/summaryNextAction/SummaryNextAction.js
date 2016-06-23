import React from 'react'
import { connect } from 'react-redux'
import moment from 'moment'

import { fetchSummaryNextActionIfNeeded } from './actions'
import selector from './selectors'

import Loading from '../components/Loading'
import Error from '../components/Error'

const SummaryNextAction = React.createClass({
    componentWillMount: function () {
        this.props.dispatch(fetchSummaryNextActionIfNeeded())
    },

    render: function () {
        if (this.props.loading)
            return Loading()

        if (this.props.error)
            return Error(this.props.error)

        return (
            <ul>
                { this.props.milestones.map(function (milestone) {
                    return (

                        <li key={ milestone.mileStoneName }>
                            <h3> { milestone.mileStoneName }</h3>
                            <ul>
                                { milestone.actions.map(function (action) {
                                    return (
                                        <li key={ action.taskName }>
                                            { action.taskName }
                                            <br/>
                                            Due by: { moment(action.dueBy).format('LL') }
                                        </li>
                                    )
                                })}
                            </ul>
                        </li>

                    )
                }) }
            </ul>
        );
    }
});

const Action = item => {
    return (<div key={item.description}><div><label>Action</label> {item.description}</div>
        <div><label>Date</label> {moment(item.dueByDate).format('LL') }</div></div>)

}

export default connect(selector)(SummaryNextAction)