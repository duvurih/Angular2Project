import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { Ng2TableModule } from "ng2-table/components/ng-table-module";
import { PaginationModule } from "ng2-bootstrap";

@Component({
    selector: "table",
    templateUrl: "app/common/table-component.html"
})

export class TableComponent implements OnInit {
    public rows: Array<any> = [];
    @Input() columns: Array<any> = [];
    @Input() data: Array<any> = [];
    @Input() config: any;
    elementObj: any;
    public page: number = 1;
    public itemsPerPage: number = 10;
    public maxSize: number = 5;
    public numPages: number = 1;
    public length: number = 0;
    @Output() elementClickEvent: EventEmitter<any> = new EventEmitter();

    constructor() {
        this.length = this.data.length;
    }

    public ngOnInit(): void {
        this.onChangeTable(this.config);
    }

    bindTable(data: Array<any> = this.data):void {
        this.data = data;
        if (this.page > Math.ceil(this.data.length / this.itemsPerPage)) {
            this.page -= 1;
        }
        this.onChangeTable(this.config);
    }

    public changePage(page: any, data: Array<any> = this.data): Array<any> {
        let start: number = (page.page - 1) * page.itemsPerPage;
        let end: number = page.itemsPerPage > -1 ? (start + page.itemsPerPage) : data.length;
        return data.slice(start, end);
    }

    public changeSort(data: any, config: any): any {
        if (!config.sorting) {
            return data;
        }

        let columns = this.config.sorting.columns || [];
        let columnName: string = void 0;
        let sort: string = void 0;

        for (let i = 0; i < columns.length; i++) {
            if (columns[i].sort !== "" && columns[i].sort !== false) {
                columnName = columns[i].name;
                sort = columns[i].sort;
            }
        }

        if (!columnName) {
            return data;
        }

        // simple sorting
        return data.sort((previous: any, current: any) => {
            if (previous[columnName] > current[columnName]) {
                return sort === "desc" ? -1 : 1;
            } else if (previous[columnName] < current[columnName]) {
                return sort === "asc" ? -1 : 1;
            }
            return 0;
        });
    }

    public changeFilter(data: any, config: any): any {
        if (!config.filtering) {
            return data;
        }

        let filteredData: Array<any> = data.filter((item: any) =>
            item[config.filtering.columnName].toLowerCase().match(this.config.filtering.filterString.toLowerCase()));

        return filteredData;
    }

    public onChangeTable(config: any, page: any = { page: this.page, itemsPerPage: this.itemsPerPage }): any {
        if (config.filtering) {
            Object.assign(this.config.filtering, config.filtering);
        }
        if (config.sorting) {
            Object.assign(this.config.sorting, config.sorting);
        }

        let filteredData = this.changeFilter(this.data, this.config);
        let sortedData = this.changeSort(filteredData, this.config);
        this.rows = page && config.paging ? this.changePage(page, sortedData) : sortedData;
        this.length = sortedData.length;
    }

    public raiseClickEvent(row: any) {
        this.elementClickEvent.emit(row);
    }
}
