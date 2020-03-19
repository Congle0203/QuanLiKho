import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OutputsRoutingModule } from './outputs-routing.module';
import { OutputListComponent } from './output-list/output-list.component';
import { OutputModalComponent } from './output-modal/output-modal.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'ng-zorro-antd';



@NgModule({
  declarations: [OutputListComponent, OutputModalComponent],
  imports: [
    CommonModule,
    OutputsRoutingModule,    
    FormsModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
        

  ],
  entryComponents: [OutputModalComponent]
})
export class OutputsModule { }
