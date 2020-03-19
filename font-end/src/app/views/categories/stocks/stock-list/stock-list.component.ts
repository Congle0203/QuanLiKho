// import { Component, OnInit, HostListener } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
// import { NzModalService } from 'ng-zorro-antd';

// // import { UnitService } from '../../../../shared/services/unit-service';
// // import { Unit } from '../../../../shared/models/unit.model';

// import { NotifyService } from 'src/app/shared/services/notify-service';

// import { MessageConstant } from '../../../../shared/constants/message-constant'
// import { ConfigConstant } from '../../../../shared/constants/config-constant'
// import { StockService } from 'src/app/shared/services/stock-service';
// import { Stock } from 'src/app/shared/models/stock.model';
// import { StockModalComponent } from '../stock-modal/stock-modal.component';
// import { PagingParams } from 'src/app/shared/params/paging-params.model';
// import { Pagination, PaginatedResult } from '../../../../shared/models/pagination.model';


// @Component({
//   selector: 'app-stock-list',
//   templateUrl: './stock-list.component.html',
//   styleUrls: ['./stock-list.component.scss']
// })
// export class StockListComponent implements OnInit {
//   lstStocks = [];
//   pagination: Pagination = {
//           currentPage: 1,
//           itemsPerPage: 5
//         }
      
//         pagingParams: PagingParams = {
//           pageNumber: 1,
//           pageSize: 5,
//           keyword: '',
//           sortKey: '',
//           sortValue: '',
//           searchKey: '',
//           searchValue: ''
//         };

//   constructor(private stockService: StockService,
//     private notify: NotifyService,
//     private modalService: NzModalService) { }

//    ngOnInit() {
//       this.loadData();
//     }
  
//     loadData() {
//       this.stockService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
//         .subscribe((res: PaginatedResult<Stock[]>) => {
  
//           this.pagination = res.pagination;
//           this.lstStocks = res.result;
  
//            console.log(res);
//         });
//     }
//     sort(sort: { key: string, value: string }): void {
//       this.pagingParams.sortKey = sort.key;
//       this.pagingParams.sortValue = sort.value;
  
//       console.log(this.pagingParams);
//       this.loadData();
//     }
  
//     search(keyword: string) {
//       this.pagingParams.searchValue = "name";
//       this.pagingParams.searchKey = keyword;
//       this.loadData();
//     }
//     searchColumn(searchKey: string) {
//       this.pagingParams.searchKey = searchKey;
//       this.loadData();
//     }
    
//     delete(id: number){
//       this.notify.confirm(MessageConstant.CONFIRM_DELETE_MSG, () => { 
//         this.stockService.delete(id).subscribe((res :boolean)=>{
//           if (res) {
//             this.notify.success(MessageConstant.DELETED_OK_MSG);
//             this.loadData();
//           }
//         });
//       });
//       console.log(id);
//     }
  
//     addNew(){
//       const modal = this.modalService.create({
//         nzTitle: 'Thêm mới vật tư',
//         nzContent: StockModalComponent,
//         nzStyle: {
//           top: ConfigConstant.MODAL_TOP_20PX
//         },
//         nzBodyStyle: {
//           padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//         },
//         nzMaskClosable: false,
//         nzClosable: false,
//         nzComponentParams: {
//           stock: null,
//           isAddNew: true
//         }
//       });
  
//       modal.afterClose.subscribe((result: boolean) => {
//   if (result) {
//           this.loadData();
//         }
//       });
//     }
  
//     update(stock: Stock) {
//       const modal = this.modalService.create({
//         nzTitle: 'Sửa thông tin vật tư',
//         nzContent: StockModalComponent,
//         nzStyle: {
//           top: ConfigConstant.MODAL_TOP_20PX
//         },
//         nzBodyStyle: {
//           padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//         },
//         nzMaskClosable: false,
//         nzClosable: false,
//         nzComponentParams: {
//           stock :stock,
//           isAddNew: false
//         }
//       });
  
//       modal.afterClose.subscribe((result: boolean) => {
//         if (result) {
//           this.loadData();
//         }
//       });
  
//       console.log(stock);
//     }
//   }

//*********************************************Sanggggggggggggggggggggggggggggggggggg */
import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
import { StockService } from '../../../../shared/services/stock-service';
import { NotifyService } from '../../../../shared/services/notify-service';
import { MessageConstant } from '../../../../shared/constants/message-constant';
import { ConfigConstant } from '../../../../shared/constants/config-constant';
import { Stock } from '../../../../shared/models/stock.model';
import { ModalBuilderForService } from 'ng-zorro-antd/modal/nz-modal.service';
import { StockModalComponent } from '../stock-modal/stock-modal.component'
import { Pagination, PaginatedResult } from '../../../../shared/models/pagination.model';
import { PagingParams } from '../../../../shared/params/paging-params.model';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html',
  styleUrls: ['./stock-list.component.scss']
})
export class StockListComponent implements OnInit {

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

  constructor(private stockService: StockService,
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
    this.stockService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
      .subscribe((res: PaginatedResult<Stock[]>) => {
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
      this.stockService.delete(id).subscribe((res: boolean) => {
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
      nzTitle: 'Thêm mới vật tư',
      nzContent: StockModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
      stock: {mavt:0, tenvt: "", soluong:0, noisx :"", unitID: 0, inventoryID: 0,  inventoryname:"", unitname:"", supplierId:0, suppliername:""},
        isAddNew: true
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
  }

  update(stock: Stock) {
    const modal = this.modalService.create({
      nzTitle: 'Sửa thông tin vật tư',
      nzContent: StockModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
        stock,
        isAddNew: false
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
    console.log(stock);
  }
}
