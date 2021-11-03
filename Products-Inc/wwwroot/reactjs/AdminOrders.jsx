import { Component, Fragment } from 'react';
import {
    Link,
    BrowserRouter,
    Route,
    Switch,
    StaticRouter,
    Redirect,
    browserHistory
} from 'react-router-dom';



export default class AdminOrders extends Component {

    constructor(props) {
        super(props)
        this.state = {
            allorders: []
        }
    }


//    orderDetails(orderdetails) {
//        this.props.history.push("/admineditorder", { state: orderdetails });
//}


        loadDataFromServer = e => {
            const xhr = new XMLHttpRequest();
            xhr.open('get', "api/order", true)
            xhr.onload = () => {
                const allorderslist = JSON.parse(xhr.responseText)
                console.log(allorderslist)
                this.setState({ allorders: allorderslist })

            }
            xhr.send()
        }

    componentDidMount = () => {
            this.loadDataFromServer();
            //window.setInterval(this.loadDataFromServer(), this.state.pollInterval)
        }



    
    render() {
       $(window).scrollTop(0)
            return (
                <div>                  
                    <br />
                    <div> {/*this div is sidemenu-tab*/}
                        <div className="nav-item">
                            <button className="nav-link btn createProductBtn">ALL Orders</button>
                        </div>
                        <div>
                            <button className="nav-link btn createProductBtn">Users Orders</button>
                            {/*<p>isuserlogged: {this.props.propstest}</p>*/}
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />

                    </div>
                    <div> {/*this div is content of the selected tab*/}
                        
                        <table className="table" id="adminorderslist">
                            <thead>
                                <tr>
                                    <th scope="col">OrderID</th>
                                    <th scope="col">UserID</th>
                                    <th scope="col">UserName</th>
                                    <th>Options</th>
                                </tr>
                            </thead>
                            <tbody>
                                {/*onClick={() => this.orderDetails(ao)}*/}
                                        {this.state.allorders.map(ao => (
                                            <tr key={ao.orderId} className="allorders">
                                                <td scope="row">{ao.orderId}</td>
                                                <td scope="row">{ao.user.id}</td>
                                                <td scope="row">{ao.user.userName}</td>
                                                <td><button className="showEditButton">
                                                    <Link to={{ pathname: "/admineditorder", ao }}>SHOW / EDIT</Link>
                                                </button></td>

                                            </tr>
                                        ))}
                            </tbody>
                        </table>
                    </div>
                </div>
        )

    }
}



//function orderDetails(orderdetails) {
//    const editorder = {
//        pathname: '/admineditorder',
//        state: { orderdetailprops: orderdetails }
//    }
//    /*let history = useHistory();*/
//    /*<AdminEditOrder orderobj={ao} />*/
//    /*console.log(ao)*/
//    /*<Redirect push to="/admineditorder" />*/
//    //this.props.history.push('/products')
//    //console.log(this.props.hist)
//    //function orderDetails(ao) {
//    //    history.push("/admineditorder");
//    //}
//    this.props.history.push(editorder)
//}
