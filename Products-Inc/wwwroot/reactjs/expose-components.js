// Content/components/expose-components.js

import React from 'react';
import ReactDOM from 'react-dom';
import ReactDOMServer from 'react-dom/server';
/*import ReactRouter from 'react-router-dom';*/


/*import RootComponent from './Index.jsx';*/

/*import Router from './Router.jsx';*/
import Index from './Index.jsx';
//import ContactUs from './ContactUs.jsx';


// any css-in-js or other libraries you want to use server-side
//import { ServerStyleSheet } from 'styled-components';
/*import { renderStylesToString } from 'emotion-server';*/
import Helmet from 'react-helmet';

//const rootElement = document.getElementById('root')
//ReactDOM.render(
//    <Provider store={store}>
//        <App />
//    </Provider>,
//    rootElement
//)

global.React = React;
global.ReactDOM = ReactDOM;
global.ReactDOMServer = ReactDOMServer;
/*global.ReactRouter = ReactRouter;*/

/*global.Styled = { ServerStyleSheet };*/
global.Helmet = Helmet;

global.Components = { Index };