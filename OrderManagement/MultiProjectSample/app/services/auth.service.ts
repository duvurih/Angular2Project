﻿import { Injectable } from "@angular/core";
import { Http, Headers } from "@angular/http";

import { DataContextService } from "./datacontext.service";

@Injectable()
export class AuthService {
    // private component: any;
    private isLoggedin: boolean;
    // private authData: any;

    constructor(
        private dataContextService: DataContextService,
        private _http: Http
    ) {

    }

    validateUser(user: any):any {
        return this.dataContextService.httpPost("api/Account/Login", user);
    }

    loginfn(userCredentials: any):any {
        this.isLoggedin = false;
        var _headers:any = new Headers();
        var creds:any = "username=" + userCredentials.username + "&password=" + userCredentials.password + "&grant_type=password";
        // var creds = {
        //    username: userCredentials.username,
        //    password: userCredentials.password,
        //    grant_type: "password"
        // }
        _headers.append("Content-Type", "application/x-www-form-urlencoded");
        return new Promise((resolve) => {
            // this.dataContextService.httpPost("http://localhost:60541/token", creds,true).subscribe((data:any) => {
            //    if (data.json().success) {
            //        window.localStorage.setItem("auth_key", data.json().token);
            //        this.isLoggedin = true;
            //    }
            //    resolve(this.isLoggedin);
            // });
            this._http.post("http://localhost:60541/token", creds, { headers: _headers }).subscribe(response => {
                if (response.status===200) {
                    window.localStorage.setItem("auth_key", response.json().access_token);
                    this.isLoggedin = true;
                }
                resolve(this.isLoggedin);
            });
        });
    }

    isUserLoggedIn():any {
        return this.isLoggedin;
    }
}