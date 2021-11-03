import { Component, Fragment } from 'react';
import Register from './Register.jsx';


export default class AdminRegister extends Component{
    render(){
        return (
            <div>
                <Link className="btn btn-primary" to={this.props.location.redirectUrl}>BACK</Link>
                <h4>Register new user</h4>
                <Register redirectUrl={this.props.location.redirectUrl}/>

            </div>
        )
    }
}




