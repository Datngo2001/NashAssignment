
async function getAPI(url) {
    try {
        const response = await fetch(`${API_URL}${url}`, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const jsonResult = await response.json();
        return jsonResult
    } catch (error) {
        console.log(error)
    }
}

async function postAPI(url, body) {
    try {
        const response = await fetch(`${API_URL}${url}`, {
            method: 'POST',
            body: body, // string or object
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const jsonResult = await response.json();
        return jsonResult
    } catch (error) {
        console.log(error)
    }
}

async function putAPI(url, body) {
    try {
        const response = await fetch(`${API_URL}${url}`, {
            method: 'PUT',
            body: body, // string or object
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const jsonResult = await response.json();
        return jsonResult
    } catch (error) {
        console.log(error)
    }
}

async function deleteAPI(url, body) {
    try {
        const response = await fetch(`${API_URL}${url}`, {
            method: 'DELETE',
            body: body, // string or object
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const jsonResult = await response.json();
        return jsonResult
    } catch (error) {
        console.log(error)
    }
}