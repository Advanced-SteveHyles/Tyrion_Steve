import React from 'react'
import { Link } from 'react-router'
import { connect } from 'react-redux'
import { updateMatterReference } from '../selectedMatter/actions'
import { getDebts } from './actions'
import selector from './selectors'
import * as Routes from '../routes'
import Loading from '../components/Loading'
import Error from '../components/Error'
import {ASCENDING, NONSORTING, SORTING} from '../sortedTable/actions'

import SortableTable from '../sortedTable/component'
import SortableTableRow from '../sortedTable/SortableTableRow'


const FindDebts = React.createClass({
	render: function () {
		const { results, dispatch, loading, error } = this.props

		return (
			<div>
				<Link to={Routes.planets}>Planets</Link>

				{ Search(dispatch,loading) }
				<SortableTable id="debtresults" dispatch={dispatch} results={results} loading={loading} error={error} > 
					<SortableTableRow id="Reference" value={(x) => x.reference} sortable={SORTING}/>
					<SortableTableRow id="Description" value={(x) => x.description} sortable={SORTING}/>
					<SortableTableRow id="Debtor Reference" value={(x) => x.ourReference} sortable={SORTING}/>
					<SortableTableRow id="Summary"  sortable={NONSORTING} value={(x) => 
						<Link onClick={() => dispatch(updateMatterReference(x.reference))} to={Routes.summary}>Summary</Link>
					}/>
					<SortableTableRow id="Ledger"  sortable={NONSORTING} value={(x) => 
						<Link onClick={() => dispatch(updateMatterReference(x.reference))} to={Routes.ledger}>Ledger</Link>
					}/>
					<SortableTableRow id="Documents"  sortable={NONSORTING} value={(x) => 
						<Link onClick={() => dispatch(updateMatterReference(x.reference))} to={Routes.documents}>Documents</Link>
					}/>
				</SortableTable>
				
			</div>

			
		)
	}
})

const Search = (dispatch,loading) => {
		return <div className="container-fluid">
			<form className="form-inline" onSubmit={e =>SearchForDebts(e, loading, dispatch)}>
				<div className="input-group col-xs-6 searchMargin">
					<input type="text" id="searchClientMatter" className="form-control"/>
					<span className="input-group-btn">
						<button type="submit" className="btn btn-primary" disabled={loading} >
							{loading ? 'Searching...' : 'Search'}
						</button>
					</span>
				</div>
			</form>
		</div>
	}

const SearchForDebts = (e, loading, dispatch) => {
	e.preventDefault()
	 if (loading) return
	const searchString = document.getElementById("searchClientMatter").value
	dispatch(getDebts(searchString))
}

export default connect(selector)(FindDebts)