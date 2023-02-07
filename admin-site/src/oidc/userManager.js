import Oidc from "oidc-client"

var config = {
    authority: "https://localhost:7167",
    client_id: "js",
    redirect_uri: "http://localhost:3000/callback",
    response_type: "code",
    scope: "openid profile API.read API.write",
    post_logout_redirect_uri: "http://localhost:3000/",
};
const UserManager = new Oidc.UserManager(config);

export default UserManager