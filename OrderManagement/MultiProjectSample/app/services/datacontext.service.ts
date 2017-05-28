import { Injectable } from "@angular/core";
import { Http, Headers, URLSearchParams } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/map";
import "rxjs/add/operator/debounceTime";

@Injectable()
export class DataContextService {
    constructor(private _http: Http) { }

    httpGet(url: string, parameters?: Object[]): Observable<any> {
        let observable: any;
        url = `./${url}`;
        if (parameters != undefined) {
            const search = new URLSearchParams();
            for (let count = 0; count < parameters.length; count++) {
                search.set(parameters[count][0], parameters[count][1]);
            }
            observable = this._http.get(url, { search }).map((response) => response.json());
        } else {
            observable = this._http.get(url).map((response) => response.json());
        }
        return observable;
    }

    httpPost(url: string, dataObject: any, fullUrl: boolean = false): Observable<any> {
        if (fullUrl === false) {
            url = `./${url}`;
        }
        const _headers = new Headers();
        _headers.append("Content-Type", "application/json");
        _headers.append("Access-Control-Allow-Origin", location.origin);
        const observable = this._http.post(url, JSON.stringify(dataObject), { headers: _headers }).map(response => response.json());
        return observable;
    }

    httpPut(url: string, id: number, model: any): Observable<any> {
        const _headers = new Headers();
        _headers.append("Content-Type", "application/json");
        _headers.append("Access-Control-Allow-Origin", location.origin);
        const observable = this._http.put(url + id, JSON.stringify(model), { headers: _headers }).map(response => response.json());
        return observable;
    }

    httpDelete(url: string, id: number): Observable<any> {
        const _headers = new Headers();
        _headers.append("Content-Type", "application/json");
        _headers.append("Access-Control-Allow-Origin", location.origin);
        const observable = this._http.delete(url + id, { headers: _headers }).map(response => response.json());
        return observable;
    }

}