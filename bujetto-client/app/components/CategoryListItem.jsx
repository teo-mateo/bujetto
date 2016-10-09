import React from 'react'

export default class CategoryListItem extends React.Component{
    constructor(props){
        super(props);
        this.onClick = this.onClick.bind(this);

        this.state = this.props.data

    }

    onClick(){
        const data = this.props.data;
        const disabled = this.props.disableSelected && data.selected;

        if(disabled){
            return;
        }

        let category = this.props.data;
        this.props.onClick(category.id);
    }

    render(){

        const data = this.props.data;
        const disabled = this.props.disableSelected && data.selected;

        return (
            <button
                className={"list-group-item " + (disabled ? "disabled" : "")}
                key={data.id}
                onClick={this.onClick}>{data.name}</button>
        )
    }
}