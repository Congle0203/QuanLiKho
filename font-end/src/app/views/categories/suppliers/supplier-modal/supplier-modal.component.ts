import { Component, OnInit, Input } from '@angular/core';
import { Supplier } from 'src/app/shared/models/supplier.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd';
import { SupplierService } from 'src/app/shared/services/supplier-service';
import { NotifyService } from 'src/app/shared/services/notify-service';
import { MessageConstant } from 'src/app/shared/constants/message-constant';

@Component({
  selector: 'app-supplier-modal',
  templateUrl: './supplier-modal.component.html',
  styleUrls: ['./supplier-modal.component.scss']
})
export class SupplierModalComponent implements OnInit {
  @Input() supplier: Supplier;
  @Input() isAddNew: boolean;

  supplierForm: FormGroup;

  loadingSaveChanges: boolean;

  constructor(private fb: FormBuilder,
    private modal: NzModalRef,
    private supplierService: SupplierService,
    private notify: NotifyService) { }

    //********************************************************************************* */
  ngOnInit() {
    this.createForm();
    this.supplierForm.reset();
    this.supplierForm.patchValue(this.supplier);
  }
  //******************************************************************************************* */
  createForm() {
    this.supplierForm = this.fb.group({
      mancc: [null],
      tenncc: [null, [Validators.required]],
      diachi: [null, [Validators.required]],
      sdt: [null],
      
      // createdDate: [null],
      // createdBy: [null],
      // status: [null]
    });
  }


  saveChanges() {
    const supplier = this.supplierForm.getRawValue();
    if (this.isAddNew) {
      this.supplierService.addNew(supplier).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.CREATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);
    } else {
      this.supplierService.update(supplier).subscribe((res: any) => {
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
