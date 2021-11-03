import { Component } from 'react'
import {Link} from 'react-router-dom';

export default class AddRoles extends Component{
    state = {
        roles: [],
        user: {
            userName: "",
            roles: []
        },
        msg: "",
        errorMsg: false
    }
    componentDidMount = () => {
        let t = this;
        $.get("/api/user/roles", function(res){ t.setState({roles: res})})
        .done(r => {
            $.get(`/api/user/roles/${t.props.location.user.userName}`, 
            function(res){ t.setState({user: {...t.props.location.user, roles: res.roles}})})
            .fail(e => console.log(e));
        }).fail(e => console.log(e))
      
            
      
    }
   
    addRole = () => {
        let t = this;
        t.setState({msg: "", errorMsg: false})
        $.ajax({      
            url: `api/user/roles/${this.state.user.userName}`,
            type: "PUT",
            data: JSON.stringify(this.state.user.roles),
            Accept: "application/json",
            contentType: "application/json", 
            dataType: "json",
            success: function(res) {
                console.log(res)
                t.setState(oldState => ({user: {...oldState.user, roles: res.roles}, msg: "Roles updated!", errorMsg: false}))
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR)
                console.log(textStatus)
                console.log(errorThrown)
                t.setState({msg: "Roles not managed to be updated", errorMsg: true})
            }
        });
    }
    filterRole = r => {
        if(this.state.user.roles.includes(r)) { 
            this.setState(oldState => ( {user: {...oldState.user, roles: oldState.user.roles.filter(role => role !== r) } })) 
        } 
        else {
            this.setState(oldState => ( {user: { ...oldState.user, roles:  [...oldState.user.roles, r]}}) ) }
    }
    checked = r => this.state.user.roles.includes(r);
    render() { return (
        <div className="editUserPageRoles">
            <p className={this.state.errorMsg ? 'text-danger' : 'text-success'}>{this.state.msg}</p>
            <Link className="btn" to={{pathname: "/adminusers"}}>Back</Link>
            <h2>User: {this.props.location.user.userName}</h2>
            <Roles roles={this.state.roles} filterRoleMethod={this.filterRole} checked={this.checked} userroles={this.state.user.roles} submitMethod={this.addRole}/>
        </div>
        )
        }

}

function Roles({roles, filterRoleMethod, submitMethod, checked}){
    return (
        
        <div className="editUserPageRoles">
            <form onSubmit={e => { e.preventDefault(); submitMethod(); }}>
            { roles.map(r => ( <div key={r}>
                <label htmlFor="checkbox" >{r}</label>
                    <input type="checkbox" id="checkbox" value={r} checked={checked(r)} onChange={() => { filterRoleMethod(r) }} />
                </div> ))
                }
            <button className="btn" type="submit">Update roles</button>
            </form>
        </div>
    )
}