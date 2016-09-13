import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';

@Injectable()
export class EmployeeService {

    private _url = '/api/employees';

    constructor(private http: Http) { }

    get() {
        return this.http.get(this._url);
    }

    getById(id: number) {
        return this.http.get(this._url + "/" + id);
    }

    save(id: number, model: Employee) {
        return this.http.put(this._url + "/" + id, model);
    }

    create(model: Employee) {
        return this.http.post(this._url, model);
    }

    delete(id: number) {
        return this.http.delete(this._url + "/" + id);
    }
}
