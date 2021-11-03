import { Component, Fragment } from 'react';
import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect
} from 'react-router-dom';

export default class ContactUs extends Component{
    
    render() {
        $(window).scrollTop(0)
        return (
            <div className="contact_us_contents">
                <h4><b>Contact Us at:</b></h4>
                <br/>
           <p>Products Inc</p>
                <p>Diddly Shop</p>
                <p>5-12 Chipping Norton Road BB8</p>
                <p>Chipping Norton BB8 3NR</p>
                <p>UK</p>

            </div>
        )
    }
}
