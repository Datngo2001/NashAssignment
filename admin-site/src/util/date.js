export function convertDDMMYYYY(input) {
    const date = new Date(input);
    const yyyy = date.getFullYear();
    let mm = date.getMonth() + 1; // Months start at 0!
    let dd = date.getDate();

    if (dd < 10) dd = '0' + dd;
    if (mm < 10) mm = '0' + mm;

    return dd + '/' + mm + '/' + yyyy;
}

export function dateDiffInDays(date1, date2) {
    return Math.round((date1 - date2) / (1000 * 60 * 60 * 24));
}