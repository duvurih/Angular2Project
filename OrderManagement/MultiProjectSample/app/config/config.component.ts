import { Injectable } from "@angular/core";

@Injectable()
export class ConfigComponent {
    static appErrorPrefix: string = "Application Error: ";
    static idle: number = 1200; // 20 minutes
    static idleTimeOut: number = 60; // 1 minute before timeout
    static keepAliveTimeOut: number = 1080; // ping to server after every 18 minutes to keep cookie active
    static timeoutMessage: string = "You have been logged out due to inactivity.";
    static successfulLogoutMessage: string = "You have been logged out successfully.";
    static accessDeniedMessage: string = "You do not have access to this portal.";
    static cryptographicKey: string;
    static defaultResultRowCount: number;
    static lastUsedModule: string;
}