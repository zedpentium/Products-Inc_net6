import { Component, Fragment } from 'react';


import {
    Link
} from 'react-router-dom';

function UserOrderTable({ orders }) {
    return (
        <div>
            {orders.map(o => <UserOrder key={o.orderId} order={o} />)}
        </div>
    )
}

function UserOrder({ order }) {
    return (<div className="row text-primary">
        <Link className="text-primary" to={{ pathname: "/orderdetails", order, msg: "Receipt" }} >Ordernr: {order.orderId} </Link>
    </div>
    )
}
export default class UserOrders extends Component {
    state = {
        orders: []
    }
    componentDidMount() {
        let t = this;

        $.get("/api/order/users", function () { })
            .done(res => t.setState({ orders: res }))
            .fail(e => console.log(e));
    }
    render() {
        $(window).scrollTop(0)
        return (
            <div>
                <h4>UserOrders:</h4>
                <Link className="btn" to="/userpage">Back</Link>
                <UserOrderTable orders={this.state.orders} />
            </div>
        )
    }
}