
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