import { Component, Fragment } from 'react';
import {
    Link
} from 'react-router-dom';


export default class AdminEditOrder extends Component {

    constructor(props) {
        super(props)
        this.state = {
            orderproducts: this.props.location.ao.orderProducts,
            orderId: 0,
            products: {
                productId: 0,
                amount: 0
            },
            msg: "",
            errorMsg: false
        }
    }
    removeProduct = (id) => {
        let t = this;
        t.setState({errorMsg: false, msg: ""})

        $.ajax({
            url: `/api/order/products/${id}`,
            type: 'DELETE',
            success: function(response) {
                t.setState(oldState => ({
                    orderproducts: 
                        oldState.orderproducts.filter(p => p.orderProductId !== id)        
            }));
            t.setState({errorMsg: false, msg: "Product successfully deleted."})
            },
            error: function(err){
                t.setState({errorMsg: true, msg: "Product failed to be deleted."})
            }
         });
 
   
        
    }

    editProduct = (id, newAmount) => {
       
        this.setState(oldState => ({ orderproducts: oldState.orderproducts.map(op => {
            if(op.orderProductId === id){
                op.amount = Number(newAmount);
            }
                return op; }
        )})) 

    }
    updateProductAmount = (id, op) => {
        let t = this;
            
        if(op.amount > 0){
        $.ajax({
            url: `/api/order/products/${id}`,
            type: 'PUT',
            data: JSON.stringify(op),
            Accept: "application/json",
            contentType: "application/json", 
            dataType: "json",
            success: function(response) {
                console.log(response);
                t.setState(oldState => ({ orderproducts: oldState.orderproducts.map(op => {
                            if(op.orderProductId === id){
                                return response;
                            }
                                return op; }
                        )}))        
            
            t.setState({errorMsg: false, msg: "Product successfully updated."})
            },
            error: function(err){
                t.setState({errorMsg: true, msg: "Product failed to be updated."})
            }
         });}else{
             this.removeProduct(id);
         }
    }


    render() {
        $(window).scrollTop(0)

        return (
            <div>
                <h4><b>AdminEditOrder & Details:</b></h4>
                <br />
                <p className={this.state.errorMsg ? 'text-danger' : 'text-success'}>{this.state.msg}</p>
                <div> {/*this div is sidemenu-tab*/}
                    {/*<div className="nav-item">*/}
                    {/*    <button className="nav-link text-dark">ALL Orders</button>*/}
                    {/*</div>*/}
                    {/*<div>*/}
                    {/*    <button className="nav-link text-dark">Users Orders</button>*/}
                    {/*</div>*/}

                </div>
                <div> {/*this div is content of the selected tab*/}
                    <div className="row adminEditOrder">
                        <p>OrderID: {this.props.location.ao.orderId}</p>
                        <p>UserID: {this.props.location.ao.id}</p>
                        <p>Users Name: {this.props.location.ao.user.userName}</p>
                    </div>
                    <table className="table" id="adminorderslist">
                        <thead>
                            <tr>
                                <th scope="col">Product Image</th>
                                <th scope="col">ArtNr</th>
                                <th scope="col">Name</th>
                                <th scope="col">Description</th>
                                <th className="productamount" scope="col">Amount</th>
                                <th scope="col">Price</th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.orderproducts.map((ap, index) => (
                            <tr key={index + 300} className="admineditorder">
                                <td><img src={ap.product.imgPath} className="admineditorder_img" alt="logo"  /></td>
                                <td>{ap.productId}</td>
                                <td>{ap.product.productName}</td>
                                <td>{ap.product.productDescription}</td>

                                <td><input className="productamount" type="number" name="inputproductamount" value={ap.amount}
                                        onChange={e => this.editProduct(ap.orderProductId, e.target.value)}
                                // dont know right now how to change the amount on 1 specific product in the array of orderproducts  /ER
                                /></td>

                                <td>{ap.product.productPrice}</td>
                                <td><button className="btn" onClick={() => this.removeProduct(ap.orderProductId)}>Delete</button></td>
                                <td><button className="btn " onClick={() => this.updateProductAmount(ap.orderProductId, ap)}>Update</button></td>
                            
                            </tr>
                        ))}
                        </tbody>
                    </table>
                   < br />
                    <br />
                    <div className="saveAndBackBtnDiv">
                       
                        <div>
                            <button onClick={() => this.saveEditedOrder} className="btn">SAVE</button></div>
                        
                        <div>
                            <button className="btn backBtn"><Link to={{ pathname: "/adminorders" }}>BACK</Link></button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
