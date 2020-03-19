import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OutputListComponent } from './output-list/output-list.component';


const routes: Routes = [
    {
        path: '',
        data: {
            breadcrumb: 'Phiếu xuất'
        },
        children: [
            {
                path: 'danh-sach',
                component: OutputListComponent,
                data: {
                    breadcrumb: 'Danh sách'
                }
            },
            {
                path: '',
                redirectTo: 'danh-sach',
                pathMatch: 'full'
            }
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OutputsRoutingModule { }
