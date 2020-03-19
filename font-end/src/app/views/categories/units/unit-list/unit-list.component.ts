// import { Component, OnInit, HostListener } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
// import { NzModalService } from 'ng-zorro-antd';

// import { UnitService } from '../../../../shared/services/unit-service';
// import { Unit } from '../../../../shared/models/unit.model';

// import { UnitModalComponent } from '../unit-modal/unit-modal.component'
// import { NotifyService } from 'src/app/shared/services/notify-service';

// import { MessageConstant } from '../../../../shared/constants/message-constant'
// import { ConfigConstant } from '../../../../shared/constants/config-constant'

// import { Pagination, PaginatedResult } from '../../../../shared/models/pagination.model';
// import { PagingParams } from '../../../../shared/params/paging-params.model';


// @Component({
//   selector: 'app-unit-list',
//   templateUrl: './unit-list.component.html',
//   styleUrls: ['./unit-list.component.scss']
// })

// export class UnitListComponent implements OnInit {
//   lstUnits = [];

//   constructor(private route: ActivatedRoute,
//     private unitService: UnitService,
//     private notify: NotifyService,
//     private modalService: NzModalService) { }

//   loading = true;
//   sortValue = null;
//   sortKey = null;
//   pagination: Pagination = {
//     currentPage: 1,
//     itemsPerPage: 5
//   }

//   pagingParams: PagingParams = {
//     pageNumber: 1,
//     pageSize: 5,
//     keyword: '',
//     sortKey: '',
//     sortValue: '',
//     searchKey: '',
//     searchValue: ''
//   };


//   ngOnInit() {
//     this.loadData();
//   }

//   loadData(reset: boolean = false): void {
//     if (reset) {
//       this.pagination.currentPage = 1;
//     }
//     this.loading = true;
//     this.unitService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
//       .subscribe((res: PaginatedResult<Unit[]>) => {
//         this.loading = false;
//         this.pagination = res.pagination;
//         this.lstUnits = res.result;

//         console.log(res);
//       });
//   }

//   loadData() {
//     this.unitService.getAll().subscribe((units: Unit[]) => {
//       console.log(units);
//       this.lstUnits = units;
//       console.log(this.lstUnits);
//     });
//   }

//   addNew() {
//     const modal = this.modalService.create({
//       nzTitle: 'Thêm mới đơn vị tính',
//       nzContent: UnitModalComponent,
//       nzStyle: {
//         top: ConfigConstant.MODAL_TOP_20PX
//       },
//       nzBodyStyle: {
//         padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//       },
//       nzMaskClosable: false,
//       nzClosable: false,
//       nzComponentParams: {
//         unit: { id: 0, name: "" },
//         isAddNew: true
//       }
//     });

//     modal.afterClose.subscribe((result: boolean) => {
//       if (result) {
//         this.loadData();
//       }
//     });
//   }

//   update(unit: Unit) {
//     const modal = this.modalService.create({
//       nzTitle: 'Lưu đơn vị tính',
//       nzContent: UnitModalComponent,
//       nzStyle: {
//         top: ConfigConstant.MODAL_TOP_20PX
//       },
//       nzBodyStyle: {
//         padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//       },
//       nzMaskClosable: false,
//       nzClosable: false,
//       nzComponentParams: {
//         unit,
//         isAddNew: false
//       }
//     });

//     modal.afterClose.subscribe((result: boolean) => {
//       if (result) {
//         this.loadData();
//       }
//     });
//     console.log(unit);
//   }

//   delete(id: number) {

//     Show massage
//     this.notify.confirm(MessageConstant.CONFIRM_DELETE_MSG, () => {
//       this.unitService.delete(id).subscribe((res: boolean) => {
//         if (res) {
//           this.notify.success(MessageConstant.DELETED_OK_MSG);
//           this.loadData();
//         }
//       });
//     });
//     console.log(id);
//   }

//   sort(sort: { key: string, value: string }): void {
//     this.pagingParams.sortKey = sort.key;
//     this.pagingParams.sortValue = sort.value;

//     console.log(this.pagingParams);
//     this.loadData();
//   }
// ***đổi */
//   search(keyword: string) {
//     this.pagingParams.searchValue = "name";
//     this.pagingParams.searchKey = keyword;
//     this.loadData();
//   }

//   searchColumn(searchKey: string) {
//     this.pagingParams.searchKey = searchKey;

//     this.loadData(true);
//   }
// }

