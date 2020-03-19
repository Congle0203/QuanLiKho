// import { Component, OnInit, Input, HostListener } from '@angular/core';

// import { UnitService } from '../../../../shared/services/unit-service';
// import { Unit } from '../../../../shared/models/unit.model';
// import { NotifyService } from 'src/app/shared/services/notify-service';
// import { MessageConstant } from '../../../../shared/constants/message-constant'
// import { ConfigConstant } from '../../../../shared/constants/config-constant'
// // import { FormGroup } from '@angular/forms';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { NzModalRef } from 'ng-zorro-antd';


// @Component({
//   selector: 'app-unit-modal',
//   templateUrl: './unit-modal.component.html',
//   styleUrls: ['./unit-modal.component.scss']
// })
// export class UnitModalComponent implements OnInit {



//   @Input() unit: Unit;
//   @Input() isAddNew: boolean;

//   unitForm: FormGroup;

//   loadingSaveChanges: boolean;

//   constructor(private fb: FormBuilder,
//     private modal: NzModalRef,
//     private unitService: UnitService,
//     private notify: NotifyService) { }

//   ngOnInit() {
//     this.createForm();
//     this.unitForm.reset();
//     this.unitForm.patchValue(this.unit);
//   }

//   createForm() {
//     this.unitForm = this.fb.group({
//       id: [null],
//       name: [null, [Validators.required]],
//       createdDate: [null],
//       createdBy: [null],
//       status: [null]
//     });
//   }


//   saveChanges() {
//     const unit = this.unitForm.getRawValue();
//     if (this.isAddNew) {
//       this.unitService.addNew(unit).subscribe((res: any) => {
//         if (res) {
//           this.notify.success(MessageConstant.CREATED_OK_MSG);
//           this.modal.destroy(true);
//         }

//         this.loadingSaveChanges = false;
//       }, _ => this.loadingSaveChanges = false);
//     } else {
//       this.unitService.update(unit).subscribe((res: any) => {
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


import { Component, OnInit, Input, HostListener } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd';
import { Unit } from '../../../../shared/models/unit.model'
import { NotifyService } from '../../../../shared/services/notify-service'
import { MessageConstant } from '../../../../shared/constants/message-constant'
import { UnitService } from '../../../../shared/services/unit-service'

@Component({
  selector: 'app-unit-modal',
  templateUrl: './unit-modal.component.html',
  styleUrls: ['./unit-modal.component.scss']
})


export class UnitModalComponent implements OnInit {

  @Input() unit: Unit;
  @Input() isAddNew: boolean;

  unitForm: FormGroup;

  loadingSaveChanges: boolean;

  constructor(private fb: FormBuilder,
    private modal: NzModalRef,
    private unitService: UnitService,
    private notify: NotifyService) { }

    //********************************************************************************* */
  ngOnInit() {
    this.createForm();
    this.unitForm.reset();
    this.unitForm.patchValue(this.unit);
  }
  //******************************************************************************************* */
  createForm() {
    this.unitForm = this.fb.group({
      madv: [null],
      tendv: [null, [Validators.required]],
      Description: [null, [Validators.required]],
      
      // createdDate: [null],
      // createdBy: [null],
      // status: [null]
    });
  }


  saveChanges() {
    const unit = this.unitForm.getRawValue();
    if (this.isAddNew) {
      this.unitService.addNew(unit).subscribe((res: any) => {
        if (res) {
          this.notify.success(MessageConstant.CREATED_OK_MSG);
          this.modal.destroy(true);
        }

        this.loadingSaveChanges = false;
      }, _ => this.loadingSaveChanges = false);
    } else {
      this.unitService.update(unit).subscribe((res: any) => {
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


