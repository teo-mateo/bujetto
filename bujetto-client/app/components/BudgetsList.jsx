import React from 'react'
import axios from 'axios'

export default class BudgetsList extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            budgets: []
        }
    }

    componentWillMount(){
        axios({
            url:this.props.url,
            method:'get',
            responseType:'json'
        }).then(function(response){
            this.setState({
                budgets: response.data
            })
        }.bind(this));
    }

    render(){
        return (
            <div>
            <h3>List of budgets</h3>
            {this.state.budgets.map(budget =>
                (
                    <div key={budget.id}>{budget.name}</div>
                )
            )}
            </div>
        );
    }
}