// import { Component, OnInit, HostListener } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
// import { NzModalService } from 'ng-zorro-antd';

// import { UnitService } from '../../../../shared/services/unit-service';
// import { NotifyService } from '../../../../shared/services/notify-service';
// import { Unit } from '../../../../shared/models/unit.model';
// import { MessageConstant } from '../../../../shared/constants/message-constant'
// import { ConfigConstant } from '../../../../shared/constants/config-constant'

// import { UnitModalComponent } from '../unit-modal/unit-modal.component'

// @Component({
//   selector: 'app-unit-list',
//   templateUrl: './unit-list.component.html',
//   styleUrls: ['./unit-list.component.scss']
// })

// export class UnitListComponent implements OnInit {

//   lstUnits = [];

//   constructor(private route: ActivatedRoute,
//     private modalService: NzModalService,
//     private unitService: UnitService,
//     private notify: NotifyService) { }

//   ngOnInit() {
//     this.loadData();
//   }

//   loadData() {
//     this.unitService.getAll().subscribe((units: Unit[])  => {
//       console.log(units);
//       this.lstUnits = units;
//     });
//   }

//   addNew() {
//     const modal = this.modalService.create({
//       nzTitle: 'Thêm mới đơn vị tính',
//       nzContent: UnitModalComponent,
//       nzStyle: {
//         top: ConfigConstant.MODAL_TOP_20PX
//       },
//       nzBodyStyle: {
//         padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//       },
//       nzMaskClosable: false,
//       nzClosable: false,
//       nzComponentParams: {
//         unit: { id: 0, name: ""},
//         isAddNew: true
//       }
//     });

//     modal.afterClose.subscribe((result: boolean) => {
//       if (result) {
//         this.loadData();
//       }
//     });

//     console.log("add new");
//   }

//   update(unit: Unit) {
//     const modal = this.modalService.create({
//       nzTitle: 'Sửa thông tin đơn vị tính',
//       nzContent: UnitModalComponent,
//       nzStyle: {
//         top: ConfigConstant.MODAL_TOP_20PX
//       },
//       nzBodyStyle: {
//         padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//       },
//       nzMaskClosable: false,
//       nzClosable: false,
//       nzComponentParams: {
//         unit,
//         isAddNew: false
//       }
//     });

//     modal.afterClose.subscribe((result: boolean) => {
//       if (result) {
//         this.loadData();
//       }
//     });

//     console.log(unit);
//   }

//   delete(id: any) {
//     this.notify.confirm(MessageConstant.CONFIRM_DELETE_MSG, () => {
//       this.unitService.delete(id).subscribe((res: boolean) => {
//         if (res) {
//           this.notify.success(MessageConstant.DELETED_OK_MSG);
//           this.loadData();
//         }
//       });
//     });

//     console.log(id);
//   }

//   search(keyword: string) {
//     // this.pagingParams.keyword = keyword;
//     // this.loadData(true);
//   }
// }


//***********************************Sannggggggggggggggggggggggggggggggggggggggggggggggggggggg */
// import { Component, OnInit } from '@angular/core';
// import { NzModalService } from 'ng-zorro-antd';
// import { UnitService } from '../../../../shared/services/unit-service';
// import { NotifyService } from '../../../../shared/services/notify-service';
// import { MessageConstant } from '../../../../shared/constants/message-constant';
// import { ConfigConstant } from '../../../../shared/constants/config-constant';
// import { Unit } from '../../../../shared/models/unit.model';
// import { ModalBuilderForService } from 'ng-zorro-antd/modal/nz-modal.service';
// import { UnitModalComponent } from '../unit-modal/unit-modal.component'
// import { Pagination, PaginatedResult } from '../../../../shared/models/pagination.model';
// import { PagingParams } from '../../../../shared/params/paging-params.model';


// @Component({
//   selector: 'app-unit-list',
//   templateUrl: './unit-list.component.html',
//   styleUrls: ['./unit-list.component.scss']
// })
// export class UnitListComponent implements OnInit {

//   listOfData = []
//   pagination: Pagination = {
//     currentPage: 1,
//     itemsPerPage: 5
//   }

//   pagingParams: PagingParams = {
//     pageNumber: 1,
//     pageSize: 5,
//     keyword: '',
//     sortKey: '',
//     sortValue: '',
//     searchKey: '',
//     searchValue: ''
//   };

//   constructor(private unitService: UnitService,
//     private notify: NotifyService,
//     private modalService: NzModalService) { }

//   ngOnInit() {
//     this.loadData();
//   }

