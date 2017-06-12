import { Component, Input, Output, EventEmitter, forwardRef } from "@angular/core";
import { FormsModule, ReactiveFormsModule, FormGroup, FormControl, NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { TypeaheadModule } from "ng2-bootstrap";
import { DataContextService } from "../services/datacontext.service";
import { Observable } from "rxjs/Observable";

const noop = () => { };
export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => AutoCompleteComponent),
    multi: true
};

@Component({
    selector: 'auto-complete',
    templateUrl: 'app/common/autocomplete.html'
})
export class AutoCompleteComponent implements ControlValueAccessor {
    @Input() inputId: string;
    @Input() inputClass: string;
    @Input() inputPlaceHolder: string;
    @Input() searchUrl: string;
    @Input() asyncDisplayText: string;
    @Input() asyncSetValue: string;
    @Output() emitSelectedObj: EventEmitter<any> = new EventEmitter();
    selectedObj: any;
    private _value: any = '';
    public autoCompleteLoading: boolean = false;
    public autoCompleteNoResults: boolean = false;
    public autoCompleteRef: Observable<any>;

    constructor(private dataContextService: DataContextService) {
        this.autoCompleteRef = Observable.create((observer: any) => {
            observer.next(this.asyncSetValue);
        }).mergeMap((searchPhrase: string) => this.dataContextService.httpPost(this.searchUrl, searchPhrase));
    }

    private _onTouchedCallback: () => void = noop;

    private _onChangeCallback: (e: any) => void = noop;

    get value(): any { return this._value; };

    set value(v: any) {
        if (v !== this._value) {
            this._value = v;
            this._onChangeCallback(v);
        }
    }

    writeValue(value: any) {
        this._value = value;
    }

    registerOnChange(fn: any) {
        this._onChangeCallback = fn;
    }

    registerOnTouched(fn: any) {
        this._onTouchedCallback = fn;
    }

    public changeTypeaheadLoading(e: boolean): void {
        this.autoCompleteLoading = e;
    }

    public changeTypeaheadNoResults(e: boolean): void {
        this.autoCompleteNoResults = e;
        this.selectedObj = null;
    }

    public autoCompleteOnSelect(e: any): void {
        this.selectedObj = e.item;
        this.emitSelectedObj.next(this.selectedObj);
    }

    public autoCompleteOnClear(e: any): void {
        this.autoCompleteNoResults = true;
        this.selectedObj = null;
        this.emitSelectedObj.next(this.selectedObj);
    }
}
