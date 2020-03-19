import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
import { OutputService } from '../../../../shared/services/output-service';
import { NotifyService } from '../../../../shared/services/notify-service';
import { MessageConstant } from '../../../../shared/constants/message-constant';
import { ConfigConstant } from '../../../../shared/constants/config-constant';
import { Output } from '../../../../shared/models/output.model';
import { ModalBuilderForService } from 'ng-zorro-antd/modal/nz-modal.service';
import { OutputModalComponent } from '../output-modal/output-modal.component'
import { Pagination, PaginatedResult } from '../../../../shared/models/pagination.model';
import { PagingParams } from '../../../../shared/params/paging-params.model';


// import { Component, OnInit } from '@angular/core';
// import { NzModalService } from 'ng-zorro-antd';
// import { OutputService } from '../../../../shared/services/output-service';
// import { NotifyService } from '../../../../shared/services/notify-service';
// import { MessageConstant } from '../../../../shared/constants/message-constant';
// import { ConfigConstant } from '../../../../shared/constants/config-constant';
// import { Output } from '../../../../shared/models/output.model';
// import { ModalBuilderForService } from 'ng-zorro-antd/modal/nz-modal.service';
// import { OutputModalComponent } from '../output-modal/output-modal.component'
// import { Pagination, PaginatedResult } from '../../../../shared/models/pagination.model';
// import { PagingParams } from '../../../../shared/params/paging-params.model';



@Component({
  selector: 'app-output-list',
  templateUrl: './output-list.component.html',
  styleUrls: ['./output-list.component.scss']
})
export class OutputListComponent implements OnInit {
  
  listAll = []
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 10
  }

  pagingParams: PagingParams = {
    pageNumber: 1,
    pageSize: 3,
    keyword: '',
    sortKey: '',
    sortValue: '',
    searchKey: '',
    searchValue: ''
  };

  constructor(private outputService: OutputService,
    private notify: NotifyService,
    private modalService: NzModalService) { }

  ngOnInit() {
    this.loadData();
  }
 
  // loadData() {
  //   this.stockService.getAll().subscribe((stocks: Stock[]) => {
  //     console.log(stocks);
  //     this.listAll = stocks;
  //     console.log(this.listAll);
  //   });
  // }

  loadData() {
    this.outputService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
      .subscribe((res: PaginatedResult<Output []>) => {
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
      this.outputService.delete(id).subscribe((res: boolean) => {
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
      nzTitle: 'Thêm mới phiếu xuất',
      nzContent:OutputModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
      output: {mapx:0, tenpx: "", soluongxuat:0, tinhtrangxuat:"", CustomerId: 0, thanhtien: 0,  IdStock:0, ngayxuat:0, dongiaxuat:0},
        isAddNew: true
      }
    });
    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
  }

  update(output: Output) {
    const modal = this.modalService.create({
      nzTitle: 'Sửa thông tin phiếu xuất',
      nzContent: OutputModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
        output,
        isAddNew: false
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
    console.log(output);
  }
}


  