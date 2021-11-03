import { Component, Fragment } from 'react';
import React from 'React'
import {
    Redirect,
    Link
} from 'react-router-dom';

export default class Register extends Component {
    state = {
        registerModel: {userName: "", password: "", confirmPassword: "", email: ""},
        redirect: false
    }
    componentDidMount(){
        this.setState({redirect: false})
    }
    register = e => {
        let t = this;
        e.preventDefault();

        $.ajax({
            url: "api/user/register",
            method: "POST",
            data: JSON.stringify(this.state.registerModel),
            accepts: { json: "application/json" },
            contentType: "application/json",
            dataType: "json",
            success: function(response, textStatus, jqXHR) {
                console.log("succeeded");
                console.log(t)
                t.setState({redirect: true})
            },
            error: function (jqXHR, textStatus, errorThrown) {
                    console.log(jqXHR);
                  console.log(textStatus);
                  console.log(errorThrown);
            }
          });



    }
    render() {
        $(window).scrollTop(0)

        if(this.state.redirect){
            return <Redirect to={this.props.redirectUrl ? this.props.redirectUrl : this.props.location.redirectUrl}/>
        }else
        return (
            <div>
                <form className="form" onSubmit={this.register}>
                    <div className="form-group">
                        <label htmlFor ="username-input">Username</label>
                        <input value={this.state.registerModel.userName} onChange={e => this.setState({registerModel: {...this.state.registerModel, userName: e.target.value}})} className="form-control" id="username-input" type="text" />
                    </div>
                    <div className="form-group">
                        <label htmlFor ="email-input">Email</label>
                        <input value={this.state.registerModel.email} onChange={e => this.setState({registerModel: {...this.state.registerModel, email: e.target.value}})} className="form-control" id="email-input" type="email" />
                    </div>
                    <div className="form-group">
                        <label htmlFor ="password-input">Password</label>
                        <input value={this.state.registerModel.password} onChange={e => this.setState({registerModel: {...this.state.registerModel, password: e.target.value}})} className="form-control" id="password-input" type="password" />
                    </div>
                    <div className="form-group">
                        <label htmlFor ="confirm-password-input">Repeat Password</label>
                        <input value={this.state.registerModel.confirmPassword} onChange={e => this.setState({registerModel: {...this.state.registerModel, confirmPassword: e.target.value}})} className="form-control" id="confirm-password-input" type="password" />
                    </div>
                    <div className="registerBtnDiv">
                        <button type="submit" className="btn">Register</button>
                    </div>
                </form>
            </div>
        )
    }
}

