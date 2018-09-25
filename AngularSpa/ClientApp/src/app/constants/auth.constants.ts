import { appConfig } from "./app.constants";
import { WebStorageStateStore, UserManagerSettings } from "oidc-client";

export const authConfig: UserManagerSettings = {
    authority: `${appConfig.stsUrl}`,
    redirect_uri: `${appConfig.appRoot}assets/signin-oidc.html`,
    client_id: 'angular-spa',
    scope: 'openid profile',
    response_type: 'id_token token',
    post_logout_redirect_uri: `${appConfig.appRoot}signout-oidc`,
    loadUserInfo: false,
    silent_redirect_uri: `${appConfig.appRoot}assets/signin-oidc.html`,
    userStore: new WebStorageStateStore({ store: window.localStorage }),
    
};
