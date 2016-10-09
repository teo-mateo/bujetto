import React from 'react'
import CategoryList from './CategoryList'

export default class CategoryPicker extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            all: this.props.data,
            selected: this.props.data.filter(c=>c.selected)
        };

        console.log('CategoryPicker .ctor: all: ' + this.state.all.length);

        this.select = this.select.bind(this);
        this.deselect = this.deselect.bind(this);
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
        const all = this.state.all;
        const selected = this.state.selected;
        return (
            <div className="row">
                <div className="col-sm-6">
                    <CategoryList
                        data={all}
                        disableSelected={true}
                        onClick={this.select}
                        ref="leftSide"/>
                </div>
                <div className="col-sm-6">
                    <CategoryList
                        data={selected}
                        disableSelected={false}
                        onClick={this.deselect}
                        ref="rightSide"/>
                </div>

            </div>
        )
    }
}