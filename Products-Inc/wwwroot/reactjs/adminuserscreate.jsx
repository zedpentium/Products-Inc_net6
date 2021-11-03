import { Component, Fragment } from 'react';
import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect
} from 'react-router-dom';



export default class CreateUser extends Component{
    state = {
        user: {
            userName: "",
            email: "",
            password: "",
            confirmPassword: ""
        }
    }
    componentDidMount(){
        
    }
    updateUser = (value) => {
        this.setState({user: {...this.state.user, ...value}})
    }
    postUser = () => {
        $.ajax({      
            url: `api/user/register`,
            type: "POST",
            data: JSON.stringify(this.state.user),
            Accept: "application/json",
            contentType: "application/json", 
            dataType: "json",
            success: function(res) {
                console.log(res);
            },
            error: function (jqXHR, textStatus, errorThrown) {
            }
        });
    }
    render(){
        return (
            <div>
                <CreateUserForm user={this.state.user} stateMethod={this.updateUser} createUserMethod={this.postUser}/>
            </div>
            
        )
    }
}

function CreateUserForm({user, stateMethod, createUserMethod}){
    return (
        <form className="form" onSubmit={e => {e.preventDefault(); createUserMethod()}}>
              <div className="form-group">
                    <label htmlFor="username-input">Username</label>
                    <input className="form-control" value={user.userName} type="text" id="username-input" onChange={e => stateMethod({ userName: e.target.value})}/>
                </div>
                <div className="form-group">
                    <label htmlFor="email-input">Email</label>
                    <input className="form-control" value={user.email} type="email" id="email-input" onChange={e => stateMethod({ email: e.target.value})}/>
                </div>
                <div className="form-group">
                    <label htmlFor="password-input">New password:</label>
                    <input className="form-control" value={user.password} type="password" id="password-input" onChange={e => stateMethod({ password: e.target.value})}/>
                </div>
                <div className="form-group">
                    <label htmlFor="confirm-password-input">Confirm new password:</label>
                    <input className="form-control"  value={user.confirmPassword} type="password" id="confirm-password-input" onChange={e => stateMethod({ confirmPassword: e.target.value})}/>
                </div>
                <button className="btn btn-primary" type="submit">Edit</button>
        </form>
    )
}