import { Component, ElementRef, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';

import { Subject } from 'rxjs/Subject';

import { ApiService } from '../shared/services/api.service';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit, AfterViewInit {

        title = 'Transaction Hub';
        errorMessage: string;
        requestToken: any;


    public creds = {
        username: "",
        password: "",
        expiryType: "",
        expiryDuration: ""
    };

    constructor(private apiservice: ApiService,
            private elementRef: ElementRef,
            private router: Router) {
    }


    onLogin() {

        this.apiservice.call('getRequestToken', this.creds).subscribe(result => {

            // Console Log results
            console.log(result.data);
    
            // Assign results
            this.requestToken = result.data;

            // For now... If token is not null navigate to list of customers
            if (this.requestToken !== null) {
                this.router.navigate(["customers"]);
            }

        }, err => this.errorMessage = "Failed to login");
           
    }

}
