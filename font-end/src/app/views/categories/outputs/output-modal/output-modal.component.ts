import { Component, OnInit, Input, HostListener } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd';
import { Output } from '../../../../shared/models/output.model'
import { NotifyService } from '../../../../shared/services/notify-service'
import { MessageConstant } from '../../../../shared/constants/message-constant'
import { StockService } from '../../../../shared/services/stock-service'

import { CustomerService } from 'src/app/shared/services/customer-service';
import { Stock } from 'src/app/shared/models/stock.model';
import { Customer } from 'src/app/shared/models/customer.model';
import { UnitService } from 'src/app/shared/services/unit-service';
import { OutputService } from 'src/app/shared/services/output-service';

@Component({
  selector: 'app-output-modal',
  templateUrl: './output-modal.component.html',
  styleUrls: ['./output-modal.component.scss']
})
export class OutputModalComponent implements OnInit {
  @Input() output: Output;

  @Input() isAddNew: boolean;

  outputForm: FormGroup;
  loadingSaveChanges: boolean;

  ListOfCustomers = [];
  ListOfStocks = [];


  constructor(private fb: FormBuilder,
    private modal: NzModalRef,
    private customerService: CustomerService,
    private notify: NotifyService,
    private stockService:StockService,
    private outputService: OutputService,
    ) { }

  ngOnInit() {
    this.loadStocks();
    this.loadCustomers();
    
    this.createForm();
    this.outputForm.reset();
    this.outputForm.patchValue(this.output);
  }

  createForm() {
    this.outputForm = this.fb.group({
      mapx: [null],
      tenpx: [null, [Validators.required]],
      soluongxuat: [null],
      ngayxuat: [null, [Validators.required]],
      tinhtrangxuat: [Validators.required],
      thanhtien: [null],
      customername: [Validators.required],

      stockname: [null, [Validators.required]],
      Idstock: [Validators.required],
      CustomerId: [Validators.required],
      dongiaxuat:[null],


      // createdDate: [null],
      // createdBy: [null],
      // status: [null]
    });
  }

  loadStocks() {
    this.stockService.getAll().subscribe((res: Stock[]) => {
      this.ListOfStocks = res;
    });
  }

  loadCustomers() {
    this.customerService.getAll().subscribe((res: Customer[]) => {
      this.ListOfCustomers = res;
    });
  }

 

  destroyModal() {
    this.modal.destroy(false);
  }

  saveChanges() {
    const output = this.outputForm.getRawValue();

    console.log(output);
    if (this.isAddNew) {
      this.outputService.addNew(output).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.CREATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);

    }
    else {
      this.outputService.update(output).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.UPDATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);
    }

  }
  
  

 

}
