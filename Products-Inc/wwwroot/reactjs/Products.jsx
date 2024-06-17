import { Component, Fragment } from 'react';
import axios from 'axios';

export default class Products extends Component {

    constructor(props) {
        super(props)
        this.state = {
            error: null,
            isLoaded: false,
            products: []
            /*pollInterval: 2000*/
        }
    }

    //const axios = require('axios').default;

    //loadDataFromServer = () => {
    //    //e.preventDefault();

    //    let t = this;

    //    axios.get("/api/product")
    //        .then(function (response) {
    //            //console.log(response.data);
    //            //console.log(response.status);
    //            //console.log(response.statusText);
    //            //console.log(response.headers);
    //            //console.log(response.config);
    //            t.setState({ products: response.data })
    //        })

    //        .catch(function (error) {
    //            if (error.response) {
    //                // The request was made and the server responded with a status code
    //                // that falls out of the range of 2xx
    //                console.log(error.response.data);
    //                console.log(error.response.status);
    //                console.log(error.response.headers);
    //            } else if (error.request) {
    //                // The request was made but no response was received
    //                // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
    //                // http.ClientRequest in node.js
    //                console.log(error.request);
    //            } else {
    //                // Something happened in setting up the request that triggered an Error
    //                console.log('Error', error.message);
    //            }
    //            console.log(error.config);
    //        })

        //$.ajax({
        //    url: "/api/product",
        //    method: "GET",
        //    //data: JSON.stringify(this.state.loginModel),
        //    accepts: { json: "application/json" },
        //    //contentType: "application/json",
        //    dataType: "json",
        //    success: function (res) {

        //        this.setState({
        //            isLoaded: true,
        //            products: result.items
        //        });

        //const xhr = new XMLHttpRequest();
        //xhr.open('get', "api/product", true)
        //xhr.onload = () => {
        //    const productlist = JSON.parse(xhr.responseText)

        //    this.setState({ products: productlist })

        //}
        //xhr.send()



        //},

        //    error: function (jqXHR, textStatus, errorThrown) {
        //        /*console.log(jqXHR);*/
        //        //console.log(textStatus);
        //        //console.log(errorThrown);
        //        //t.setState({ wronglogin: true })
        //        //t.setState({ redirect: true })

        //        this.setState({
        //            isLoaded: true,
        //            error
        //        })
        //    }


        //    })

/*    }*/


    componentDidMount = () => {

        let t = this;

        axios.get("/api/product")
            .then(function (response) {
                //console.log(response.data);
                //console.log(response.status);
                //console.log(response.statusText);
                //console.log(response.headers);
                //console.log(response.config);
                t.setState({
                    isLoaded: true,
                    products: response.data
                })

            })

            .catch(function (error) {
                this.setState({
                    isLoaded: true,
                    error
                })

                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log(error.response.data);
                    console.log(error.response.status);
                    console.log(error.response.headers);
                } else if (error.request) {
                    // The request was made but no response was received
                    // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
                    // http.ClientRequest in node.js
                    console.log(error.request);
                } else {
                    // Something happened in setting up the request that triggered an Error
                    console.log('Error', error.message);
                }
                console.log(error.config);
            })

    }


        //this.loadDataFromServer();


        //window.setInterval(this.loadDataFromServer(), this.state.pollInterval)



         //$.ajax({
         //   url: "/api/product",
         //   method: "GET",
         //   //data: JSON.stringify(this.state.loginModel),
         //   accepts: { json: "application/json" },
         //   //contentType: "application/json",
         //   dataType: "json",
         //   success: function (res) {

         //       this.setState({
         //           isLoaded: true,
         //           products: result.items
         //       });

        //const xhr = new XMLHttpRequest();
        //xhr.open('get', "api/product", true)
        //xhr.onload = () => {
        //    const productlist = JSON.parse(xhr.responseText)

        //    this.setState({ products: productlist })

        //}
        //xhr.send()






    addProduct = (product, amount) => {
        let t = this;
        let shoppingCartProduct = {
            product, amount, productId: product.productId
        };
        $.ajax({
            url: "/api/shoppingcart/products",
            method: "POST",
            data: JSON.stringify(shoppingCartProduct),
            //accepts: "application/json",
            contentType: "application/json",
            dataType: "json",
            success: function(res) {

                if(t.props.location.setNrOfProducts)
                    t.props.location.setNrOfProducts(amount)
                else{
                    t.props.setNrOfProducts(amount);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }




    render() {
        /*$(window).scrollTop(0)*/
/*        return (*/

        const { error, isLoaded, products } = this.state;
        if (error) {
            return ( <div>Error: {error.message}</div> )
        } else if (!isLoaded) {
            return (
                <div><br />Loading products...</div>
            )
        } else {
            return (

                <div>

                    {/*carousel code goes here*/}
                    <div className="carouseldiv overflow-auto">
                        <div id="demo" className="carousel slide" data-bs-ride="carousel">
                            <div className="carousel-indicators">
                                <button type="button" data-bs-target="#demo" data-bs-slide-to="0" className="active"></button>
                                <button type="button" data-bs-target="#demo" data-bs-slide-to="1"></button>
                                <button type="button" data-bs-target="#demo" data-bs-slide-to="2"></button>
                            </div>
                            <div className="carousel-inner">

                                <div className="carousel-item active">
                                    <img className="carouselImage d-block" src="./img/img18.jpg" alt="Los Angeles" />
                                    <div className="quotes carousel-caption">
                                        <p>EATING ORGANIC ISN't A TREND </p>
                                        <p>IT'S A RETURN TO TRADITION </p>
                                    </div>
                                </div>
                                <div className="carousel-item">
                                    <img className="carouselImage d-block" src="./img/img19.jpg" alt="Chicago" />
                                    <div className="quotes carousel-caption">

                                    </div>
                                </div>
                                <div className="carousel-item">
                                    <img className="carouselImage d-block" src="./img/img20.jpg" alt="New York" />
                                    <div className="quotes carousel-caption">

                                    </div>
                                </div>
                            </div>

                            <button className="carousel-control-prev" type="button" data-bs-target="#demo" data-bs-slide="prev">
                                <span className="carousel-control-prev-icon"></span>
                            </button>
                            <button className="carousel-control-next" type="button" data-bs-target="#demo" data-bs-slide="next">
                                <span className="carousel-control-next-icon"></span>
                            </button>
                        </div>

                    </div>

                    <div className="products-holder d-flex p-2 justify-content-center flex-wrap overflow-auto">
                        {products.map(p => (
                            <div key={p.productId} className="productdiv w-2">

                                <Product product={p} addProductEvent={this.addProduct} />

                            </div>


                        ))}
                    </div>

                </div>
            )

        }


    } // Render Endtag


} // Class endtag





function Product({ product, addProductEvent }) {
    const [amount, setAmount] = React.useState(1);
    return (
        
                            <div>
                                <img src={product.imgPath} className="text-center product-img" alt="Product image"></img>
                                <div className="producttextwrapper">
                                    <div className="product-info">
                                        <h4>{product.productName}</h4>
                                        <p>{product.productPrice} kr</p>
                                         <p>{product.productDescription}</p>
                                    </div>

                                    <div className="product-input d-flex align-items-end justify-content-end">
                                        <input  className="addNumberOfItems"type="number" value={amount} onChange={e => setAmount(Number(e.target.value))}/>
                                        <button className="btn" onClick={e => { e.preventDefault(); addProductEvent(product, amount);}}>ADD</button>
                                    </div>
                                </div>
                            </div>

    )
}

