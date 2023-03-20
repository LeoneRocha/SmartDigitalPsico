import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { UserLoginModel } from 'app/models/UserLoginModel';
import { AuthService } from 'app/services/auth/auth.service';

declare var $: any;

@Component({
    moduleId: module.id,
    selector: 'login-cmp',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit {
    test: Date = new Date();
    invalidLogin: boolean;
    public userLoginModel: UserLoginModel;

    constructor(
        @Inject(Router) private router: Router,
        @Inject(AuthService) private authService: AuthService) {


    }

    checkFullPageBackgroundImage() {
        var $page = $('.full-page');
        var image_src = $page.data('image');

        if (image_src !== undefined) {
            var image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>'
            $page.append(image_container);
        }
    };

    ngOnInit() {
        this.userLoginModel = {
            login: '', password: ''
        };
        this.checkFullPageBackgroundImage();

        setTimeout(function () {
            // after 1000 ms we add the class animated to the login/register card
            $('.card').removeClass('card-hidden');
        }, 700)
    }
    signIn() {
        //console.log(this.userLoginModel);
        this.authService.login(this.userLoginModel).subscribe({
            next: (response: any) => {                
                this.router.navigate(['/adminpages/dashboard']);
            },
            error: (err) => { this.invalidLogin = true; }
        });
        //value="admin"
        //value="mock123adm"
    }
}
