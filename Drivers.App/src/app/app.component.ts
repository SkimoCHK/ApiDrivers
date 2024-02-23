import { Component } from '@angular/core';
import { Driver } from './models/driver';
import { DriverService } from './services/driver.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Drivers.App';
  drivers:Driver[]=[];
  constructor(private driverService: DriverService){}

  ngOnInit():void{
    this.driverService.getDrivers().subscribe((result:Driver[]) => (this.drivers=result));
    console.log(this.drivers); 
  }
}
