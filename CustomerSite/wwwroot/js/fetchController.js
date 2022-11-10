
async function getView(url) {
    try {
        const response = await fetch(`${BASE_URL}${url}`, {
            headers: {
                'Content-Type': 'text/html'
            }
        });
        const view = await response.text()
        return view
    } catch (error) {
        console.log(error)
    }
}

async function postAction(url, body, headers) {
    try {
        const response = await fetch(`${BASE_URL}${url}`, {
            method: 'POST',
            body: JSON.stringify(body), // string or object
            headers: {
                ...headers,
                'Content-Type': 'application/json'
            }
        });
        const jsonResult = await response.json();
        return jsonResult
    } catch (error) {
        console.log(error)
    }
}
