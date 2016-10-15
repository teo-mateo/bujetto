import React from 'react'
import CategoryPicker from './CategoryPicker'
import BudgetsList from './BudgetsList'

export default class TheApp extends React.Component {

    constructor(props) {
        super(props);

    };


    render() {
        return (
            <div>
                <div className="row col-sm-6">
                    <BudgetsList url="http://localhost:56665/api/users/1/budgets"/>
                </div>
                <div className="row col-sm-6">
                    <CategoryPicker url='http://localhost:56665/api/expensecategories' />
                </div>
            </div>

        )

    }
}