//   loadData() {
//     this.unitService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
//       .subscribe((res: PaginatedResult<Unit[]>) => {

//         this.pagination = res.pagination;
//         this.listOfData = res.result;

//         console.log(res);
//       });
//   }
//   sort(sort: { key: string, value: string }): void {
//     this.pagingParams.sortKey = sort.key;
//     this.pagingParams.sortValue = sort.value;

//     console.log(this.pagingParams);
//     this.loadData();
//   }

//   search(keyword: string) {
//     this.pagingParams.searchValue = "name";
//     this.pagingParams.searchKey = keyword;
//     this.loadData();
//   }
//   searchColumn(searchKey: string) {
//     this.pagingParams.searchKey = searchKey;
//     this.loadData();
//   }



//   delete(id: number) {
//     this.notify.confirm(MessageConstant.CONFIRM_DELETE_MSG, () => {
//       this.unitService.delete(id).subscribe((res: boolean) => {
//         if (res) {
//           this.notify.success(MessageConstant.DELETED_OK_MSG);
//           this.loadData();
//         }
//       });
//     });
//     console.log(id);
//   }

//   addNew() {
//     const modal = this.modalService.create({
//       nzTitle: 'Thêm mới đơn vị tính',
//       nzContent: UnitModalComponent,
//       nzStyle: {
//         top: ConfigConstant.MODAL_TOP_20PX
//       },
//       nzBodyStyle: {
//         padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//       },
//       nzMaskClosable: false,
//       nzClosable: false,
//       nzComponentParams: {
//         unit: null,
//         isAddNew: true
//       }
//     });

//     modal.afterClose.subscribe((result: boolean) => {
//       if (result) {
//         this.loadData();
//       }
//     });
//   }

//   update(unit: Unit) {
//     const modal = this.modalService.create({
//       nzTitle: 'Sửa thông tin đơn vị tính',
//       nzContent: UnitModalComponent,
//       nzStyle: {
//         top: ConfigConstant.MODAL_TOP_20PX
//       },
//       nzBodyStyle: {
//         padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
//       },
//       nzMaskClosable: false,
//       nzClosable: false,
//       nzComponentParams: {
//         unit: unit,
//         isAddNew: false
//       }
//     });

//     modal.afterClose.subscribe((result: boolean) => {
//       if (result) {
//         this.loadData();
//       }
//     });

//     console.log(unit);
//   }


// }

import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
import { UnitService } from '../../../../shared/services/unit-service';
import { NotifyService } from '../../../../shared/services/notify-service';
import { MessageConstant } from '../../../../shared/constants/message-constant';
import { ConfigConstant } from '../../../../shared/constants/config-constant';
import { Unit } from '../../../../shared/models/unit.model';
import { ModalBuilderForService } from 'ng-zorro-antd/modal/nz-modal.service';
import { UnitModalComponent } from '../unit-modal/unit-modal.component'
import { Pagination, PaginatedResult } from '../../../../shared/models/pagination.model';
import { PagingParams } from '../../../../shared/params/paging-params.model';


@Component({
  selector: 'app-unit-list',
  templateUrl: './unit-list.component.html',
  styleUrls: ['./unit-list.component.scss']
})
export class UnitListComponent implements OnInit {
  //********************************** */
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

  constructor(private unitService:UnitService,
    private notify: NotifyService,
    private modalService: NzModalService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.unitService.getAllPaging(this.pagination.currentPage, this.pagination.itemsPerPage, this.pagingParams)
      .subscribe((res: PaginatedResult<Unit[]>) => {
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
      this.unitService.delete(id).subscribe((res: boolean) => {
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
      nzTitle: 'Thêm đơn vị mới',
      nzContent: UnitModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
        unit: {madv: 0, tendv:"", description:""},
        isAddNew: true
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
  }

  update(unit: Unit) {
    const modal = this.modalService.create({
      nzTitle: 'Sửa thông tin đơn vị',
      nzContent: UnitModalComponent,
      nzStyle: {
        top: ConfigConstant.MODAL_TOP_20PX
      },
      nzBodyStyle: {
        padding: ConfigConstant.MODAL_BODY_PADDING_HORIZONTAL
      },
      nzMaskClosable: false,
      nzClosable: false,
      nzComponentParams: {
        unit,
        isAddNew: false
      }
    });

    modal.afterClose.subscribe((result: boolean) => {
      if (result) {
        this.loadData();
      }
    });
    console.log(unit);
  }


  
}


