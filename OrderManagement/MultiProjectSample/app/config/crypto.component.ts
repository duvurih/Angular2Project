declare var require: any;
declare var module: { id: string };

// import { Injectable, EventEmitter } from "@angular/core";

import { DataContextService } from "../services/datacontext.service";
import { ConfigComponent } from "../config/config.component";

export class CryptoComponent {
    constructor(private dataContextService: DataContextService) {

    }

    getDefaults():any {
        return this.dataContextService.httpGet("api/Configuration/GetDefaults");
    }

    encryptContent(inputData:any):any {
        var CryptoJS:any = require("crypto-js");
        var encrResponse:any = CryptoJS.AES.encrypt(JSON.stringify(inputData), ConfigComponent.cryptographicKey);
        return encrResponse;
    }

    decryptContent(inputData:any):any {
        var CryptoJS:any = require("crypto-js");
        var bytes:any = CryptoJS.AES.decrypt(inputData.toString(), ConfigComponent.cryptographicKey);
        var decryptedData:any = JSON.parse(bytes.toString(CryptoJS.enc.Utf8));
        return decryptedData;
    }
}