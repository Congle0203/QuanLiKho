import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InventoriesRoutingModule } from './inventories-routing.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'ng-zorro-antd';


import { InventoryListComponent } from './inventory-list/inventory-list.component';
import { InventoryModalComponent } from './inventory-modal/inventory-modal.component';


@NgModule({
  declarations: [
    InventoryListComponent,
    InventoryModalComponent
  ],
  imports: [
    CommonModule,
    InventoriesRoutingModule,    
    FormsModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    
  ],
  entryComponents: [InventoryModalComponent]
})
export class InventoriesModule {
  
 }
