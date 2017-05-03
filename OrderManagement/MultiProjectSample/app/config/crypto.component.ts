declare var require: any;
declare var module: { id: string };

import { Injectable, EventEmitter } from '@angular/core';

import { DataContextService } from '../services/datacontext.service';
import { ConfigComponent } from '../config/config.component';

export class CryptoComponent {
    constructor(private dataContextService: DataContextService) {

    }

    getDefaults() {
        return this.dataContextService.httpGet('api/Configuration/GetDefaults');
    }

    encryptContent(inputData:any) {
        var CryptoJS = require("crypto-js");
        var encrResponse = CryptoJS.AES.encrypt(JSON.stringify(inputData), ConfigComponent.cryptographicKey);
        return encrResponse;
    }

    decryptContent(inputData:any) {
        var CryptoJS = require("crypto-js");
        var bytes = CryptoJS.AES.decrypt(inputData.toString(), ConfigComponent.cryptographicKey);
        var decryptedData = JSON.parse(bytes.toString(CryptoJS.enc.Utf8));
        return decryptedData;
    }
}