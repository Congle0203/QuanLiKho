import { Component, OnInit, Input, HostListener } from '@angular/core';
import { NotifyService } from 'src/app/shared/services/notify-service';
import { MessageConstant } from '../../../../shared/constants/message-constant'
import { ConfigConstant } from '../../../../shared/constants/config-constant'
// import { FormGroup } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd';
import { Customer } from 'src/app/shared/models/customer.model';
import { CustomerService } from 'src/app/shared/services/customer-service';
import { Inventory } from 'src/app/shared/models/inventory.model';
import { InventoryService } from 'src/app/shared/services/inventory-service';
@Component({
  selector: 'app-inventory-modal',
  templateUrl: './inventory-modal.component.html',
  styleUrls: ['./inventory-modal.component.scss']
})
export class InventoryModalComponent implements OnInit {

  @Input() inventory: Inventory;
  @Input() isAddNew: boolean;

  inventoryForm: FormGroup;

  loadingSaveChanges: boolean;

  constructor(private fb: FormBuilder,
    private modal: NzModalRef,
    private inventoryService: InventoryService,
    private notify: NotifyService) { }

    //********************************************************************************* */
  ngOnInit() {
    this.createForm();
    this.inventoryForm.reset();
    this.inventoryForm.patchValue(this.inventory);
  }
  //******************************************************************************************* */
  createForm() {
    this.inventoryForm = this.fb.group({
      makho: [null],
      tenkho: [null, [Validators.required]],
      
      // createdDate: [null],
      // createdBy: [null],
      // status: [null]
    });
  }


  saveChanges() {
    const inventory = this.inventoryForm.getRawValue();
    if (this.isAddNew) {
      this.inventoryService.addNew(inventory).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.CREATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);
    } else {
      this.inventoryService.update(inventory).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.UPDATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);
    }
  }
  
  destroyModal() {
    this.modal.destroy(false);
  }

}
