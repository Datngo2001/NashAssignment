export function closeAndTriggerCallBack({ payload }) {
    debugger
    if (payload.result) {
        if (payload.onYes)
            payload.onYes();
    } else {
        if (payload.onNo)
            payload.onNo();
    }
}