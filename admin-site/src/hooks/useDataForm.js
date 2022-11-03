import { useForm } from 'react-hook-form';
import { CREATE, UPDATE, DETAIL } from "./_dataAction"

function useDataForm({ action }) {
    const formHook = useForm();
    const CREATING = action === CREATE
    const UPDATING = action === UPDATE
    const DETAILING = action === DETAIL

    return { ...formHook, CREATING, UPDATING, DETAILING }
}

export default useDataForm