

var DebtsList = React.createClass({
  render: function() {
    return (
      <div>
        <table className="table table-striped">
            <thead>
          <tr data-id="a00001-0001">
            <th>Reference</th>
            <th>Matter</th>
          </tr>
            </thead>
          <DebtsListRows />
          
        </table>
      </div>
    );
  }
});
