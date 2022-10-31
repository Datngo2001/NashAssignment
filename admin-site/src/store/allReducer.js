import { combineReducers } from 'redux'
import productReducer from './reducer/product/productReducer'
import userReducer from './reducer/user/userReducer'

export default combineReducers({
    user: userReducer,
    product: productReducer,
})