import { Component, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ValidationService } from '../services/validation.service';

@Component({
    selector: 'validation-messages',
    templateUrl: "app/common/validation-component.html"
})
export class ValidationMessages {

    @Input() control: FormControl;
    @Input() controlname: any;
    @Input() validations: any;
    constructor() { }

    get errorMessage():string {
        for (let propertyName in this.control.errors) {
            if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
                return ValidationService.getValidatorErrorMessage(this.controlname, propertyName, this.control.errors[propertyName],this.validations);
            }
        }

        return null;
    }
}