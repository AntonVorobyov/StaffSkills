import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class EmployeeService {

    private _url = '/api/employees';

    constructor(private http: Http) { }

    get() {
        return this.http.get(this._url);
    }
}
