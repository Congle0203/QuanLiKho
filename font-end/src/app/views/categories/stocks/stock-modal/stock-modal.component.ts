// import { Component, OnInit, HostListener, Input } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
// import { NzModalService, NzModalRef } from 'ng-zorro-antd';

// import { UnitService } from '../../../../shared/services/unit-service';
// import { Unit } from '../../../../shared/models/unit.model';


// import { NotifyService } from 'src/app/shared/services/notify-service';

// import { MessageConstant } from '../../../../shared/constants/message-constant'
// import { ConfigConstant } from '../../../../shared/constants/config-constant'
// import { Stock } from 'src/app/shared/models/stock.model';
// import { FormGroup, FormBuilder, Validators } from '@angular/forms';
// import { StockService } from 'src/app/shared/services/stock-service';

// @Component({
//   selector: 'app-stock-modal',
//   templateUrl: './stock-modal.component.html',
//   styleUrls: ['./stock-modal.component.scss']
// })
// export class StockModalComponent implements OnInit {
//   @Input() stock: Stock;
//   @Input() isAddNew: boolean;



//   stockForm: FormGroup;

//   loadingSaveChanges: boolean;

//   constructor(private fb: FormBuilder,
//     private modal: NzModalRef,
//     private stockService: StockService,
//     private notify: NotifyService) { }

//     //********************************************************************************* */
//   ngOnInit() {
//     this.createForm();
//     this.stockForm.reset();
//     this.stockForm.patchValue(this.stock);
//   }
//   //******************************************************************************************* */
//   createForm() {
//     this.stockForm = this.fb.group({
//       id: [null],
//       name: [null, [Validators.required]],
//       createdDate: [null],
//       createdBy: [null],
//       status: [null]
//     });
//   }


//   saveChanges() {
//     const stock = this.stockForm.getRawValue();
//     if (this.isAddNew) {
//       this.stockService.addNew(stock).subscribe((res: any) => {
//         if (res) {
//           this.notify.success(MessageConstant.CREATED_OK_MSG);
//           this.modal.destroy(true);
//         }

//         this.loadingSaveChanges = false;
//       }, _ => this.loadingSaveChanges = false);
//     } else {
//       this.stockService.update(stock).subscribe((res: any) => {
//         if (res) {
//           this.notify.success(MessageConstant.UPDATED_OK_MSG);
//           this.modal.destroy(true);
//         }

//         this.loadingSaveChanges = false;
//       }, _ => this.loadingSaveChanges = false);
//     }
//   }

//   destroyModal() {
//     this.modal.destroy(false);


//   }
// }

//********************************************sanggggggggggggggggggggggggggggggggg */

import { Component, OnInit, Input, HostListener } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd';
import { Stock } from '../../../../shared/models/stock.model'
import { NotifyService } from '../../../../shared/services/notify-service'
import { MessageConstant } from '../../../../shared/constants/message-constant'
import { StockService } from '../../../../shared/services/stock-service'
import { InventoryService } from 'src/app/shared/services/inventory-service';
import { UnitService } from 'src/app/shared/services/unit-service';
import { Unit } from 'src/app/shared/models/unit.model';
import { Inventory } from 'src/app/shared/models/inventory.model';
import { Supplier } from 'src/app/shared/models/supplier.model';
import { SupplierService } from 'src/app/shared/services/supplier-service';

@Component({
  selector: 'app-stock-modal',
  templateUrl: './stock-modal.component.html',
  styleUrls: ['./stock-modal.component.scss']
})


export class StockModalComponent implements OnInit {

  @Input() stock: Stock;

  @Input() isAddNew: boolean;

  stockForm: FormGroup;
  loadingSaveChanges: boolean;

  ListOfSuppliers = [];
  ListOfUnits = [];
  ListOfInventory = [];

  constructor(private fb: FormBuilder,
    private modal: NzModalRef,
    private stockService: StockService,
    private notify: NotifyService,
    private inventoryService: InventoryService,
    private unitService: UnitService,
    private supplierService: SupplierService) { }

  ngOnInit() {
    this.loadUnits();
    this.loadInventory();
    this.loadSuppliers();
    this.createForm();
    this.stockForm.reset();
    this.stockForm.patchValue(this.stock);
  }

  createForm() {
    this.stockForm = this.fb.group({
      mavt: [null],
      tenvt: [null, [Validators.required]],
      soluong: [null],
      noisx: [null, [Validators.required]],
      inventoryID: [Validators.required],
      unitID: [Validators.required],
      supplierId: [Validators.required],
      suppliername: [Validators.required],
      inventoryname: [null, [Validators.required]],
      unitname: [null, [Validators.required]],

      // createdDate: [null],
      // createdBy: [null],
      // status: [null]
    });
  }

  loadUnits() {
    this.unitService.getAll().subscribe((res: Unit[]) => {
      this.ListOfUnits = res;
    });
  }

  loadInventory() {
    this.inventoryService.getAll().subscribe((res: Inventory[]) => {
      this.ListOfInventory = res;
    });
  }

  loadSuppliers() {
    this.supplierService.getAll().subscribe((res: Supplier[]) => {
      this.ListOfSuppliers = res;
    });
  }

  destroyModal() {
    this.modal.destroy(false);
  }

  saveChanges() {
    const stock = this.stockForm.getRawValue();

    console.log(stock);
    if (this.isAddNew) {
      this.stockService.addNew(stock).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.CREATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);

    }
    else {
      this.stockService.update(stock).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.UPDATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);
    }

  }

}
