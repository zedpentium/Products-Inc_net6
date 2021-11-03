import { Component } from 'react';

function OrderList({ orders, editable }) {
    return (
        <div>
            {orders.map(o => <Order editable={editable} order={o} key={o.orderId} />)}
        </div>
    )
}

function OrderProduct({ product, editable, onDelete }) {
    return (
        <div>
            {product.name}
            {editable ? <button onClick={() => onDelete(product)}>Delete</button> : null}
        </div>
    )
}
function OrderProducts({ products, editable, onDelete }) {
    return (
        <div>
            {products.map(p => <OrderProduct onDelete={onDelete} editable={editable} product={p} key={p.name} />)}

        </div>
    )
}
function Order({ order, editable, onDelete }) {
    let deleteDetected = p => {
        onDelete(order, p);
    }
    return (
        <div className="row">
            <p>{order.orderId}</p>
            <OrderProduct onDelete={deleteDetected} editable={editable} products={order.products} />

        </div>
    )
}

export default class Orders extends Component {
    state = {
        orders: [
            { products: [{ name: "test" }], orderId: "234784834", userId: 1 },
            { products: [{ name: "test" }], orderId: "2342334029834", userId: 1 },
            { products: [{ name: "test" }], orderId: "23423945645", userId: 2 },
            { products: [{ name: "test" }], orderId: "2342361234", userId: 3 },
        ]
    }
    deleteProductFromOrder = (order, p) => {
        console.log(order)
        console.log(p);
        //ajax call to delete order from product
    }

    render() {
        $(window).scrollTop(0)
        return (
            <div>

                <h1>From order component in a different fiiiile</h1>
                {/*<OrderList onDelete={deleteProductFromOrder} orders={this.props.orders.orders} editable={this.props.editable}/>     */}
            </div>
        )
    }
}