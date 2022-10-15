const API_URL = "https://localhost:7238/api/"

async function getAPI(url) {
    const response = await fetch(`${API_URL}${url}`, {
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const jsonResult = await response.json();
    return jsonResult
}

async function postAPI(url, body) {
    const response = await fetch(`${API_URL}${url}`, {
        method: 'POST',
        body: body, // string or object
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const jsonResult = await response.json();
    return jsonResult
}

async function putAPI(url, body) {
    const response = await fetch(`${API_URL}${url}`, {
        method: 'PUT',
        body: body, // string or object
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const jsonResult = await response.json();
    return jsonResult
}

async function deleteAPI(url, body) {
    const response = await fetch(`${API_URL}${url}`, {
        method: 'DELETE',
        body: body, // string or object
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const jsonResult = await response.json();
    return jsonResult
}