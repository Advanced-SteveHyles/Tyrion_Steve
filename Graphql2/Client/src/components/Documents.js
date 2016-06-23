import React, { Component } from 'react'

var items = {
	"data": [
		{ "docName": "Initial Instruction.docx", "dateCreated": "09/11/2007" },
		{ "docName": "Bacs Receipt.docx", "dateCreated": "21/01/2008" },
		{ "docName": "Offer.pdf", "dateCreated": "21/02/2008" },
		{ "docName": "Current Account.xls", "dateCreated": "21/03/2008" }
	]
};

var Row = React.createClass({
	render() {
		var item = this.props.item;
		return <tr key={item.date} >
			<td>{item.dateCreated}</td>
			<td>{item.docName}</td>
			<td><a href="#">Download</a></td>
		</tr>
	}
});

class Documents extends Component {
	render() {
		return (
			<div>
				<h2>Documents</h2>
				<table className="table table-striped table-hover">
					<thead>
						<tr>
							<th>Date Created</th>
							<th>Name</th>
							<th>Download</th>
						</tr>
					</thead>
					<tbody>
						{items.data.map(function (item) {
							return <Row key={item.docName} item={item} />
						}) }
					</tbody>
				</table>
			</div>
		)
	}
}

export default Documents