
import { Component, Fragment } from 'react';
import Cookies from 'js-cookies'
import {
    Redirect
} from "react-router-dom";

class Checkout extends Component {
    state = {
        viewReceipt: false,
        shoppingCart: {
            products: [],
            shoppingCartId: ''
        },
        order: {
            Price: 0.0,
            UserId: 0,
            Products: [],
            Id: 0,
            OrderNr: ""
        },
        redirect: false,
        redirectUrl: "/products"
    }
    componentDidMount() {
        this.setState({ redirect: false })

        if (Cookies.hasItem("shopping-cart")) {
            let sc = JSON.parse(Cookies.getItem("shopping-cart"))
            let newSc = { shoppingCartId: sc.ShoppingCartId, products: sc.Products.map(p => { return {amount: p.Amount, productId: p.ProductId, product: {productName: p.Product.ProductName, productPrice: p.Product.ProductPrice, productId: p.Product.ProductId}}})}
            console.log(newSc)
            this.setState({ shoppingCart: newSc })
        }
    }
    cancelOrder = () => {

        this.setState({
            order: {
                Price: 0.0,
                UserId: 0,
                Products: [],
                Id: 0,
                OrderNr: "",
                TotalPrice: 0.0
            }
        })

        this.setState({ redirectUrl: "/products", redirect: true })

    }
    checkoutOrder = () => {
        let t = this;

        $.ajax({
            url: "/api/shoppingcart/buy",
            method: "POST",
            data: JSON.stringify(this.state.shoppingCart),
            accepts: { json: "application/json" },
            contentType: "application/json",
            dataType: "json",
            success: function(res) {
                
                t.props.resetNrOfProducts()
                t.setState(oldState => ({ viewReceipt: !oldState.viewReceipt, order: { ...res, TotalPrice: t.totalPrice() } }))
            },
            error: function (jqXHR, textStatus, errorThrown) {

                t.setState({ redirectUrl: "/login", redirect: true })

            }
        });

    }
    
    updateMe = (product, amount) => {
        let t = this;
        let productAmount = product.amount
        let nr = amount > productAmount ? Number(amount - productAmount) : amount > 0 ? Number((productAmount - amount) * -1) : Number( productAmount * -1)
        let updatedProduct = {...product, amount}
        $.ajax({
            url: "/api/shoppingcart/products",
            method: "PUT",
            data: JSON.stringify(updatedProduct),
            accepts: { json: "application/json" },
            contentType: "application/json",
            dataType: "json",
            success: function(res) {
                
                t.props.setNrOfProducts(nr)
                t.setState({ shoppingCart: {...t.state.shoppingCart, products: res.products}} )
            },
            error: function (jqXHR, textStatus, errorThrown) {

               

            }
        });

    }
    totalPrice = () => Math.round(this.state.shoppingCart.products.reduce((prevPr, nextPr) => { return prevPr + ((nextPr.amount) * (nextPr.product.productPrice)) }, 0) * 100) / 100 ;

    render() {
        $(window).scrollTop(0)

        if (this.state.redirect)
            return (
                <div>
                    <RedirectTo url={this.state.redirectUrl} />
                </div>
            )
        else
            return (
                <div>
                    {
                        !this.state.viewReceipt ?
                            <div>
                                <ProductList products={this.state.shoppingCart.products} updateProductMethod={this.updateMe} />
                                <div className="d-flex align-items-end justify-content-end totalPriceCheckoutDiv">
                                    <h3 className="border border-white m-3 p-2" >Total Price: {this.totalPrice()}kr</h3>
                                </div>
                                <button onClick={this.checkoutOrder} className="p-2 m-3 btn">BUY</button>
                                <button onClick={this.cancelOrder} className="p-2 m-3 btn">CANCEL</button>
                            </div>
                            :
                            <div>
                                <Receipt propMsg={"Your order has been placed!"} propOrder={this.state.order} />
                            </div>
                    }

                </div>
            )
    }
}



function Receipt({ propOrder, propMsg, user, location }) {
    const printReceipt = () => {

        var divContents = document.getElementById("receipt").innerHTML;
        var receiptWindow = window.open('', '', 'height=500, width=500');
        receiptWindow.document.write('<html>');
        receiptWindow.document.write('<body >');
        receiptWindow.document.write(divContents);
        receiptWindow.document.write('</body></html>');
        receiptWindow.document.close();
        receiptWindow.print();


    };
    const order = propOrder ? propOrder : location.order
    const msg = propMsg ? propMsg : location.msg

    const totalPrice = Math.round(order.orderProducts.reduce((prevPr, nextPr) => { return prevPr + (nextPr.amount * nextPr.product.productPrice) }, 0) * 100) / 100;
    return (
        <div id="receipt" className="d-flex align-items-center justify-content-center orderSucessPage">
            <div>
                <h2>{msg}</h2>

       
            <h4>Ordernr: {order.orderId}</h4>
            <ul>
                    {order.orderProducts.map((p, index) => <li key={index+10}>{p.product.productName}, x{p.amount} {p.product.productPrice * p.amount}kr</li>)}
            </ul>
           
                <h2>Total price: {totalPrice}kr</h2>
                <h4>Thank you for ordering!</h4>

                <div className="d-flex align-items-end justify-content-end printReciptBtn">
                    <button className="p-2 m-2 btn " onClick={printReceipt}>PRINT RECEIPT</button>
                </div>


            </div>
        </div>
    )
}

function RedirectTo({ url,  redirectUrl }) {
    
    return <Redirect to={{pathname: url, redirectUrl}}></Redirect>
}


function Product({ product, updateMe }) {
    
    return (
        <tr>
            {console.log(product)}
            <td colSpan={5}>{product.product.productName}</td>
            <td colSpan={2}><input type="number" value={product.amount} onChange={e => updateMe(product, Number(e.target.value))}/></td>
            <td colSpan={5}>{Number(product.product.productPrice * product.amount)}</td>
            <td colSpan={1}><button className="btn btn-danger" onClick={() => updateMe(product, 0)}>-</button></td>
        </tr>
    )
}

function ProductList({ products, updateProductMethod }) {
    return (
        <table className="table">
            <thead>
                <tr>
                    <th colSpan={5}>Product</th>
                    <th colSpan={2}>Amount</th>
                    <th colSpan={5}>Price</th>
                    <th colSpan={1}></th>
                </tr>
            </thead>
            <tbody>
                {products.map((p, index) => <Product product={p} key={index + 50} updateMe={updateProductMethod} />)}
            </tbody>
        </table>
    )
}

export { Checkout, Receipt }