import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class SkillService {

    private _url = '/api/skills';

    constructor(private http: Http) { }

    get() {
        return this.http.get(this._url);
    }
}
