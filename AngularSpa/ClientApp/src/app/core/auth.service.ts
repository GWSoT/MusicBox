import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { UserManager, User } from 'oidc-client';
import { authConfig } from '../constants/auth.constants';


@Injectable()
export class AuthService {
    private _userManager: UserManager;
    private _user: User;


    constructor(private httpClient: HttpClient) {
        this._userManager = new UserManager(authConfig);
        this._userManager.getUser().then(user => {
            if (user && !user.expired) {
                this._user = user;
            }
            console.log(user);
        }); 
    }

    login(): Promise<any> {
        return this._userManager.signinRedirect();
    }

    logout(): Promise<any> {
        return this._userManager.signoutRedirect();
    }

    isLoggedIn(): boolean {
        return this._user && this._user.access_token && !this._user.expired;
    }

    getAccessToken(): string {
        return this._user ? this._user.access_token : '';
    }
}