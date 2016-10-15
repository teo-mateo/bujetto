import React, {Component} from 'react'
import {Grid, Row, Col, Panel, Button} from 'react-bootstrap'
import axios from 'axios'
import BudgetCard from './BudgetCard'
import _ from 'lodash'

import EventDispatcher from './EventDispatcher'

export default class Budgets extends Component{
    constructor(props){
        super(props)

        this.state = {
            userid: 1,
            budgets: []
        };

        this.URL = {
            getuserbudgets:`http://localhost:56665/api/users/${this.state.userid}/budgets`
        };

        /*
        this.Context.EventDispatcher.listen('EDIT_BUDGET', function(args){
           console.log('heard you want to edit budget ' + args);
        });
        */

    }

    componentWillMount(){
        axios.get(this.URL.getuserbudgets)
            .then(function(response){

                const userid = this.state.userid;
                this.setState({
                    userid:userid,
                    budgets: response.data
                });
            }.bind(this));
    }

    render(){
        const items = this.state.budgets.map(x=> {
            return {
                type:'budget',
                object:x
            };
            }).slice(0);

        items.push({ type:'add-new', object: '???'});

        const cards = _.chunk(items, 3);

        return (
            <div>
            <h2>Where yo' money go and never come back</h2>
                <Grid>
                    {cards.map((chunk, i) =>{
                        return (
                            <Row key={i}>
                                {chunk.map(c =>{

                                    if(c.type==='budget') {
                                        return (
                                            <Col md={4} key={c.object.id}>
                                                <BudgetCard budget={c.object}/>
                                            </Col>
                                        );
                                    } else if (c.type==='add-new'){
                                        return (
                                            <Col md={4} key={999}>
                                                <a href="#">Add new budget</a>
                                            </Col>
                                        );
                                    } else {
                                        return '???';
                                    }
                                })}
                            </Row>
                        );
                    })}
                </Grid>
            </div>
        )
    }
}