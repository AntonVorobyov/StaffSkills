import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../services/employee-service';

@Component({
    selector: 'employees',
    template: require('./employees.html'),
    providers: [EmployeeService]
})
export class EmployeesComponent implements OnInit {

    private employees: Employee[];

    constructor(private employeeService: EmployeeService) { }

    ngOnInit() { this.getEmployees(); }

    getEmployees() {
        this.employeeService
            .get()
            .subscribe(response => {
                this.employees = <Employee[]>response.json();
            },
            error => {
                console.log("error", error);
            });
    }
}
