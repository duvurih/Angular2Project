// importing angular core
import { Component, Input, DoCheck } from "@angular/core";
import { Http, Headers, URLSearchParams } from "@angular/http";

// importing data services
import { DataContextService } from "../services/datacontext.service";

// importing url endpoints
import { URLEndPoints } from "../common/urlendpoints.component";

@Component({
    selector: "location",
    templateUrl: "app/common/location.html"
})
export class LocationComponent implements DoCheck {

    // initializing variables
    @Input() address: any;
    @Input() company: any;
    private lastAddress: any;

    // google maps zoom level
    zoom: number = 8;
    title: string = 'My first angular2-google-maps project';
    // initial center position for the map
    lat: number = 51.673858;
    lng: number = 7.815982;

    // constructor
    constructor(
        private _http: Http,
        private dataContextService: DataContextService,
    ) {
        //this.getCustomerLocation();
    }

    // initialization methods
    ngDoCheck() {
        //var change:any = this.lastAddress.diff(this.address);
        if (this.address !== undefined) {
            if (this.lastAddress !== this.address) {
                this.getLocationByAddress()
                // this.getLocationByAddressApi();
            }
        }
    }

    getLocationByAddressApi(): void {
        this.lastAddress = this.address;

        this.dataContextService.httpPost(URLEndPoints.GOOGLE_MAP_API_GET_LOCATION, this.address)
            .subscribe((resultData: any) => {
                let place: any = JSON.parse(resultData._body);
                this.lat = place.results[0].geometry.location.lat;
                this.lng = place.results[0].geometry.location.lng;
            });
    }
    getLocationByAddress() {

        //let addressResult = new google.maps.places.Autocomplete(this.address, { types: ["address"] });
        //addressResult.addListener("place_changed", () => {
        //    let place : google.maps.places.PlaceResult = addressResult.getPlace();

        //    //verify result
        //    if (place.geometry === undefined || place.geometry === null) {
        //        return;
        //    }

        //    //set latitude, longitude and zoom
        //    this.lat = place.geometry.location.lat();
        //    this.lng = place.geometry.location.lng();
        //    this.zoom = 12;
        //});

        this.lastAddress = this.address;

        this._http.get('https://maps.googleapis.com/maps/api/geocode/json?address=' + this.address + '&key=AIzaSyA1vWp8aa0ohma7Zev45V7T2y5842aOh0I', null)
            .subscribe((resultData: any) => {
                let place: any = JSON.parse(resultData._body);
                this.lat = place.results[0].geometry.location.lat;
                this.lng = place.results[0].geometry.location.lng;
            });
    }

}