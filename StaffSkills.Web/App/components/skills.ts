import { Component, OnInit } from '@angular/core';
import { Skill } from '../models/skill';
import { SkillService } from '../services/skill-service';

@Component({
    selector: 'skills',
    template: require('./skills.html'),
    providers: [SkillService]
})
export class SkillsComponent implements OnInit {

    private skills: Skill[];

    constructor(private skillService: SkillService) { }

    ngOnInit() { this.getSkills(); }

    getSkills() {
        this.skillService
            .get()
            .subscribe(response => {
                this.skills = <Skill[]>response.json();
            },
            error => {
                console.log("error", error);
            });
    }
}
