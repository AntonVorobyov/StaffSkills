import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders }  from '@angular/core';
import { EmployeesComponent } from './components/employees';
import { EmployeeCreateComponent } from './components/employee-create';
import { EmployeeEditComponent } from './components/employee-edit';
import { SkillsComponent } from './components/skills';

const routes: Routes = [
    { path: '', redirectTo: 'employees', pathMatch: 'full' },
    { path: 'employees', component: EmployeesComponent },
    { path: 'employee', component: EmployeeCreateComponent },
    { path: 'employee/:id', component: EmployeeEditComponent },
    { path: 'skills', component: SkillsComponent },
    { path: '**', redirectTo: 'employees' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);