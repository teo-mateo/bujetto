import React from 'react'
import CategoryList from './CategoryList'
import axios from 'axios';

export default class CategoryPicker extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            all: [],
            selected: []
        };

        console.log('CategoryPicker .ctor: all: ' + this.state.all.length);

        this.select = this.select.bind(this);
        this.deselect = this.deselect.bind(this);
    }

    componentWillMount(){
        axios({
            url: 'http://localhost:56665/api/expensecategories',
            timeout: 20000,
            method: 'get',
            responseType: 'json'
        }).then(function(response){

            const all = response.data.map(c => {
                c['selected'] = Math.random() >= 0.5;
                return c;
            });
            const selected = all.filter(c=>c.selected);

            this.setState({all, selected});
            this.refreshState();

        }.bind(this));

    }

    select(id){
        const category = this.state.all.find(c=>c.id === id);
        category.selected = true;
        console.log(category.id + " selected");
        this.refreshState();
    }

    deselect(id){
        const category = this.state.all.find(c=>c.id === id);
        category.selected = false;
        console.log(category.id + " deselected");
        this.refreshState();
    }

    refreshState(){
        const all = this.state.all;
        const selected = all.filter(c=>c.selected);
        const newState = {all, selected};

        this.setState(newState);

        this.refs.leftSide.refreshList('left', all);
        this.refs.rightSide.refreshList('right', selected);
    }

    render(){
        return (
            <div>
                <div className="row">
                    <div className="col-sm-6">
                        <CategoryList
                            data={this.state.all}
                            disableSelected={true}
                            onClick={this.select}
                            ref="leftSide"
                            title="Available"/>
                    </div>
                    <div className="col-sm-6">
                        <CategoryList
                            data={this.state.selected}
                            disableSelected={false}
                            onClick={this.deselect}
                            ref="rightSide"
                            title="Selected"/>
                    </div>
                    <button>OK</button>
                </div>

            </div>
        )
    }
}