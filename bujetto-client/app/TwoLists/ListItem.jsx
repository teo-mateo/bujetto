import React, {Component} from 'react'
import {Label} from 'react-bootstrap'

export default class ListItem extends Component {
    constructor(props){
        super(props)

        this.onCategoryClick = this.onCategoryClick.bind(this);
    }

    onCategoryClick (evt) {
        evt.preventDefault();
        if(this.props.callback) {
            this.props.callback(this.props.item.id);
        }
    };

    render(){
        return (
            <li>
                <h3><Label onClick={this.onCategoryClick} bsStyle="warning" className="categ-label">{this.props.item.name}</Label></h3>
            </li>
        );
    }
}

ListItem.propTypes = {
    item: React.PropTypes.any.isRequired
};