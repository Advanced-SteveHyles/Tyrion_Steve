import React from 'react'
import { connect } from 'react-redux'
import moment from 'moment'

import { get } from './actions'
import selector from './selectors'

import Loading from '../components/Loading'
import Error from '../components/Error'

const SummaryMatter = React.createClass({
    componentWillMount: function () {
        this.props.dispatch(get())
    },

    render: function () {
        if (this.props.loading)
            return Loading()

        if (this.props.error)
            return Error(this.props.error)
    
        return (
            <section>
                <div><label>Matter Number</label> {this.props.reference}</div>
                <div><label>Matter Description</label> {this.props.description}</div>
                <div><label>File Open Date</label> {moment(this.props.openDate).format('LL') }</div>
                <div><label>Claim Number</label> {this.props.debt.claimNumber}</div>
                <div><label>Date of Service</label> {moment(this.props.debt.dateOfService).format('LL') }</div>

                <div><label>Case Manager</label>
                {this.props.feeEarner.url && this.props.feeEarner.url.value !== ""
                    ? <a href={this.props.feeEarner.url.value} target="_blank">{this.props.feeEarner.name}</a>
                    : <span>{this.props.feeEarner.name}</span>
                }
                </div>

                <div><label>Supervisor</label>
                {this.props.supervisor.url && this.props.supervisor.url.value !== "" 
                        ? <a href={this.props.supervisor.url.value} target="_blank">{this.props.supervisor.name}</a> 
                        : <span>{this.props.supervisor.name}</span> 
                }
                </div>
            
            </section>
        );
    }
});

export default connect(selector)(SummaryMatter)