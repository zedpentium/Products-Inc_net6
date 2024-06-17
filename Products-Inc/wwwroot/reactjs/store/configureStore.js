import { createStore } from 'redux'
//import rootReducer from './reducer'
import { composeWithDevTools } from 'redux-devtools-extension'


//export default function configureStore(preloadedState) {
    
//    const store = createStore(composeWithDevTools, preloadedState)

//    return store
//}

const reduxstore = createStore(composeWithDevTools)

export default reduxstore