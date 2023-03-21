import { Component, OnInit, AfterViewInit, AfterViewChecked, AfterContentInit, Inject } from '@angular/core';
import { AuthService } from 'app/services/auth/auth.service';

declare var $: any;
//Metadata
export interface RouteInfo {
    path: string;
    title: string;
    type: string;
    icontype: string;
    // icon: string;
    children?: ChildrenItems[];
}

export interface ChildrenItems {
    path: string;
    title: string;
    ab: string;
    type?: string;
}

//Menu Items
export const ROUTES: RouteInfo[] = [{
    path: '/adminpages/dashboard',
    title: 'Inicio',
    type: 'link',
    icontype: 'pe-7s-home'
},
{
    path: '/medical',
    title: 'Médicos',
    type: 'sub',
    icontype: 'pe-7s-users',
    children: [
        { path: '', title: 'Médicos', ab: 'M' },
        { path: 'patientrecord', title: 'Pontuarios', ab: 'PP' },
    ]
},
{
    path: '/patient',
    title: 'Pacientes',
    type: 'sub',
    icontype: 'pe-7s-users',
    children: [
        { path: 'patient', title: 'Paciente', ab: 'P' },
        { path: 'patientrecord', title: 'Pontuarios', ab: 'PP' },
    ]
},
{
    path: '/pages',
    title: 'Usuários',
    type: 'sub',
    icontype: 'pe-7s-users',
    children: [
        { path: 'users', title: 'Usuários', ab: 'U' }
    ]
}, {
    path: '/adminpages',
    title: 'Configurações',
    type: 'sub',
    icontype: 'pe-7s-tools',
    children: [
        { path: 'gender', title: 'Gender', ab: 'G' },
        { path: 'office', title: 'Office', ab: 'O' },
        { path: 'rolegroup', title: 'RoleGroup', ab: 'RG' },
        { path: 'applicationsetting', title: 'Configurações Sistema', ab: 'CS' },
        { path: 'applicationlanguage', title: 'Idiomas', ab: 'I' },
    ]
}, {
    path: '/pages',
    title: 'Cadastros',
    type: 'sub',
    icontype: 'pe-7s-gift',
    children: [
        { path: 'user', title: 'User Page', ab: 'UP' },
    ]
}, {
    path: '/authpages',
    title: 'Modelos',
    type: 'sub',
    icontype: 'pe-7s-gift',
    children: [ 
        { path: 'register', title: 'Register Page', ab: 'RP' } 
    ]
}
];

@Component({
    moduleId: module.id,
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent {

    public menuItems: any[];

    isNotMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    } 
    constructor(@Inject(AuthService) private authService: AuthService) {

    }
    logOut() : void {
        this.authService.logout();
    } 
    isLoggedIn() : boolean {
        return this.authService.isLoggedIn();
    } 
    ngOnInit() {
        var isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;
        this.menuItems = ROUTES.filter(menuItem => menuItem);

        isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;

        if (isWindows) {
            // if we are on windows OS we activate the perfectScrollbar function
            $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();
            $('html').addClass('perfect-scrollbar-on');
        } else {
            $('html').addClass('perfect-scrollbar-off');
        }
    }
    ngAfterViewInit() {
        var $sidebarParent = $('.sidebar .nav > li.active .collapse li.active > a').parent().parent().parent();

        var collapseId = $sidebarParent.siblings('a').attr("href");

        $(collapseId).collapse("show");
    }
}
