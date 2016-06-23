import React from 'react'

// This is a stub class to contain the things necessary for the SortableTable
// it expects an 'id' attribute : this will be the header of the table.
// a 'direction' attribute is optional ( ASCENDING = 1, DESCENDING = -1 )
// if no child tags are available then it will render the 'row' attribute which is a 1 parameter function, 
// with the parameter being the row.

class SortableTableRow extends React.Component {
    render(){ return (<div></div>) }
}

export default SortableTableRow