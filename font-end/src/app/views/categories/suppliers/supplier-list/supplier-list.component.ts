import { Component, OnInit } from '@angular/core';
import { Pagination, PaginatedResult } from 'src/app/shared/models/pagination.model';
import { PagingParams } from 'src/app/shared/params/paging-params.model';
import { SupplierService } from 'src/app/shared/services/supplier-service';
import { NotifyService } from 'src/app/shared/services/notify-service';
import { NzModalService } from 'ng-zorro-antd';
import { Supplier } from 'src/app/shared/models/supplier.model';
import { MessageConstant } from 'src/app/shared/constants/message-constant';
import { SupplierModalComponent } from '../supplier-modal/supplier-modal.component';
import { ConfigConstant } from 'src/app/shared/constants/config-constant';

@Component({
  selector: 'app-supplier-list',
  templateUrl: './supplier-list.component.html',
  styleUrls: ['./supplier-list.component.scss']
})
export class SupplierListComponent implements OnInit {
  loading = true;
  sortValue = null;
  sortKey = null;
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5
  }

  pagingParams: PagingParams = {
    pageNumber: 1,
    pageSize: 5,
    keyword: '',
    sortKey: '',
    sortValue: '',
    searchKey: '',
    searchValue: ''
  };
  //*********************************** */
  listAll = [];

  constructor(private supplierService: SupplierService,
    private notify: NotifyService,
    private modalService: NzModalService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.supplierService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
      .subscribe((res: PaginatedResult<Supplier[]>) => {
        this.pagination = res.pagination;
        this.listAll = res.result;
        console.log(res);
      });
  }

  sort(sort: { key: string, value: string }): void {
    this.pagingParams.sortKey = sort.key;
    this.pagingParams.sortValue = sort.value;

    console.log(this.pagingParams);
    this.loadData();
  }

  search(keyword: string) {
    this.pagingParams.searchValue = "name";
    this.pagingParams.searchKey = keyword;
    this.loadData();
  }
  searchColumn(searchKey: string) {
    this.pagingParams.searchKey = searchKey;
    //this.loadData();
  }

  delete(id: number) {
    this.notify.confirm(MessageConstant.CONFIRM_DELETE_MSG, () => {
      this.supplierService.delete(id).subscribe((res: boolean) => {
        if (res) {
          this.notify.success(MessageConstant.DELETED_OK_MSG);
          this.loadData();
        }
      });
    });
    console.log(id);
  }

  addNew() {
    const modal = this.modalService.create({
      nzTitle: 'Thêm mới nhà cung cấp ',
      nzContent: SupplierModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
        supplier: {mancc:0, tenncc:"",diachi:"",sdt:0},
        isAddNew: true
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
  }

  update(supplier: Supplier) {
    const modal = this.modalService.create({
      nzTitle: 'Sửa thông tin nhà cung cấp',
      nzContent: SupplierModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
        supplier,
        isAddNew: false
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
    console.log(supplier);
  }


 

}
