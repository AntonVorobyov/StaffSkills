import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PositionService {

    private _url = '/api/positions';

    constructor(private http: Http) { }

    get() {
        return this.http.get(this._url);
    }
}
