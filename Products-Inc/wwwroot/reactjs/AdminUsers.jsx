import { Component, Fragment } from 'react';
import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect
} from 'react-router-dom';

export default class AdminUsers extends Component{
    state = {
        users: []
    }
    componentDidMount(){
        let t = this;
        $.get("/api/user", function(res){  t.setState({users: res})})
        .done(r => console.log(r))
        .fail(e => console.log(e));
    }
    render(){
        return (
            <div>
            
                <div className="registerNewUserBtnDiv"> 
                    <Link className="btn" to={{pathname:"/adminregister", redirectUrl:"/adminusers"}}>Register new user</Link>
                </div>
                <br />
                <br />
                <br />
                <br/>
                <div> 
                    <UserTable users={this.state.users}/>
                </div>

            </div>
        )
    }
}

function UserTable({users}){
    return (
        <table className="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Username</th>
                    <th scope="col">Email</th>
                    <th scope="col"></th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                {users.map(u => <UserInfo key={u.id} user={u}/>)}
            </tbody>
        </table>
    )
}

function UserInfo({user}){
    return (
            <tr scope="col">
                <td>{user.id}</td>
                <td>{user.userName}</td>
                <td>{user.email}</td>
                         
                <td><Link className="btn" to={{pathname:"/adminedituser", user, back: "/adminusers"}}>Edit user</Link></td>
                <td><Link className="btn" to={{pathname:"/adminedituserroles", user}}>Edit roles</Link></td>
            </tr>
    )}
