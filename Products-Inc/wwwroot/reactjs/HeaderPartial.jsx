import { Component, Fragment } from 'react';
import React from 'React'
import Logout from './Logout.jsx';
import {
    Link
} from 'react-router-dom';
import LoginPartial from './LoginPartial.jsx';


export default class Headerpart extends Component {

    constructor(props) {
        super(props)
    }
    state = {
        nrOfProducts: 0
    }
    changeViewMenu = (viewpage) => {
        //console.log(viewpage)
        this.props.setViewPage({ viewpagestate: viewpage })
    }

    render() {
        return (
            <header className="item-header">
                <LoginPartial userIsAuthenticated={this.props.userIsAuthenticated} userNameIs={this.props.userName}
                    isUserAdmin={this.props.userIsAdmin} />
                {this.props.userIsAuthenticated}
                {this.props.userIsAdmin}
                <nav className="navbar navbar-expand-lg navbar-dark">
                    <div className="container-fluid">
                        <div className="navbar-brand text-info" id="menulogo" alt="Company Logo">
                            <Link to={{pathname: "/", setNrOfProducts: this.props.setNrOfProducts} }><img alt="logo" src="./img/logo.png" /></Link>
                            
                        </div>
                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse" id="collapsibleNavbar">
                            <ul className="navbar-nav me-auto mb-2 mb-lg-0 justify-content-center">
                                <li className="nav-item dropdown">
                                    <a className="nav-link dropdown-toggle dropbtn" href="#" id="navbarDarkDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                        Mainmenu
                                    </a>
                                    <ul className="dropdown-menu dropdown-content" aria-labelledby="navbarDarkDropdownMenuLink">
                                        <li><Link to={{pathname: "/products", setNrOfProducts: this.props.setNrOfProducts}}>Products</Link></li>
                                        <li><Link to="/contactus">Contact Us</Link></li>
                                    </ul>
                                </li>
                                {this.props.userIsAuthenticated ?
                                    this.props.userIsAdmin ?
                                <li className="nav-item">
                                    <div className="nav-item dropdown">
                                        <a className="nav-link dropdown-toggle dropbtn" href="#" id="navbarDarkDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                            Admin Menu
                                        </a>
                                        <ul className="dropdown-menu dropdown-content" aria-labelledby="navbarDarkDropdownMenuLink">
                                            <li><Link to="/adminproducts">Products</Link></li>
                                            <li><Link to="/adminusers">Users</Link></li>
                                            <li><Link to="/adminorders">Orders</Link></li>
                                        </ul>
                                    </div>
                                </li>
                                :
                                <li className="nav-item">
                                    <div className="nav-item dropdown">
                                        
                                        <Link className="btn" to="/userpage" id="navbarDarkDropdownMenuLink" role="button" >
                                            My Page
                                        </Link>
                                    </div>
                                </li>
                                : null }
                                <li className="nav-item">
                                    <Link to="/checkout" className="nav-link text-dark"><div><img src="./img/cart.jpg" width="40" height="40" /><div className="bg-success rounded-circle text-center" style={{ position: 'absolute', top: '3em', paddingLeft: '5px', paddingRight: '5px'}}><h3 className="h-30">{this.props.nrOfProducts}</h3></div></div></Link>
                                </li>
                                {!this.props.userIsAuthenticated ?
                                <li className="nav-item">
                                    <Link className="btn btn-primary" to={{pathname: "/register", redirectUrl: "/login"}} className="nav-link">Register</Link>
                                </li> : null
                                }
                                {!this.props.userIsAuthenticated ?
                                <li className="nav-item">
                                    <Link className="btn btn-primary" to={{pathname: "/login", loggedInCallback: this.props.setLoggedIn}} className="nav-link" >Login</Link>
                                </li> : null
                                }
                                {this.props.userIsAuthenticated ?
                                <li className="nav-item">
                                   <Logout logoutCallback={this.props.setLoggedOut}/>
                                </li> : null
                                }

                            </ul>
                    </div>

                    </div>
                </nav>
            </header >

        )

    }


} // class end tag

