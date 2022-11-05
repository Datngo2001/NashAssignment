import { useDispatch } from 'react-redux'
import { OPEN_CONFIRM_DIALOG } from '../store/reducer/confirm/confirmActionTypes';

function useConfirmModal() {
    const dispatch = useDispatch();
    const openConfirm = ({ message, onYes, onNo }) => {
        dispatch({
            type: OPEN_CONFIRM_DIALOG,
            payload: {
                message, onYes, onNo
            }
        })
    }

    return openConfirm
}

export default useConfirmModal