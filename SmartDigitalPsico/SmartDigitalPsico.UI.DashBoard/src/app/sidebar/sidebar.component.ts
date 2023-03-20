import { Component, OnInit, AfterViewInit, AfterViewChecked, AfterContentInit } from '@angular/core';

declare var $:any;
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
        path: '/dashboard',
        title: 'Inicio',
        type: 'link',
        icontype: 'pe-7s-graph'
    }, 
    {
        path: '/pages',
        title: 'Usuários',
        type: 'sub',
        icontype: 'pe-7s-users',
        children: [
            {path: 'users', title: 'Usuários', ab:'U'} 
        ]
    },
    {
        path: '/pages',
        title: 'Médicos',
        type: 'sub',
        icontype: 'pe-7s-users',
        children: [
            {path: 'medical', title: 'Médicos', ab:'M'},
            {path: 'patientrecord', title: 'Pontuarios', ab:'PP'}, 
        ]
    },
    {
        path: '/pages',
        title: 'Pacientes',
        type: 'sub',
        icontype: 'pe-7s-users',
        children: [
            {path: 'patient', title: 'Paciente', ab:'P'},
            {path: 'patientrecord', title: 'Pontuarios', ab:'PP'}, 
        ]
    },{
        path: '/pages',
        title: 'Configurações',
        type: 'sub',
        icontype: 'pe-7s-tools',
        children: [
            {path: 'gender', title: 'Gender', ab:'G'}, 
            {path: 'office', title: 'Office', ab:'O'}, 
            {path: 'rolegroup', title: 'RoleGroup', ab:'RG'}, 
            {path: 'applicationsetting', title: 'Configurações Sistema', ab:'CS'}, 
            {path: 'applicationlanguage', title: 'Idiomas', ab:'I'}, 
        ]
    },{
        path: '/pages',
        title: 'Modelos',
        type: 'sub',
        icontype: 'pe-7s-gift',
        children: [
            {path: 'user', title: 'User Page', ab:'UP'},
            {path: 'login', title: 'Login Page', ab:'LP'},
            {path: 'register', title: 'Register Page', ab:'RP'},
            {path: 'lock', title: 'Lock Screen Page', ab:'LSP'}
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
    isNotMobileMenu(){
        if($(window).width() > 991){
            return false;
        }
        return true;
    }

    ngOnInit() {
        var isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;
        this.menuItems = ROUTES.filter(menuItem => menuItem);

        isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;

        if (isWindows){
           // if we are on windows OS we activate the perfectScrollbar function
           $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();
           $('html').addClass('perfect-scrollbar-on');
       } else {
           $('html').addClass('perfect-scrollbar-off');
       }
    }
    ngAfterViewInit(){
        var $sidebarParent = $('.sidebar .nav > li.active .collapse li.active > a').parent().parent().parent();

        var collapseId = $sidebarParent.siblings('a').attr("href");

        $(collapseId).collapse("show");
    }
}
