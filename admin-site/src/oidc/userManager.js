import Oidc from "oidc-client"

var config = {
    authority: "https://localhost:5001",
    client_id: "js",
    redirect_uri: "https://localhost:5003/callback",
    response_type: "code",
    scope: "openid profile AssignmentAPI",
    post_logout_redirect_uri: "https://localhost:5003/index.html",
};
const UserManager = new Oidc.UserManager(config);

export default UserManager