import { Component, OnInit } from '@angular/core';
import { Pagination, PaginatedResult } from 'src/app/shared/models/pagination.model';
import { PagingParams } from 'src/app/shared/params/paging-params.model';
import { ReceiptService } from 'src/app/shared/services/receipt-service';
import { NotifyService } from 'src/app/shared/services/notify-service';
import { NzModalService } from 'ng-zorro-antd';
import { Receipt } from 'src/app/shared/models/receipt.model';
import { MessageConstant } from 'src/app/shared/constants/message-constant';
import { ReceiptModalComponent } from '../receipt-modal/receipt-modal.component';
import { ConfigConstant } from 'src/app/shared/constants/config-constant';

@Component({
  selector: 'app-receipt-list',
  templateUrl: './receipt-list.component.html',
  styleUrls: ['./receipt-list.component.scss']
})
export class ReceiptListComponent implements OnInit {

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

  constructor(private receiptService: ReceiptService,
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
    this.receiptService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
      .subscribe((res: PaginatedResult<Receipt []>) => {
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
      this.receiptService.delete(id).subscribe((res: boolean) => {
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
      nzTitle: 'Thêm mới phiếu nhập',
      nzContent:ReceiptModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
      receipt: {mapn:0, tenpn:"", ngaynhap:0, soluongnhap:0, stockname:"", tinhtrang:"", stockId:0, dongianhap:0,},
        isAddNew: true
      }
    });
    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
  }

  update(receipt:Receipt ) {
    const modal = this.modalService.create({
      nzTitle: 'Sửa thông tin phiếu nhập',
      nzContent: ReceiptModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
        receipt,
        isAddNew: false
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
    console.log(receipt);
  }


 
}
