import React from 'react'
import CategoryPicker from './CategoryPicker'
import Category from '../models/Category'
import axios from 'axios';

export default class TheApp extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            categories: [
                new Category(1, "Foodstuff", false, this.refresh),
                new Category(2, "Gas", false, this.refresh),
                new Category(3, "Clothes", true, this.refresh)
            ]
        };

        this.refresh.bind(this.refresh);
        this.handleIncomingCategories = this.handleIncomingCategories.bind(this);
    };

    componentWillMount(){
        axios({
            url: 'http://localhost:56665/api/expensecategories',
            timeout: 20000,
            method: 'get',
            responseType: 'json'
        }).then(function(response){
            console.log(response);
        }.bind(this));

    }

    handleIncomingCategories(response){

    }

    refresh(id) {
        const categories = this.state.categories;
        const cat = categories.find(c=>c.id ===id);
        cat.selected = !cat.selected;

        setState(new {
            categories: categories
        });
    }

    render() {
        return (
            <div>
                <CategoryPicker data={this.state.categories}/>
            </div>
        )

    }
}