import { combineReducers } from 'redux'
import productReducer from './reducer/product/productReducer'
import userReducer from './reducer/user/userReducer'
import categoryReducer from './reducer/category/categoryReducer'
import confirmReducer from './reducer/confirm/confirmReducer'
import customerReducer from './reducer/customer/customerReducer'

export default combineReducers({
    user: userReducer,
    product: productReducer,
    category: categoryReducer,
    confirm: confirmReducer,
    customer: customerReducer,
})