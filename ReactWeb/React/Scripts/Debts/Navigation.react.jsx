var Navigation = React.createClass({
  render: function() {
    return (
      <ul className="nav nav-pills">
        <li role="presentation" className="active"><a href="#">Summary</a></li>
        <li role="presentation"><a href="#">Ledger</a></li>
        <li role="presentation"><a href="#">Reports</a></li>
      </ul>
    );
  }
});