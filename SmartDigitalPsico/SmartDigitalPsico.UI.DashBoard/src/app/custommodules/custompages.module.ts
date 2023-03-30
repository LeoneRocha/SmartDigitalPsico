import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core'; 
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import { JwBootstrapSwitchNg2Module } from 'jw-bootstrap-switch-ng2';
  
@NgModule({ 
  exports: [ 
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    JwBootstrapSwitchNg2Module,
  ]
})
export class CustomPagesModule { }
