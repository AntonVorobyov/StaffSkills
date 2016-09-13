import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Employee } from '../models/employee';
import { Position } from '../models/position';
import { EmployeeService } from '../services/employee-service';
import { PositionService } from '../services/position-service';

@Component({
    selector: 'employee',
    template: require('./employee-edit.html'),
    providers: [EmployeeService, PositionService]
})
export class EmployeeEditComponent implements OnInit {

    private employee: Employee = <Employee>{};
    private positions: Position[];

    constructor(
        private employeeService: EmployeeService,
        private positionService: PositionService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit() {
        this.getEmployee();
        this.getPositions();
    }

    getEmployee() {
        var id = +this.route.snapshot.params['id'];
        this.employeeService
            .getById(id)
            .subscribe(response => {
                this.employee = <Employee>response.json();
            },
            error => {
                console.log("error", error);
            });
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

    save() {
        var id = +this.route.snapshot.params['id'];

        this.employeeService
            .save(id, this.employee)
            .subscribe(response => {
                this.employee = <Employee>response.json();
                this.router.navigate(['/employees']);
            },
            error => {
                console.log("error", error);
            });
    }
}
