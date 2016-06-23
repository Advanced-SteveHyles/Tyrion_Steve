import React from 'react'
import { Link } from 'react-router'
import { connect } from 'react-redux'
import { updateMatterReference } from '../selectedMatter/actions'
// import { getDebts } from './actions'
import selector from './selectors'
import * as Routes from '../routes'
import Loading from '../components/Loading'
import Error from '../components/Error'

import { SortBy, ASCENDING, DESCENDING, NONSORTING, SORTING } from './actions'



const SortableTable = React.createClass({
    componentWillMount: function() {
        
    },
	render: function () {
		const { results, dispatch, loading, error, sortedTable } = this.props
        
	if (loading) return Loading()
	if (error) return Error(error)
	if (!results) return <p className="text-center">Please search for something</p>

        const columns = (this.props.children) // row tags exist?
            ? this.props.children.map((row) => { 
                return ({ 
                    header: row.props.id, 
                    sortable: row.props.sortable,
                    direction: (row.props.direction) 
                        ? row.props.direction 
                        : ASCENDING, // no direction specified in tag
                    row: (row.props.children)  // content specified within tagbody?
                        ? () => row.props.children 
                        : (row.props.value) // no tagbody for row, try 'row' attribute
                            ? row.props.value 
                            : "-" })}) // no content for column
            : (this.props.columns) // no row tags default to 'columns' passed in
                ? this.props.columns
                : [] // must be a stub of the tabletag. 
                

    const sortedResults = SortResults(sortedTable, columns, results)

	return (
        <div>
		<table className="table table-striped table-hover">
			<thead>
				<tr>
                {
                    columns.map(h => Header(h, dispatch, sortedTable, results))
                }
				</tr>
			</thead>
			<tbody>
            {
                TableRows(sortedResults, dispatch, (row) => row.reference, columns.map(c => c.row))
            }
			</tbody>
		</table>
        </div>
	)
}})

const isUnique = (value, index, self) => self.indexOf(value) === index

const isSortable = (results, col) => {
    return !(col.sortable == NONSORTING);
} 

const SortResults = (column, columns, results)   => {
    if (!column || !column.header) return results
    const sortColumn = columns.find((x) => x.header === column.header)
    const sortitemFunc = sortColumn.row
    const sortitemdirection = (column.direction) ? column.direction : ASCENDING

    const sortFunc = (a, b) => {
        if(sortitemFunc(a) > sortitemFunc(b)) return -1 * sortitemdirection
        if(sortitemFunc(b) > sortitemFunc(a)) return 1 * sortitemdirection
        return 0;
    }

    return results.sort(sortFunc)
}

const Header = (col, dispatch, currentSortCol, results) => {
    const newcol = {...col, direction: (currentSortCol && currentSortCol.direction) ? currentSortCol.direction * -1 : ASCENDING}
    return (isSortable(results, newcol)) ? SortableHeader(newcol, dispatch, currentSortCol) : UnsortableHeader(newcol, dispatch, currentSortCol)
}

const SortableHeader = (col, dispatch, currentSortCol) => {
    return(<th><a onClick={() => dispatch(SortBy(col))}>{col.header}↕</a></th>)
}

const UnsortableHeader = (col, dispatch, currentSortCol) => {
    return(<th>{col.header}</th>)
}

const TableRows = (results, dispatch, key, rows) => {
	if (results.length == 0) return NoResultsFound()

	return results.map(function (item) {
		return TableRow(item, dispatch, key, rows)
	})
}

const NoResultsFound = () => {
	return <tr><td colSpan="4" className="text-center">No results found</td></tr>
}

const TableRow = (item, dispatch, key, columns) => {
    return (<tr>
        {columns.map((col) => TableColumn(col(item)))}
    </tr>)
}

const TableColumn = (colval) => {
    return <td>{colval}</td>
}

export default connect(selector)(SortableTable)