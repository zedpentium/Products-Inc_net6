import { Component, Fragment } from 'react';
import {
    Link
} from 'react-router-dom';

// class UserPageUserDetails extends Component{
//     state = {
//         user: {}
//     }
//     loadDataFromServer = () => {
//         let t = this;
//         $.get("api/user/me", function(r){ t.setState({user: r})})
//     }
//     componentDidMount = () => {
//         this.loadDataFromServer();
//     }
// render(){
//     return ( <div>
//     <Link className="btn btn-primary" to="/userpage">Back</Link>
//     <UserDetails user={this.state.user}/>
//     </div>
//     )}
// }

class UserDetails extends Component{
    state = {
        user: { userName: "", id: "", email: ""},
        updateUserDetailsModel: { userId: "", userName: "", email: "", password: "", confirmPassword: "" },
        msgIsError: false,
        msg: ""
    }
    componentDidMount(){
        this.setState({user: this.props.user ? this.props.user : this.props.location.user});

        console.log(this.state.user)
        this.setState({updateUserDetailsModel: {userId: this.state.user.id, userName: this.state.user.userName, email: this.state.user.email, ...this.state.updateUserDetailsModel}})
    }
    changeUserDetails = () => { 
        
        this.setState({msgIsError: false, msg: ""})
        console.log(this.state.user.id)
        
        let updateUserModel = this.state.updateUserDetailsModel;
        updateUserModel.userId = this.state.user.id;
        let t = this;

        if(updateUserModel.password && updateUserModel.password !== updateUserModel.confirmPassword){
            this.setState({msgIsError: true, msg: "Passwords do not match"})
        }
    
        $.ajax({      
            url: `api/user/${this.state.user.userName}`,
            type: "PUT",
            data: JSON.stringify(updateUserModel),
            Accept: "application/json",
            contentType: "application/json",
            dataType: "json",
            success: function(res) {
                t.setState({msgIsError: false, msg: "Details updated!"})
            },
            error: function (jqXHR, textStatus, errorThrown) {
                t.setState({msgIsError: true, msg: jqXHR.responseText})
            }
        });
    }
    stateMethod = (newDetail) => {
        this.setState({updateUserDetailsModel: {...this.state.updateUserDetailsModel, ...newDetail}})
    }
    render() {
        $(window).scrollTop(0)
            return (
                <div>
                    <h4><b>Details:</b></h4>
                    <Link className="btn btn-primary" to={this.props.back ? this.props.back : this.props.location.back}>Back</Link>
                    
                   {this.state.msgIsError ? <p className="text-danger">{this.state.msg}</p> : <p className="text-success">{this.state.msg}</p> }
                   <UserForm user={this.state.user} updateUserModel={this.state.updateUserDetailsModel} stateMethod={this.stateMethod} updateUserMethod={this.changeUserDetails}/>
                </div>
            )
        }
    }

function UserForm({user, updateUserModel, stateMethod, updateUserMethod}){
    return (
        <form className="form" onSubmit={e => {e.preventDefault(); updateUserMethod()}}>
              <div className="form-group">
                    <label htmlFor="username-input">Username</label>
                    <input className="form-control" placeholder={user.userName} value={updateUserModel.userName} type="text" id="username-input" onChange={e => stateMethod({ userName: e.target.value})}/>
                </div>
                <div className="form-group">
                    <label htmlFor="email-input">Email</label>
                    <input className="form-control"  placeholder={user.email} value={updateUserModel.email} type="email" id="email-input" onChange={e => stateMethod({ email: e.target.value})}/>
                </div>
                <div className="form-group">
                    <label htmlFor="password-input">New password:</label>
                    <input className="form-control" value={updateUserModel.password} type="password" id="password-input" onChange={e => stateMethod({ password: e.target.value})}/>
                </div>
                <div className="form-group">
                    <label htmlFor="confirm-password-input">Confirm new password:</label>
                    <input className="form-control"  value={updateUserModel.confirmPassword} type="password" id="confirm-password-input" onChange={e => stateMethod({ confirmPassword: e.target.value})}/>
            </div>
            <div className="savePasswordButtonDiv">
                <button className="btn submitButton" type="submit">Edit</button>
             </div>
        </form>
    )
}    

export default UserDetails;