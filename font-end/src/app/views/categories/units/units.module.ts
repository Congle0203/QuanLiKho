import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'ng-zorro-antd';

import { UnitsRoutingModule } from './units-routing.module';
import { UnitListComponent } from './unit-list/unit-list.component';
import { UnitModalComponent } from './unit-modal/unit-modal.component';


// @NgModule({
//   declarations: [UnitListComponent, UnitListComponent],// SAI CODE
    
//   imports: [
//     CommonModule,    
//     FormsModule,
//     ReactiveFormsModule,
//     NgZorroAntdModule,
//     UnitsRoutingModule,
//   ],
//   entryComponents: [UnitModalComponent]
// })
// export class UnitsModule { }

@NgModule({
  declarations: [
    UnitListComponent,
    UnitModalComponent
  ],
  imports: [
    CommonModule,
    UnitsRoutingModule,    
    FormsModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    
  ],
  entryComponents: [UnitModalComponent]
})
export class UnitsModule { }

