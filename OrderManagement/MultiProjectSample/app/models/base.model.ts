export class BaseModel {

    checkUndefinedValue(column: any): any {
        return (column === undefined) ? "" : column;
    }
}