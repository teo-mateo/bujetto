import React from 'react'
import CategoryListItem from './CategoryListItem'

export default class CategoryList extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            data: this.props.data
        };

        this.onClick = this.onClick.bind(this);
        this.refreshList = this.refreshList.bind(this);
    }

    onClick(id){
        this.props.onClick(id);
    }

    refreshList(which, data){

        this.setState({
            data: data
        });
    }

    render(){
        return (
            <div>
                <h4>{this.props.title}</h4>
                {(this.state.data.length === 0) ? (
                   <span>Nothing selected</span>
                ) : (
                    <div className="list-group">
                        {this.state.data.map(cat =>{
                            return <CategoryListItem
                                key={cat.id}
                                data={cat}
                                disableSelected={this.props.disableSelected}
                                onClick={this.onClick}
                            />
                        })}
                    </div>
                )}

            </div>
        )
    }
}