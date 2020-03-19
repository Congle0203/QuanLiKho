import { Component, OnInit, Input, HostListener } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd';
import { NotifyService } from '../../../../shared/services/notify-service'
import { MessageConstant } from '../../../../shared/constants/message-constant'
import { Receipt } from 'src/app/shared/models/receipt.model';
import { ReceiptService } from 'src/app/shared/services/receipt-service';
import { Stock } from 'src/app/shared/models/stock.model';
import { StockService } from 'src/app/shared/services/stock-service';

@Component({
  selector: 'app-receipt-modal',
  templateUrl: './receipt-modal.component.html',
  styleUrls: ['./receipt-modal.component.scss']
})


export class ReceiptModalComponent implements OnInit {

  @Input() receipt: Receipt;

  @Input() isAddNew: boolean; 

  receiptForm: FormGroup;
  loadingSaveChanges: boolean;

  ListOfStocks = [];



  constructor(private fb: FormBuilder,
    private modal: NzModalRef,
    private receiptService: ReceiptService,
    private notify: NotifyService,
    private stockService:StockService,
  
    ) { }

  ngOnInit() {
    this.loadStocks();
    
    this.createForm();
    this.receiptForm.reset();
    this.receiptForm.patchValue(this.receipt);
  }

  createForm() {
    this.receiptForm = this.fb.group({
      mapn: [null],
      tenpn: [null, [Validators.required]],
      ngaynhap: [null],
      stockId: [null, [Validators.required]],
      soluongnhap: [Validators.required],
      tinhtrang: [null],
      dongianhap: [Validators.required],

      stockname: [null, [Validators.required]],
     


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

  destroyModal() {
    this.modal.destroy(false);
  }

  saveChanges() {
    const receipt = this.receiptForm.getRawValue();

    console.log(receipt);
    if (this.isAddNew) {
      this.receiptService.addNew(receipt).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.CREATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);

    }
    else {
      this.receiptService.update(receipt).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.UPDATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);
    }

  }
  

 

}
