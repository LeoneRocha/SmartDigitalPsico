import { Component, OnInit, AfterViewInit, AfterViewChecked, AfterContentInit, Inject } from '@angular/core';
import { AuthService } from 'app/services/auth/auth.service';


declare var $: any;
//Metadata
export interface RouteInfo {
    path: string;
    id: string;
    title: string;
    type: string;
    icontype: string;
    roleaccess: string;
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
    path: '/administrative/dashboard',
    title: 'navbar.dashboard',//Inicio
    id: "dashboard",
    type: 'link',
    roleaccess: 'Read',
    icontype: 'pe-7s-home'
},
{
    path: '/medical',
    id: "medical",
    title: 'navbar.medicals',
    type: 'sub',
    icontype: 'pe-7s-users',
    roleaccess: 'Read',
    children: [
        { path: 'manage', title: 'Médicos', ab: 'M' },
    ]
},
{
    path: '/patient',
    id: "patient",
    title: 'navbar.patient',
    type: 'sub',
    icontype: 'pe-7s-users',
    roleaccess: 'Read',
    children: [
        { path: 'manage', title: 'navbar.patient', ab: 'P' },
        { path: 'patientrecord', title: 'navbar.patientrecord', ab: 'PP' },
    ]
},
{
    path: '/administrative',
    id: "users",
    title: 'navbar.users',
    type: 'sub',
    icontype: 'pe-7s-users',
    roleaccess: 'Read',
    children: [
        { path: 'usermanagement', title: 'navbar.users', ab: 'U' }
    ]
}, {
    path: '/administrative',
    id: "administrative",
    title: 'navbar.configurations', //'Configurações',
    type: 'sub',
    icontype: 'pe-7s-tools',
    roleaccess: 'Read',
    children: [
        { path: 'gender', title: 'navbar.gender', ab: 'G' },
        { path: 'office', title: 'navbar.office', ab: 'O' },
        { path: 'rolegroup', title: 'navbar.rolegroup', ab: 'RG' },
        { path: 'specialty', title: 'navbar.specialty', ab: 'S' },
        { path: 'applicationsetting', title: 'navbar.applicationsetting', ab: 'CS' },
        { path: 'applicationlanguage', title: 'navbar.applicationlanguage', ab: 'I' },
    ]
}, {
    path: '/pages',
    id: "pages",
    title: 'navbar.registers',//'Cadastros',
    type: 'sub',
    icontype: 'pe-7s-gift',
    roleaccess: 'Read',
    children: [
        { path: 'user', title: 'navbar.userpage', ab: 'UP' },
    ]
}, {
    path: '/authpages',
    id: "authpages",
    title: 'Models',
    type: 'sub',
    icontype: 'pe-7s-gift',
    roleaccess: 'Read',
    children: [
        { path: 'register', title: 'navbar.userregisterpage', ab: 'RP' }
    ]
}
];


@Component({
    moduleId: module.id,
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent {
    public userNameAtenticate: string;//= "Nome do Medico/User Logado";
    public menuItems: any[];

    isNotMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    }
    constructor(@Inject(AuthService) private authService: AuthService) {

    }
    logOut(): void {
        this.authService.logout();
    }
    checkCanAccess(menuItem: RouteInfo): boolean {
        let isCanAccess: boolean = true;
        //console.log(menuItem?.roleaccess);
        let userCanRoleMenu = this.authService.isUserContainsRole(menuItem?.roleaccess);
        isCanAccess = userCanRoleMenu;
        //console.log(userCanRoleMenu);
        if (menuItem.path.indexOf('administrative') >= 0) {
            isCanAccess = this.authService.isUserContainsRole('Admin');
            //console.log('Admin + ' + isCanAccess);
        }
        return isCanAccess;
    }
    isLoggedIn(): boolean {
        return this.authService.isLoggedIn();
    }
    ngOnInit() {
        this.userNameAtenticate = this.authService.getLocalStorageUser().name;
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
