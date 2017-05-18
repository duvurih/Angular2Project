import { ErrorHandler, Injectable } from "@angular/core";

@Injectable()
export class GenericExceptionHandler implements ErrorHandler {
    private genericErrorMessage: any;

    public handleError(error:any): void {
        if (error.status !== undefined) {
            if (error.status === 400) {
                location.href = "Error/Index";
                this.genericErrorMessage = error.exceptionMessage;
            } else if (error.status === 404) {
                location.href = "Error/NotFound";
                this.genericErrorMessage = error.exceptionMessage;
            } else if (error.status === 401) {
                location.href = "Error/UnAuthorized";
                this.genericErrorMessage = error.exceptionMessage;
            } else if (error.status === 500) {
                const errorInfo:any = JSON.parse(error._body);
                if (errorInfo !== null && errorInfo !== undefined) {
                    this.genericErrorMessage = errorInfo.exceptionMessage;
                }
            } else if (error.status === 0 && error.type === 3) {
                this.genericErrorMessage = "Data supplier API not accessible.";
            }
        } else {
            if (error.rejection !== undefined && error.rejection.name === "ObjectUnsubscribedError") {
                location.href = "Error/NotFound";
            } else {
                const errMsg:any = error._body !== undefined ? error.json().exceptionMessage : error.message;
                this.genericErrorMessage = errMsg;
            }
        }
        console.log(this.genericErrorMessage);
    }
}