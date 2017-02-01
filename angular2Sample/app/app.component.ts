import { Component } from '@angular/core';
import { ChartModule } from 'angular2-highcharts';

@Component({
    selector: 'my-app',
    styles: [`
      chart {
        display: block;
      }
      button {
        display: block;
        width: 100%;
        height: 25px;
      }
  `],
    templateUrl : 'app/common/charts/series-chart/template.html'
})
export class AppComponent {
    constructor() {
        this.options = {
            title : { text : 'angular2-highcharts example' },
            series: [{
                name: 's1',
                data: [2,3,5,8,13],
                allowPointSelect: true
            },{
                name: 's2',
                data: [-2,-3,-5,-8,-13],
                allowPointSelect: true
            }]
        };
    } 
    options: any;
    chart: any;

    saveChart(chart : any) {
      this.chart = chart;
    }
    addPoint() {
      this.chart.series[0].addPoint(Math.random() * 10);
      this.chart.series[1].addPoint(Math.random() * -10);
    }
    onPointSelect(point : any) {
      alert(`${point.y} is selected`);
    }
    onSeriesHide(series : any) {
      alert(`${series.name} is selected`);
    }
    
}
