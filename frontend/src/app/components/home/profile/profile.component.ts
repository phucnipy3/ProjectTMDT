import { Component, OnInit } from '@angular/core';
import { ProfileViewModel } from '../../../../models/account/profile';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
})
export class ProfileComponent implements OnInit {

    profile: ProfileViewModel;

    constructor() { }

    ngOnInit(): void {
        this.profile = new ProfileViewModel();
        this.profile.userId = 'phucnipy3';
        this.profile.fullName = 'Phúc Nguyễn';
        this.profile.isMale = true;
        this.profile.phoneNumber = '0346646603';
        this.profile.email = 'phucnipy3@gmail.com';
        this.profile.address = 'Quận 9, Tp.HCM';
    }

    logData() {
        console.log(this.profile);
    }
    setMale(){
        this.profile.isMale = true;
    }
    setFemale(){
        this.profile.isMale = false;
    }
}
