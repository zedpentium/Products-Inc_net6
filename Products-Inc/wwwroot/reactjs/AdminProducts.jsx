import React, { Component, Fragment } from 'react';
import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect,
    browserHistory
} from 'react-router-dom';
import CreateProduct from './CreateProduct.jsx';
import AdminEditProduct from './AdminEditProduct.jsx';

export default class AdminProducts extends Component{
    state = {
        showCreateProduct: false,
        errorMsg: false,
        products: [],
        msg: ""
    }
    componentDidMount(){
        
        let t = this;
        
        $.get("/api/product", function(){})
        .done(res => { t.setState({products: res}); console.log(res)})
        .fail(e => console.log(e))
    }
    addProduct = p => {
        this.setState(oldState => ({showCreateProduct: false, products: [...oldState.products, p]}))
    }
    editCallback = (product) => {
               
        this.setState(oldState => ({products: oldState.products.map(p => 
            { if(product.productId === p.productId){ 
                    return product
            }
            else{
                return p
            }
        })

      }))
      
    }
    render() {
        $(window).scrollTop(0)
        return (
           
            <div>
                <div>
                    { this.state.showCreateProduct ?   <div className="nav-item createProductBtn">
                        <button className="nav-link btn" onClick={e => { e.preventDefault(); this.setState({showCreateProduct: !this.state.showCreateProduct })}}>All Products</button>
                    </div> : 
                    <div className="nav-item createProductBtn">
                        <button onClick={e => { e.preventDefault(); this.setState({showCreateProduct: !this.state.showCreateProduct })}} className="nav-link btn">Create new Product</button>
                    </div>
                    }
                  
                    
                    <br />
                    <br />
                    <br />
                    <br />
                 </div>
            <div> 
                {
                this.state.showCreateProduct ? 
                <CreateProduct goBack={this.addProduct}/> : 
                <div>
                <table className="table" id="adminproductlist">
                    <thead>
                        <tr>
                            <th></th>
                            <th scope="col">ProductID</th>
                            <th scope="col">Productname</th>
                            <th scope="col">Price</th>
                            <th></th>
               
                        </tr>
                    </thead>
               <AdminProductTable editCallback={this.editCallback} products={this.state.products}/>
                </table> 
                </div>  } </div>
                
                 </div>
           
        )
        }
}


function AdminProductTable({products, editCallback}){
    return ( <tbody>
      
      {products.map(p => <AdminProduct editCallback={editCallback} key={p.productId} product={p} />)}
         </tbody>
         
    )
}
function AdminProduct({product, editCallback}){

    const [showEditProduct, setShowEditProduct] = React.useState(false);

    
     if(showEditProduct) return (  <AdminEditProduct editCallback={editCallback} product={product} return={setShowEditProduct}/> )
     else 
        return (
    <tr>
    <td scope="row"><img src={product.imgPath}  className="admineditorder_img" alt="logo" /></td>
    <td scope="row">{product.productId}</td>
    <td scope="row">{product.productName}</td>
    <td scope="row">{product.productPrice}</td>
    <td>
        <div className="showEditDiv">
            <button className="showEditButton" onClick={() => setShowEditProduct(!showEditProduct)}>SHOW / EDIT</button>
        </div>
    </td>
   
    </tr> 
    )

    
}




