import { Component, Fragment } from 'react';

export default class Products extends Component {

    constructor(props) {
        super(props)
        this.state = {
            products: []
            /*pollInterval: 2000*/
        }
    }

    loadDataFromServer = e => {
        const xhr = new XMLHttpRequest();
        xhr.open('get', "api/product", true)
        xhr.onload = () => {
            const productlist = JSON.parse(xhr.responseText)

            this.setState({ products: productlist })

        }
        xhr.send()

    }

    componentDidMount = () => {
        this.loadDataFromServer();
        //window.setInterval(this.loadDataFromServer(), this.state.pollInterval)
    }


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
        return (
            <div>

                {/*carousel code goes here*/}
                <div className="content overflow-auto">
                    <div id="demo" className="carousel slide" data-bs-ride="carousel">
                        <div className="carousel-indicators">
                            <button type="button" data-bs-target="#demo" data-bs-slide-to="0" class="active"></button>
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
                            <div class="carousel-item">
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

                    { this.state.products.map(p => (
                            <Product product={p} addProductEvent={this.addProduct}/>

                    ))}
                </div>
            </div>

        )
    }
}





function Product({ product, addProductEvent }) {
    const [amount, setAmount] = React.useState(1);
    return (
        <div key={product.productId.toString()} className="product w-2 m-2">
                            <div>
                                <img src={product.imgPath} className="text-center product-img" alt="Product image"></img>
                                <div className="wrapper">
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
                        </div>
    )
}

