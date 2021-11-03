import { Component, Fragment } from 'react';
import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect,
} from 'react-router-dom';

export default class UserPage extends Component {
    state = {
       user: {}
    }
    componentDidMount(){
        let t = this;
        $.get("api/user/me", function(r){ t.setState({user: r})})
    }
    render() {
        $(window).scrollTop(0)
        return (
            <div>
                <div className="row userDetailsRow">
                    <div className="myDetailsBtn">
                    <td><Link className="btn" to={{ pathname: "/userdetails", user: this.state.user, back: "/userpage" }}>My details</Link></td>
                    </div>
                    <div className="myOrdersBtn">
                        <Link className="btn" to="/userorders">My orders</Link>
                    </div>
                </div>
            </div>
        )
    }

}