import React, {Component} from 'react'
import { render } from 'react-dom'
import { Router, Route, Link, hashHistory} from 'react-router'
import Layout from './Layout'
import Budgets from './Budgets'
import Expenses from './Expenses'
import TwoListsSelector from './TwoListsSelector'

export default class App extends Component{
    constructor(props){
        super(props)
    }

    render(){
        return(
            <Router history={hashHistory}>
                <Route path="/" component={Layout}>
                    <Route path="budgets" component={Budgets} />
                    <Route path="budgets/:budgetid" component={TwoListsSelector} />
                    <Route path="expenses" component={Expenses} />
                    {/*

                     <Route path="about" component={About} />
                     <Route path="inbox" component={Inbox}>
                     <Route path="messages/:id" component={Message} />
                     </Route>

                     */}
                </Route>
            </Router>
        );
    }
}
