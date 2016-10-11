import React, {Component} from 'react'
import ListItem from './ListItem'
import CategoryDTO from './Models/CategoryDTO'

export default class List extends Component {
    constructor(props){
        super(props);
    }

    render() {
        return (
            <ul>
                {this.props.items.map((item) =>
                    <ListItem key={item.id} item={item} callback={this.props.callback}></ListItem>
                )}
            </ul>
        )
    }
}

List.propTypes = {
    items: React.PropTypes.array.isRequired
};
