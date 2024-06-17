﻿//import { render } from 'react-dom'
import { Component, Fragment } from 'react'

import Orders from './Orders.jsx'
import Products from './Products.jsx'
import HeaderPartial from './HeaderPartial.jsx'
import FooterPartial from './FooterPartial.jsx'
import Login from './Login.jsx'
import Register from './Register.jsx'
import Logout from './Logout.jsx'
import LoginPartial from './LoginPartial.jsx'
import YouAreLoggedOut from './YouAreLoggedOut.jsx'
import ContactUs from './ContactUs.jsx'
import UserPage from './UserPage.jsx'
import { Checkout, Receipt } from './Checkout.jsx'
import AdminOrders from './AdminOrders.jsx'
import AdminEditOrder from './AdminEditOrder.jsx'
import AdminProducts from './AdminProducts.jsx'
import AdminEditUserRoles from './AdminEditUserRoles.jsx'
import AdminCreateUser from './AdminCreateUser.jsx'
import AdminRegisterUser from './AdminRegisterUser.jsx'
import AdminUsers from './AdminUsers.jsx'
import UserOrders from './UserOrders.jsx'
import UserDetails  from './UserDetails.jsx'

import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect,
    browserHistory,
    useLocation,
    useHistory
} from 'react-router-dom';
import Cookies from 'js-cookie'
import React, { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux'
import { Provider } from 'react-redux'
import reduxstore from './store/configureStore.js'
//import PropTypes from 'prop-types';

// ------------- end imports -------------


//const reduxstore = reduxstore()

//const propTypes = {
//    store: PropTypes.object.isRequired
//}

export default class Index extends Component {
   state = {
       viewOrders: false,
       isUserAuthenticated: false,
       isUserAdmin: false,
       isUserName: "",
       nrOfProducts: 0
    }


    componentDidMount(){
        let t = this;

        this.setState({
            isUserAuthenticated: this.props.userIsAuthenticated, isUserAdmin: this.props.userIsAdmin,
            isUserName: this.props.userNameIs
        })

        //if(!Cookies.get("shopping-cart") && this.props.userIsAuthenticated){   
        //    $.get(`/api/shoppingcart/users`, function(r){ if(r.products){
        //        t.setState({nrOfProducts: r.products.length}
             
        //            )}})

            
    //    .fail(e => console.log(e));
    //    }else if(Cookies.get("shopping-cart")){
    //        let shoppingCart = JSON.parse(Cookies.get("shopping-cart"))
          
    //        t.setState({nrOfProducts: shoppingCart.Products ?
    //    shoppingCart.Products.reduce((prevPr, nextPr) => { return prevPr + nextPr.Amount }, 0) : 0
    //})
    //    }

    }


    setNrOfProducts = (nr) => {
        this.setState(oldState => ({nrOfProducts: oldState.nrOfProducts + nr}))
    }


    resetNrOfProducts = () => {
        this.setState(oldState => ({nrOfProducts: 0}))
    }


    loggedIn = (user) => {
           
        let t = this;


        //if(!Cookies.hasItem("shopping-cart")){   
        //    $.get(`/api/shoppingcart/users`, function(r){ if(r.products){
        //        t.setState({nrOfProducts: r.products.length}
        //        )}}).fail(e => console.log(e)); 
        //}
            
        this.setState({ isUserAuthenticated: true, 
            isUserAdmin: user.roles.includes("Admin") || user.roles.includes("ADMIN") ||
                user.roles.includes("admin"),
            isUserName: user.userName})
    }


    loggedOut= () => {
        this.setState({ isUserAuthenticated: false, isUserAdmin: false, isUserName: "" })
    }


    render() {
        /*const app = ({ store }) => (*/
        const app = (

            <div id="pagegridwrapper">
                {/*Header component*/}
                <HeaderPartial userName={this.state.isUserName} nrOfProducts={this.state.nrOfProducts}
                    resetNrOfProducts={this.resetNrOfProducts} setNrOfProducts={this.setNrOfProducts}
                    setLoggedIn={this.loggedIn} setLoggedOut={this.loggedOut}
                    userIsAdmin={this.state.isUserAdmin} userIsAuthenticated={this.state.isUserAuthenticated} />


                <reactcontent>

                    <Switch>
                        <Route exact path="/" render={(props) =>
                            <Redirect to={{
                                pathname: "/products", ...props,
                                setNrOfProducts: this.setNrOfProducts
                            }} />} />

                        <Route exact path="/"> <ContactUs /> </Route>

                        <Route path="/login" render={(props) => <Login {...props } />}/>
                        <Route path="/logout" render={(props) => <Logout {...props } />}/>
                        <Route path="/loginpartial" render={(props) => <LoginPartial {...props } />}/>
                        <Route path="/youareloggedout"><YouAreLoggedOut /></Route>

                        <Route path="/register" render={(props) => <Register {...props } />}/>


                        <Route path="/products" render={(props) =>
                            <Products {...props} setNrOfProducts={this.setNrOfProducts} />} />
                        <Route path="/orders"><Orders /></Route>
                        <Route path="/contactus"><ContactUs /></Route>


                        <Route path="/userpage"><UserPage /></Route>
                        <Route path="/userorders"><UserOrders /></Route>
                        <Route path="/userdetails" render={(props) => <UserDetails {...props}/>}/>
                        <Route path="/checkout"><Checkout setNrOfProducts={this.setNrOfProducts}
                            resetNrOfProducts={this.resetNrOfProducts} /></Route>
                        <Route path="/orderdetails" render={(props) => <Receipt {...props}/>}/>


                        {/*<Route path="/adminorders"><AdminOrders history={useHistory}*/}
                        {/*    location={useLocation} /></Route>*/}
                        <Route path="/adminorders"><AdminOrders history={useHistory} /></Route>
                        <Route path="/admineditorder" render={(props) => <AdminEditOrder {...props} />} />
                        <Route path="/adminproducts" render={(props) => <AdminProducts {...props} />} />

                        <Route path="/admincreateuser" render={(props) => <AdminCreateUser {...props} />} />
                        <Route path="/adminregisteruser" render={(props) => <AdminRegisterUser {...props}/>}/>
                        <Route path="/adminusers"><AdminUsers /></Route>
                        <Route path="/adminedituser" render={(props) => <AdminEditUser {...props}/>}/>
                        <Route path="/adminedituserroles" render={(props) => <AdminEditUserRoles {...props}/>}/>
                    </Switch>



                </reactcontent>

                <FooterPartial />  {/*Footer component*/}
            </div>

        )



        if (typeof window === 'undefined') {
            return (
                <Provider store={reduxstore}>
                <StaticRouter
                    //context={this.props.context}
                    //location={this.props.location}
                >
                    {app}
                </StaticRouter>
                </Provider >
            )
        }


        return (
            <Provider store={reduxstore}>
            <BrowserRouter>
                {app}
                </BrowserRouter>
            </Provider >
        )


    }


}

/*App.propTypes = propTypes*/


//export function ReduxStuff() {
//    const count = useSelector(selectCount)
//    const dispatch = useDispatch()
//}

