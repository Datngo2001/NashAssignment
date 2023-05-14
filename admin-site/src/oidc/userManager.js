import Oidc from "oidc-client"

var config = {
    authority: "https://group01-softwaretesting-auth.azurewebsites.net",
    client_id: "js",
    redirect_uri: "https://zealous-bush-0329e9010.3.azurestaticapps.net/callback",
    response_type: "code",
    scope: "openid profile AssignmentAPI",
    post_logout_redirect_uri: "https://zealous-bush-0329e9010.3.azurestaticapps.net/",
    response_mode: "query",
};
const UserManager = new Oidc.UserManager(config);

export default UserManager