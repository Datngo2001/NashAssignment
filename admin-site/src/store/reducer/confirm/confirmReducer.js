import { CLOSE_CONFIRM_DIALOG, OPEN_CONFIRM_DIALOG } from "./confirmActionTypes";

const init = {
    open: false,
    message: "",
    onYes: null,
    onNo: null
}

export default function confirmReducer(state = init, { type, payload }) {
    switch (type) {
        case OPEN_CONFIRM_DIALOG:
            return {
                ...state,
                open: true,
                message: payload.message,
                onYes: payload.onYes,
                onNo: payload.onNo
            }
        case CLOSE_CONFIRM_DIALOG:
            return {
                ...init,
            }
        default:
            return state;
    }
}
