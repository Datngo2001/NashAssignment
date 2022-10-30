import Oidc from "oidc-client"

var config = {
    authority: "https://localhost:5001",
    client_id: "js",
    redirect_uri: "http://localhost:3000/callback",
    response_type: "code",
    scope: "openid profile AssignmentAPI",
    post_logout_redirect_uri: "http://localhost:3000/",
    response_mode: "query",
};
const UserManager = new Oidc.UserManager(config);

export default UserManager