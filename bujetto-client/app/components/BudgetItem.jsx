import React from 'react'

export default class BudgetItem extends React.Component{
    constructor(props){
        super(props)
    }

    render(){
        return(
          <div>{props.data.name}</div>
        );
    }
}