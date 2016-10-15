import React, {Component} from 'react'
import List from './List'
import axios from 'axios'
import CategoryDTO from './Models/CategoryDTO'
import { Router, RouterContext, Link, browserHistory } from 'react-router';
import Config from 'Config'

export default class TwoListsSelector extends Component{
    constructor(props){
        super(props);

        this.state = {
            categories: [
                new CategoryDTO(0, "loading", true)
            ]
        };

        this.changeSelectionCallback = this.changeSelectionCallback.bind(this);
        this.onSaveCLick = this.onSaveCLick.bind(this);
        this.onGoBackClick = this.onGoBackClick.bind(this);

        this.budgetid = this.props.routeParams.budgetid;

        this.URL = {
            getbudget: `${Config.serverUrl}/api/budgets/${this.budgetid}`,
            getallcategories: `${Config.serverUrl}/api/expensecategories`,
            savebudgetcategories: `${Config.serverUrl}/api/budgets/${this.budgetid}/setcategories`
        };

    }


    componentWillMount(){

        const URL = this.URL;

        const update = function(s){
            this.setState(s);
        }.bind(this);

        axios.all([
            axios.get(URL.getallcategories),
            axios.get(URL.getbudget)
        ]).then(axios.spread(function(categories, budget){
            const newState = {
                categories: categories.data.map(
                    c =>
                        new CategoryDTO(
                            c.id,
                            c.name,
                            budget.data.categories.some(function(c2){
                                return c2.id === c.id;
                            }))
                )
            };
            update(newState);
        }));
    }

    changeSelectionCallback (id) {
        const categories = this.state.categories;
        var category = this.state.categories.find(c => c.id == id);
        category.selected = !category.selected;
        this.setState(categories);
    };

    onSaveCLick(evt){
        const URL = this.URL;
        const categories = this.state.categories
            .filter(c=>c.selected)
            .map(c=>{
                return {id:c.id};
            });

        axios.post(
            URL.savebudgetcategories,
            categories);
    }

    onGoBackClick(evt){
        evt.preventDefault();
        Router.History.back()
    }

    render(){

        const selected = this.state.categories.filter(c=>c.selected);
        const available = this.state.categories.filter(c=>!c.selected);
        return (
          <div>
              <div className="row">
                  <div className="col-sm-4">
                      <h2>Available</h2>
                      <List items={available} callback={this.changeSelectionCallback}/>
                  </div>

                  <div className="col-sm-4">
                      <h2>Selected</h2>
                      <List items={selected} callback={this.changeSelectionCallback}/>
                  </div>
              </div>
              <div className="row">
                  <div className="col-sm-4">
                      <button className="btn btn-default form-control" onClick={this.onSaveCLick}>Save</button>
                  </div>
              </div>
              <div className="row">
                  <div className="col-sm-4">
                      <Link className="col-sm-4 col-sm-offset-4" to="budgets">Back
                      </Link>
                  </div>
              </div>
          </div>
        );
    }
}


