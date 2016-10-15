import React, {Component} from 'react'
import {Panel, ProgressBar, Button, Row, Col, ButtonGroup, Glyphicon} from 'react-bootstrap'
import { browserHistory, Link } from 'react-router'
import dateFormat from 'dateformat';

import EventDispatcher from './EventDispatcher'

export default class BudgetCard extends Component{
    constructor(props){
        super(props);

        this.handleEditCategories = this.handleEditCategories.bind(this);
        this.handleEditBudget = this.handleEditBudget.bind(this);
        this.handleDuplicateBudget = this.handleDuplicateBudget.bind(this);
    }

    handleEditCategories(evt){
        browserHistory.push('#/budgets/'+this.props.budget.id);
    }

    handleEditBudget(evt){
        this.Context.EventDispatcher.publish("EDIT_BUDGET", this.props.budget.id);
    }

    handleDuplicateBudget(evt){
        /*EventDispatcher.publish("DUPLICATE_BUDGET", this.props.budget.id);*/
    }


    render(){

        const badges = ["red", "blue", "fuchsia", "green", "magenta", "darkgray"];
        const badgeStyle = {
            randbackgroundColor: badges[Math.floor(Math.random() * badges.length)],
            backgroundColor: '#7DB4B5'
        };

        const model = {
            letter: this.props.budget.name[0].toUpperCase(),
            name: this.props.budget.name.substring(1),
            label: 'validity',
            value: this.props.budget.value,
            totalexpenses: this.props.budget.totalexpenses,
            pcspent: ((+this.props.budget.totalexpenses)*100)/this.props.budget.value,
            progstyle:'success'
        };

        if(model.pcspent <=50){
            model.progstyle = 'success'
        } else if (model.pcspent <=75){
            model.progstyle = 'warning';
        } else {
            model.progstyle = 'danger';
        }

        if(this.props.budget.startdate && this.props.budget.expirationdate){
            const startDate = dateFormat(new Date(this.props.budget.startdate), 'dd-MM-yyyy');
            const expirationDate = dateFormat(new Date(this.props.budget.expirationdate), 'dd/MM/yyyy');
            model['label'] = startDate + ' - ' + expirationDate;
        } else if(this.props.budget.startdate){
            const startDate = dateFormat(new Date(this.props.budget.startdate), 'dd/MM/yyyy');
            model['label'] = 'Started at: ' + startDate;
        } else if(this.props.budget.expirationdate){
            const expirationDate = dateFormat(new Date(this.props.budget.expirationdate), 'dd/MM/yyyy');
            model['label'] = 'Ends at: ' + expirationDate;
        } else {
            model['label'] = '-'
        }

        return (
            <Panel className="budgetCard">
                <span>
                    <span className="numberCircle" style={badgeStyle}>
                        <span><strong>{model.letter}</strong></span>
                    </span>
                    <span style={{fontSize: 24 + "px"}}>{model.name}</span>
                </span>
                <h4>{model.label}</h4>

                <Row>
                    <Col md={6}>
                        <ProgressBar striped bsStyle={model.progstyle} now={model.pcspent} />
                    </Col>
                    <Col md={6}><div>Spent {model.totalexpenses} € of {model.value} € </div></Col>
                </Row>


                <Link to={'budgets/'+this.props.budget.id}>Categories</Link>
                &nbsp;
                <a href="#" onClick={this.handleEditBudget}>Edit</a>
                &nbsp;
                <a href="#" onClick={this.handleDuplicateBudget}>Duplicate</a>
            </Panel>
        );
    }
}