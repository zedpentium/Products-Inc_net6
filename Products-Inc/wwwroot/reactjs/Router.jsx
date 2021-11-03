
import { Component, Fragment} from 'react';

import UserPage from './UserPage.jsx';
import Products from './Products.jsx';

import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect,
    browserHistory
} from 'react-router-dom';

//function handleClick(whatever) {
//    console.log(whatever)
//    browserHistory.push(whatever)
//}



export default class RouterNav extends Component {

    render() {
        const app = (
            <div>
                <h1>{this.props.someProp}</h1>
                <Switch>
                    <Route path="/products"><Products name={this.props.name}/></Route>
                    <Route
                        path="/mypage">
                        <UserPage />
                    </Route>

                </Switch>



            </div>
        );


        if (typeof window === 'undefined') {
            return (
                <StaticRouter history={browserHistory}
                    context={this.props.context}
                    location={this.props.location}
                >
                    {app}
                </StaticRouter>
            );
        }
        return <BrowserRouter history={browserHistory}>{app}</BrowserRouter>;

    }
}

