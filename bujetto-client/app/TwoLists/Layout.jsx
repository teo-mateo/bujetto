import React, {Component} from 'react'
import {Link} from 'react-router'
import {Nav, Navbar, NavItem, MenuItem, NavDropdown, Row, Col} from 'react-bootstrap'

export default class Layout extends Component{
    constructor(props){
        super(props)

        this.handleSelect = this.handleSelect.bind(this);
    }

    handleSelect(k){

    }

    render(){
        return (
            <div>
                <div>
                    <Navbar>
                        <Navbar.Header>
                            <Navbar.Brand>
                                <a href="#">BuJetto</a>
                            </Navbar.Brand>
                        </Navbar.Header>
                        <Nav>
                            <NavItem eventKey={1} href="#/budgets">Budgets</NavItem>
                            <NavItem eventKey={2} href="#/expenses">Expenses</NavItem>
                            <NavItem eventKey={4} href="#/budgets/1">Categorii B1</NavItem>
                            <NavItem eventKey={5} href="#/budgets/2">Categorii B2</NavItem>
                        </Nav>
                    </Navbar>
                </div>
                <div>
                    <Row>
                        <Col md={2} />
                        <Col md={6}>
                            {this.props.children}
                        </Col>
                        <Col md={3} />
                    </Row>
                </div>
            </div>
        );
    }
}