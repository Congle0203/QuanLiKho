import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from './customer-list/customer-list.component'
import { from } from 'rxjs';

const routes: Routes = [
    {
        path: '',
        data: {
            breadcrumb: 'Khách hàng'
        },
        children: [
            {
                path: 'danh-sach',
                component: CustomerListComponent,
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
export class CustomersRoutingModule { }
