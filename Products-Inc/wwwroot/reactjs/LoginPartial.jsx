 import { Component, Fragment } from 'react';
 import React from 'React'

export default class LoginPartial extends Component {

    state = {
        loginModel: { userName: "", password: "", rememberMe: false }
    }

    //componentDidMount() {
    //    this.setState({ loginModel: { ...this.state.loginModel, userName: this.props.isUserAdmin } })
    //}

    render() {

        //console.log(this.props.isUserAdmin)
         return (
             <div className="identitybox loginPartialDiv">
                 <ul className="navbar-nav">
                     {this.props.userIsAuthenticated ?
                         <li className="nav-item">
                             <a className="nav-link">Hello {this.props.userNameIs}&nbsp;&nbsp;&nbsp;&nbsp; Role: {this.props.isUserAdmin? "Admin" : "User"}</a>

                         </li>
                         :
                         <li className="nav-item">
                             <a className="nav-link">You need to login</a>
                         </li>
                     }
                 </ul>
             </div >
         )
     }

 }