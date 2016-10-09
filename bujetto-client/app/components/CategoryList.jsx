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

        console.log('refreshing ' + which + ' list state: ' + data.length);

        this.setState({
            data: data
        });
    }

    render(){
        const categories = this.state.data;

        return (
            <div>
                <h1>Categories</h1>
                <div className="list-group">
                    {categories.map(cat =>{
                        return <CategoryListItem
                            key={cat.id}
                            data={cat}
                            disableSelected={this.props.disableSelected}
                            onClick={this.onClick}
                        />
                    })}
                </div>
            </div>
        )
    }
}