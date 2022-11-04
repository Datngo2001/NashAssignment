export function removeElementById(arr, toRemove) {
    let index = arr.findIndex(c => c.id === toRemove.id)
    arr.splice(index, 1)
    return arr
}

export function updateElementById(arr, toUpdate) {
    let index = arr.findIndex(c => c.id === toUpdate.id)
    arr[index] = toUpdate;
    return arr
}