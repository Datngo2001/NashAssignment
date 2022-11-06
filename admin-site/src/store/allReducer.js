import { combineReducers } from 'redux'
import productReducer from './reducer/product/productReducer'
import userReducer from './reducer/user/userReducer'
import categoryReducer from './reducer/category/categoryReducer'
import confirmReducer from './reducer/confirm/confirmReducer'

export default combineReducers({
    user: userReducer,
    product: productReducer,
    category: categoryReducer,
    confirm: confirmReducer,
})