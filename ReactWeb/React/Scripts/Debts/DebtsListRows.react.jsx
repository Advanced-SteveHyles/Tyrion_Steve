
var DebtsListRows = React.createClass({
  render: function() {
    var names = [
      { "ref": "A00001-0001", "description": "De Debt -V- Mr John Smith" }, 
      { "ref": "B00001-0001", "description": "De Debt -V- Miss Jane Jones" }, 
      { "ref": "H00001-0002", "description": "De Debt Coll -V- Mr Bob Evans" }];
      
    var namesList = names.map(function(name){
                        return <tr key={name.ref}>
                            <td>{name.ref}</td>
                            <td>{name.description}</td>
							{React.DebtsLink}{name.ref}
                          </tr>;
                      });
    return (
         <tbody>{namesList}</tbody>
    );
  }
});


var DebtsLink = React.createClass({
    render: function(link) {
        return ("<a href=" + request + link + "/>");
    }
});

