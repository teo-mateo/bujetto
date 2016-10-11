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
                            <NavItem eventKey={1} href="#"><Link to="budgets">Budgets</Link></NavItem>
                            <NavItem eventKey={2} href="#"><Link to="expenses">Expenses</Link></NavItem>
                            <NavItem eventKey={4} href="#"><Link to="budgets/2">Categorii B2</Link></NavItem>
                            <NavItem eventKey={5} href="#"><Link to="budgets/2">Categorii B2</Link></NavItem>
                            <NavDropdown eventKey={3} title="Dropdown" id="basic-nav-dropdown">
                                <MenuItem eventKey={3.1}>Action</MenuItem>
                                <MenuItem eventKey={3.2}>Another action</MenuItem>
                                <MenuItem eventKey={3.3}>Something else here</MenuItem>
                                <MenuItem divider />
                                <MenuItem eventKey={3.3}>Separated link</MenuItem>
                            </NavDropdown>
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