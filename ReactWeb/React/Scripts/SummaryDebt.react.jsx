var SummaryDebt = React.createClass({
  render: function() {
    
    return (
        <section>
          <div><label>Original Debt</label> £643.21</div>
          <div><label>Our Fees</label> £10.00</div>
          <div><label>Recoverable Fees</label> £0.00</div>
          <div><label>Interest</label> £95.13</div>
          <div><label>Disbursements</label> £0.00</div>
          <div><label>Recoverable Disbursements</label> £0.00</div>
          <div><label>Paid</label> £635.00</div>
          <div><label>Current Balance</label> £8.21</div>
        </section>
    );
  }
});