import React, { Component } from 'react'

class Panel extends Component {
  render() {
    return (
      <div className= "col-md-4">
        <div className="panel panel-default">
          {Title(this.props.title) }
          <div className="panel-body">
            {this.props.children}
          </div>
        </div>
      </div>
    );
  }
}

const Title = (titleName) => {
  if (!titleName)
    return

  return (
    <div className="panel-heading">
      <h3 className="panel-title">
        {titleName}
      </h3>
    </div>
  )
}

export default Panel