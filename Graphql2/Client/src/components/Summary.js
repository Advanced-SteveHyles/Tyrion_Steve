import React from 'react'
import SummaryHeader from '../summaryHeader/SummaryHeader'
import SummaryMatter from '../summaryMatter/SummaryMatter'
import SummaryLedger from '../summaryLedger/SummaryLedger'
import Panel from './Panel'
import SummaryNextAction from '../summaryNextAction/SummaryNextAction'

export default function Summary() {

  return (
    <div className="container-fluid">
      <SummaryHeader/>
      <div className="row">
        <Panel title="Milestones and actions">
          <SummaryNextAction/>
        </Panel>
        <Panel title="Debt Details">
          <SummaryLedger/>
        </Panel>
        <Panel title="Matter Details">
          <SummaryMatter/>
        </Panel>
      </div>
    </div>
  );
}