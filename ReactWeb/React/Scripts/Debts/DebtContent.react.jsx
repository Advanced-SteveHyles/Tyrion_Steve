var DebtContent = React.createClass({
  render: function() {
    
    return (
      <div className="container-fluid">
        <div className="row">
          <Panel title="Matter Details">
            <SummaryMatter/>
          </Panel>
          <Panel title="Debt Details">
            <SummaryDebt/>
          </Panel>
          <Panel title="Next Action">
            <NextAction/>
          </Panel>
        </div>
      </div>
    );
    
  }
});