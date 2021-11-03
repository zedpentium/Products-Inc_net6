import { Component, Fragment } from 'react';

import {
    Link
} from 'react-router-dom';

export default class AdminEditProduct extends Component {
    state = {
        product: {},
        editedProduct: {
            ProductName: '',
            ProductDescription: '',
            ImgPath: '',
            ImgData: '',
            ProductPrice: 0
        },
        msg: "",
        errorMsg: false
    }
    
    editProduct = () => {
        let t = this;
        $.ajax({
            url: `/api/product/${this.props.product.productId}`,
            method: 'PUT',
            Accept: "application/json",
            contentType: "application/json", 
            dataType: "json",
            data: JSON.stringify(t.state.editedProduct),
            success: function(response) {
            
                t.setState({errorMsg: false, msg: "Product successfully updated."})
                t.props.editCallback(response);
                     
           
            },
            error: function(err){
                t.setState({errorMsg: true, msg: "Product failed to be updated."})
            }
         }); 
    }
    setFile = file => {
        const reader = new FileReader();
        reader.onload = e => {
            this.setState({editedProduct: {...this.state.editedProduct, ImgPath: '', ImgData: btoa(String.fromCharCode.apply(null, new Uint8Array(e.target.result)))}}) 
        }

        reader.readAsArrayBuffer(file); 
    }
    deleteProduct(id){
        let t = this;

        $.ajax({
            url: `/api/product/${id}`,
            type: 'DELETE',
            success: function(response) {
                t.setState(oldState => ({
                    products: 
                        oldState.products.filter(p => p.productId !== id)        
            }));
            t.setState({errorMsg: false, msg: "Product successfully deleted."})
            },
            error: function(err){
                t.setState({errorMsg: true, msg: "Product failed to be deleted."})
            }
         }); 
        
    }
    render(){
        return  ( 
        <div>
             <p className={this.state.errorMsg ? 'text-danger' : 'text-success'}>{this.state.msg}</p>
           <form className="form" onSubmit={e => { e.preventDefault(); this.editProduct(); }}>
                <div className="form-group">
                    <label for="name-input">Product-name</label>
                    <input placeholder={this.props.product.productName} value={this.state.editedProduct.ProductName} className="form-control" type="text" id="name-input" onChange={e =>this.setState({editedProduct: { ...this.state.editedProduct, ProductName: e.target.value}})}/>
                </div>
                <div className="form-group">
                    <label for="description-input">Description</label>
                    <input className="form-control" placeholder={this.props.product.productDescription} value={this.state.editedProduct.ProductDescription} type="text" id="description-input" onChange={e => this.setState({editedProduct: { ...this.state.editedProduct, ProductDescription: e.target.value}})}/>
                </div>
                <div className="form-group">
                    <label for="price-input">Price</label>
                    <input className="form-control" type="number" id="price-input" placeholder={this.props.product.productPrice} value={this.state.editedProduct.ProductPrice} onChange={e => this.setState({editedProduct: { ...this.state.editedProduct, ProductPrice: Number(e.target.value)}})}/>
                </div>
                <div className="form-group">
                        <img src={this.props.product.imgPath} className="editProductImg img" alt={"logo"} />
                        <br />
                        <br/>
                    <label for="IMG-input">IMG</label>
                    <input className="form-control" type="file" id="IMG-input" onChange={e => { this.setFile(e.target.files[0]); }}/>
                    </div>
                    <div className="ButtonsEditProducts">
                        
                            <button type="submit" className="btn submitBtnDiv">Update</button> 
                            <button className="btn deleteBtn btn-warning" onClick={() => this.deleteProduct(this.props.product.productId)}>DELETE</button>
                            <button className="btn backBtn" onClick={() => this.props.return(false)}>BACK</button>
                        
                    </div>
                    <br />
                    <br />
                    <br />
                </form>
                

    </div>
    )
    }
}