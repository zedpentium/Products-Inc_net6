import { Component, Fragment } from 'react';
import { Redirect} from 'react-router-dom';
import Cookies from 'js-cookies';
import Index from './Index.jsx';

export default class Login extends Component {

    state = {
            loginModel: { userName: "", password: "", rememberMe: false },
            redirect: false,
            wronglogin: false
    }


    componentDidMount() {
       this.setState({ redirect: false })

    }


    tryToLogin = e => {
        e.preventDefault();

        let t = this;

        $.ajax({
            url: "/api/user/login",
            method: "POST",
            data: JSON.stringify(this.state.loginModel),
            //accepts: { json: "application/json" },
            contentType: "application/json",
            dataType: "json",
            success: function(res) {

                let shoppingCart = JSON.parse(Cookies.getItem("shopping-cart"));
                if (shoppingCart) {

                    if (!shoppingCart.shoppingCartId || !shoppingCart.UserId) {
                        $.ajax({
                            url: "/api/shoppingcart",
                            method: "POST",
                            data: JSON.stringify(shoppingCart),
                            dataType: "json",
                            success: function (res) {
                                console.log(res)
                            },
                            error: function (res) {
                                console.log(res);
                            }
                        })
                    }


                }else{
                    $.get(`/api/shoppingcart/users`, function(r){ console.log(r); })
                   .fail(e => console.log(e));
                }
                if(t.props.location.loggedInCallback){
                    t.props.location.loggedInCallback(res);
                }

                t.setState({redirect: true})
            },
            error: function (jqXHR, textStatus, errorThrown) {
                /*console.log(jqXHR);*/
                //console.log(textStatus);
                //console.log(errorThrown);
                //t.setState({ wronglogin: true })
                t.setState({ redirect: true })
            }
        })
    }


    render() {
        $(window).scrollTop(0)

        if (this.state.redirect) {
           return <Redirect to={this.props.location.redirectUrl ? this.props.location.redirectUrl : "/"} />
        } else
            return (
                <div>
                    {this.state.wronglogin ?
                        <div>WRONG USER OR PASSWORD</div>
                        :
                        null
                    }
                    <form className="formlogin" onSubmit={this.tryToLogin}>
                        <div className="form-group">
                            <label htmlFor ="username-input">Username</label>
                            <input value={this.state.loginModel.userName} onChange={ e =>
                                this.setState({ loginModel: { ...this.state.loginModel, userName: e.target.value }
                                })} className="form-control" id="username-input" type="text" />
                        </div>
                        <div className="form-group">
                            <label htmlFor ="password-input">Password</label>
                            <input value={this.state.loginModel.password} onChange={ e =>
                            this.setState({ loginModel: { ...this.state.loginModel, password: e.target.value }
                            })} className="form-control" id="password-input" type="password" />
                        </div>
                        <div className="form-check">
                            <label className="form-check-label" htmlFor="remember-me-check">Remember me</label>
                            <input defaultChecked={this.state.loginModel.rememberMe} onChange={ e =>
                            this.setState({ loginModel: { ...this.state.loginModel, rememberMe: !this.state.loginModel.rememberMe }
                            })}
                            id="remember-me-check" className="form-check-input" type="checkbox" />
                        </div>
                        <br/>
                        <div className="logInBtnDiv">
                            <button type="submit" className="btn submitButton">Login</button>
                        </div>
                    </form>
                </div>
            )
    }
}