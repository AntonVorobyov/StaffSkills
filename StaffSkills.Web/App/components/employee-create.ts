import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../models/employee';
import { Position } from '../models/position';
import { EmployeeService } from '../services/employee-service';
import { PositionService } from '../services/position-service';

@Component({
    selector: 'employee',
    template: require('./employee-create.html'),
    providers: [EmployeeService, PositionService]
})
export class EmployeeCreateComponent implements OnInit {

    private employee: Employee = <Employee>{};
    private positions: Position[];

    constructor(
        private employeeService: EmployeeService,
        private positionService: PositionService,
        private router: Router) { }

    ngOnInit() {
        this.getPositions();
    }

    getPositions() {
        this.positionService
            .get()
            .subscribe(response => {
                this.positions = <Position[]>response.json();
            },
            error => {
                console.log("error", error);
            });
    }

    back() {
        this.router.navigate(['/employees']);
    }

    create() {
        this.employeeService
            .create(this.employee)
            .subscribe(response => {
                this.employee = <Employee>response.json();
                this.router.navigate(['/employee', this.employee.id]);
            },
            error => {
                console.log("error", error);
            });
    }
}
