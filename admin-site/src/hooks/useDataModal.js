import { useState } from 'react'
import { CREATE, UPDATE, DETAIL } from "./_dataAction"

function useDataModal() {
    const [dataModal, setDataModal] = useState({
        open: false,
        data: undefined,
        action: CREATE,
        handleSave: () => { }
    });

    const openCreateModal = (onSave) => {
        setDataModal({
            open: true,
            data: undefined,
            action: CREATE,
            handleSave: onSave ? (data) => { onSave(data); closeModal(); } : () => { }
        });
    }

    const openDetailModal = (data) => {
        setDataModal({
            open: true,
            data: data,
            action: DETAIL,
        });
    };

    const openUpdateModal = (init, onSave) => {
        setDataModal({
            open: true,
            data: init,
            action: UPDATE,
            handleSave: onSave ? (data) => { onSave(data); closeModal(); } : () => { }
        });
    };

    const closeModal = () => {
        setDataModal({
            open: false,
            category: null,
            action: CREATE,
        });
    }

    return { dataModal, openCreateModal, openDetailModal, openUpdateModal, closeModal }
}

export default useDataModal