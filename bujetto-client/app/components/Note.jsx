import React from 'react';

export default class Note extends React.Component {
    constructor(props){
        super(props);

        //Track 'editing' state
        this.state = {
            editing: false
        };

        this.renderEdit = this.renderEdit.bind(this);
        this.renderNote = this.renderNote.bind(this);
        this.renderDelete = this.renderDelete.bind(this);
        this.edit = this.edit.bind(this);
        this.checkEnter = this.checkEnter.bind(this);
        this.finishEdit = this.finishEdit.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    render() {
        //Render the component differently based on state
        if(this.state.editing){
            return this.renderEdit();
        } else {
            return this.renderNote();
        }
    }

    renderEdit() {
        return (
            <input type="text"
                   autoFocus={true}
                   defaultValue={this.props.task}
                   onBlur={this.finishEdit}
                   onKeyPress={this.checkEnter} />
        );
    };

    renderDelete(){
        return (
            <button className="delete-note" onClick={this.props.onDelete} >x</button>
        );
    }

    renderNote() {
        const onDelete = this.props.onDelete;

        // if the user clicks a normal note, trigger editing logic
        return (
            <div onClick={this.edit}>
                <span className="task">{this.props.task}</span>
                {onDelete ? this.renderDelete() : null }
            </div>
        );
    };

    edit() {
        //enter edit mode
        this.setState({
            editing: true
        });
    };

    onDelete(){

    }

    checkEnter(e) {
        // the user hit *enter*, let's finish up.
        if(e.key === "Enter"){
            this.finishEdit(e);
        }
    };

    finishEdit(e) {
        // *Note* will trigger an *onEdit* callback once it has a new value.
        // we will use this to communicate change to *App*

        const value = e.target.value;
        if(this.props.onEdit) {
            this.props.onEdit(value);
        }

        //Exit edit mode
        this.setState({
            editing: false
        });
    }
}
