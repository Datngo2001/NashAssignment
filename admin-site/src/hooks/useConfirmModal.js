import { useState } from 'react'

function useConfirmModal({ open, message }) {
    const [confirm, setConfirm] = useState({
        open: false,
        message: message,
        onYes: null,
        onNo: null
    })

    const onAnswer = (result) => {
        if (result) {
            if (confirm.onYes)
                confirm.onYes();
        } else {
            if (confirm.onNo)
                confirm.onNo();
        }

        setConfirm(val => ({
            ...val,
            open: false,
        }))
    }

    const openNewConfirm = (onYes, onNo) => {
        setConfirm({
            open: true,
            message: message,
            onYes: onYes,
            onNo: onNo
        })
    }

    return { confirm, openNewConfirm, onAnswer }
}

export default useConfirmModal