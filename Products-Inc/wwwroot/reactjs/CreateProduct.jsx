import { Component } from 'react';


export default class CreateProduct extends Component {
    state = {
        createdProduct: {
            ProductName: '',
            ProductDescription: '',
            ImgPath: '',
            ImgData: '',
            ProductPrice: 0
        },
        errorMsg: ''
    }
    checkData = () => {
        let product = this.state.createdProduct;
        let errorMsg = '';

        if(!product.ProductName){
            this.setState({errorMsg: "Productname cannot be empty."})
            return false;
        }
        else if(!product.ProductDescription){
            this.setState({errorMsg: "Productdescription cannot be empty."})
            return false;
        }
        else if(!product.ImgData){
            this.setState({errorMsg: "Image not chosen."})
            return false;
        }
        else if(product.ProductPrice <= 0){
            this.setState({errorMsg: "Price not set."})
            return false;
        }

        return true;
    }
    postProduct = () => {
        if(this.checkData()){
            let t = this;
            $.ajax({      
                url: "/api/product",
                type: "POST",
                data: JSON.stringify(this.state.createdProduct),
                Accept: "application/json",
                contentType: "application/json", 
                dataType: "json",
                success: function(res) {
                    t.setState({createdProduct: { 
                                    ProductName: '',
                                    ProductDescription: '',
                                    ImgPath: '',
                                    ImgData: '',
                                    ProductPrice: 0}
                                , errorMsg: ''})
                    $("#IMG-input").val(null)
                    t.props.goBack(res);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    t.setState({errorMsg: errorThrown});
                }
            });
        }
    }
    setFile = file => {
        const reader = new FileReader();
        reader.onload = e => {
            this.setState({createdProduct: {...this.state.createdProduct, ImgData: btoa(String.fromCharCode.apply(null, new Uint8Array(e.target.result)))}}) 
        }

        reader.readAsArrayBuffer(file); 
    }
    render() {
        $(window).scrollTop(0)
        return (
             <div>
                 <p className="text-danger">{this.state.errorMsg}</p>
            <form className="form" onSubmit={e => { e.preventDefault(); this.postProduct(); }}>
                <div className="form-group">
                    <label for="name-input">Product-name</label>
                    <input value={this.state.createdProduct.ProductName} className="form-control" type="text" id="name-input" onChange={e =>this.setState({createdProduct: { ...this.state.createdProduct, ProductName: e.target.value}})}/>
                </div>
                <div className="form-group">
                    <label for="description-input">Description</label>
                    <input className="form-control"  value={this.state.createdProduct.ProductDescription} type="text" id="description-input" onChange={e => this.setState({createdProduct: { ...this.state.createdProduct, ProductDescription: e.target.value}})}/>
                </div>
                <div className="form-group">
                    <label for="price-input">Price</label>
                    <input className="form-control" type="number" id="price-input"  value={this.state.createdProduct.ProductPrice} onChange={e => this.setState({createdProduct: { ...this.state.createdProduct, ProductPrice: Number(e.target.value)}})}/>
                </div>
                <div className="form-group">
                    <label for="IMG-input">IMG</label>
                    <input className="form-control" type="file" id="IMG-input" onChange={e => { this.setFile(e.target.files[0]); }}/>
                    </div>
                    <div className="createBtnDiv">
                        <button type="submit" className="btn">Create</button>
                    </div>
            </form>
        </div>
        )
    }
}
