import React, { Component } from 'react'

var items = {"data": [
				{ "date": "09/11/2007", "narrative": "Claim Fee", "officeDebit": 85, "officeCredit" : 0, "clientDebit" :0, "clientCredit" :0  },								
                { "date": "21/01/2008", "narrative": "Writ Of Fi Fa fee", "officeDebit": 50, "officeCredit" : 0, "clientDebit" :0, "clientCredit" :0  }
			]};

var Row = React.createClass({
	render() {
		var item = this.props.item;
		return <tr key={item.date} >
					<td>{item.date}</td>
					<td>{item.narrative}</td>
					<td>£{item.officeDebit.toFixed(2)}</td>
					<td>£{item.officeCredit.toFixed(2)}</td>
					<td>£{item.clientDebit.toFixed(2)}</td>
					<td>£{item.clientCredit.toFixed(2)}</td>                                        
				</tr>
	}
});

class Ledger extends Component {
	render() { 
		return (
			<div>
				<h2>Ledger Entries</h2>
				<table className="table table-striped table-hover">
					<thead>
						<tr>
							<th>Date Posted</th>
							<th>Narrative</th>
							<th>Office DR</th>
							<th>Office CR</th>
							<th>Client DR</th>
							<th>Client CR</th>
						</tr>
					</thead>
					<tbody>
						{items.data.map(function (item) {
							return <Row key={item.date} item={item} />
						}) }
					</tbody>
				</table>
			</div>
		)
	}
}

export default Ledger