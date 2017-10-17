// importing angular core
import { Component, OnInit, trigger, state, style, transition, animate } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

@Component({
    selector: "dashboard",
    templateUrl: "app/features/dashboard/dashboard.html",
    animations: [
        trigger("flyInOut", [
            state("in", style({ opacity: 1, transform: "translateX(0)" })),
            transition("void => *", [
                style({
                    opacity: 0,
                    transform: "translateX(-100%)"
                }),
                animate("0.6s ease-in")
            ]),
            transition("* => void", [
                animate("0.2s 10 ease-out", style({
                    opacity: 0,
                    transform: "translateX(100%)"
                }))
            ])
        ])
    ]
})
export class DashboardComponent implements OnInit {

    // initializing variables
    options: Object;
    optionsSecond: Object;

    // constuctor
    constructor(
        private dataContextService: DataContextService
    ) {
        this.options = {
            title: { text: 'Sales Trend Comparison & Forecasting' },
            subtitle: { text: '2017 Sales Trend and Forecast' },
            xAxis: {
                categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
            },
            series: [
                {
                    name: "2016",
                    animation: true,
                    color: 'green',
                    data: [23.9, 65.5, 33.5, 83.1, 79.1, 80.3, 89.9, 116.4, 120.8, 105.3, 130.9, 139.2],
                },
                {
                    name: "2017",
                    animation: true,
                    color: 'blue',
                    data: [29.9, 75.5, 30.5, 75.1, 70.1, 90.3, 99.9, 106.4, 110.8, 115.3, 120.9, 129.2],
                }
            ]
        };

        this.optionsSecond = {
            title: { text: 'Stock Trend' },
            chart: {
                type: 'column',
                margin: 75,
                options3d: {
                    enabled: true,
                    alpha: 15,
                    beta: 15,
                    depth: 50
                }
            },
            plotOptions: {
                column: {
                    depth: 25
                }
            },
            series: [{
                animation: true,
                data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4]
            }]
        };
    }

    // initialization methods
    ngOnInit(): void {
        console.log("Dashboard Component");
    }




}