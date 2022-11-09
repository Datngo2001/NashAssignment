import { useForm } from 'react-hook-form';
import { CREATE, UPDATE, DETAIL } from "./_dataAction"

function useDataForm(props) {
    const formHook = useForm(props);
    const CREATING = props.action === CREATE
    const UPDATING = props.action === UPDATE
    const DETAILING = props.action === DETAIL

    return { ...formHook, CREATING, UPDATING, DETAILING }
}

export default useDataForm