import React from 'react'
import { connect } from 'react-redux'

import { fetchSummaryLedgerIfNeeded } from './actions'
import selector from './selectors'

import Loading from '../components/Loading'
import Error from '../components/Error'

const SummaryLedger = React.createClass({
  componentWillMount: function () {
    this.props.dispatch(fetchSummaryLedgerIfNeeded())
  },

  render: function () {
    if (this.props.loading)
      return Loading()

    if (this.props.error)
      return Error(this.props.error)
      
    return (
      <section>
        <div><label>Original Debt</label> £{this.props.debt.originalDebt}</div>
        <div><label>Our Fees</label> £{this.props.debt.totalCosts}</div>
        <div><label>Interest</label> £{this.props.debt.interest}</div>
        <div><label>Disbursements</label> £{this.props.debt.disbursements}</div>
        <div><label>Paid</label> £{this.props.debt.paidToDate}</div>
        <div><label>Current Balance</label> £{this.props.debt.currentBalance}</div>
      </section>
    );
  }
});

export default connect(selector)(SummaryLedger)