import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { AuthService } from "../../services/auth.service";

@Component({
    selector: "login",
    templateUrl: `app/public/login/login.html`,
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    localUser = {
        username: "admin",
        password: "admin"
    };

    constructor(
        private _authService: AuthService,
        private _formBuilder: FormBuilder,
        private _router: Router
    ) { }

    ngOnInit():any {
        this.generateFormGroup();
    }

    generateFormGroup():any {
        this.loginForm = this._formBuilder.group({
            username: ["", [Validators.required, Validators.maxLength(50)]],
            password: ["", [Validators.required, Validators.maxLength(12)]]
        });
    }

    login():any {
        this._authService.loginfn(this.localUser).then((res:any) => {
            if (res) {
                // window.location.href = "./dashboard";
                this._router.navigate(["dashboard"]);
            } else {
                console.log(res);
            }
        });
    }

}