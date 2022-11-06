export function closeAndTriggerCallBack({ payload }) {
    if (payload.result) {
        if (payload.onYes)
            payload.onYes();
    } else {
        if (payload.onNo)
            payload.onNo();
    }
}