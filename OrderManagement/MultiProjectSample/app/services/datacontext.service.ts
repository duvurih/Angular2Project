import { Injectable } from '@angular/core';
import { Http, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';

@Injectable()
export class DataContextService {
    constructor(private _http: Http) { }

    httpGet(url: any, parameters?: Object[]) {
        let observable: any;
        url = `./${url}`;
        if (parameters != undefined) {
            const search = new URLSearchParams();
            for (let count = 0; count < parameters.length; count++) {
                search.set(parameters[count][0], parameters[count][1]);
            }
            observable = this._http.get(url, { search }).map((response) => response.json());
        }
        else {
            observable = this._http.get(url).map((response) => response.json());
        }
        return observable;
    }

    httpPost(url: any, dataObject: any, fullUrl: boolean = false): any {
        if (fullUrl === false) {
            url = `./${url}`;
        }
        const _headers = new Headers();
        _headers.append('Content-Type', 'application/json');
        _headers.append('Access-Control-Allow-Origin', location.origin);
        const observable = this._http.post(url, JSON.stringify(dataObject), { headers: _headers }).map(response => response.json());
        return observable;
    }

    // httpDownloadBlob(url: any, dataObject: any): any {
    //    return Observable.create(observer => {
    //        url = `./${url}`;
    //        var xhr = new XMLHttpRequest();
    //        xhr.open('POST', url, true);
    //        xhr.responseType = 'arraybuffer';
    //        xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    //        xhr.onreadystatechange = () => {
    //            if (xhr.readyState === 4 && xhr.status === 200) {
    //                observer.next(xhr.response);
    //                observer.complete();
    //            }
    //        }
    //        xhr.send(JSON.stringify(dataObject));
    //    });
    // }

    httpSearch(url: string, searchText: string) {
        url = `./${url}`;
        const search = new URLSearchParams();
        search.set('inputText', searchText);
        const obsersvable = this._http.get(url, { search: search }).map(res => res.json());
        return obsersvable;
    }
}