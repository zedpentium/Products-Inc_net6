import { Component, Fragment } from 'react';
import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect
} from 'react-router-dom';

export default class YouAreLoggedOut extends Component{

    render() {
        $(window).scrollTop(0)
        return (
            <div>
                <h4><b>You are now logged out.</b></h4>
                <br/>
            </div>
        )
    }
}
