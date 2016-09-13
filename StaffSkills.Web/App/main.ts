import 'es6-shim';
require('zone.js');
import 'bootstrap';
import 'reflect-metadata';
import './css/site.css';
import './css/bootstrap.css';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';
import { App }           from './components/app';
import { EmployeesComponent } from './components/employees';
import { EmployeeCreateComponent } from './components/employee-create';
import { EmployeeEditComponent } from './components/employee-edit';
import { SkillsComponent } from './components/skills';
import { routing } from './routes';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],
    declarations: [
        App,
        EmployeesComponent,
        EmployeeCreateComponent,
        EmployeeEditComponent,
        SkillsComponent
    ],
    bootstrap: [App]
})
class AppModule { }

const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);

declare var module: any;
if (module.hot) {
    module.hot.accept();
}
