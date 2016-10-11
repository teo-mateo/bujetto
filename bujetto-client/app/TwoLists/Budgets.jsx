import React, {Component} from 'react'
import {Grid, Row, Col, Panel, Button} from 'react-bootstrap'
import axios from 'axios'
import BudgetCard from './BudgetCard'
import _ from 'lodash'

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
        const budgets = _.chunk(this.state.budgets, 3);

        budgets.map(chunk =>{
           console.log(chunk);
            chunk.map(budget =>{
                console.log(budget);
            })
        });

        return (
            <div>
            <h2>Where yo' money go and never come back</h2>
                <Grid>
                    {budgets.map((chunk, i) =>{
                        return (
                            <Row key={i}>
                                {chunk.map(budget =>{
                                    return (
                                        <Col md={4} key={budget.id}>
                                            <BudgetCard budget={budget}/>
                                        </Col>
                                    );
                                })}
                            </Row>
                        );
                    })}
                </Grid>
            </div>
        )
    }
}