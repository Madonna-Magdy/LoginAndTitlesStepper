import { TitleService } from './../services/title.service';
import { Component } from '@angular/core';
import { TitleVm } from '../models/title-vm';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public titles: TitleVm[];

  constructor(private titleService: TitleService) {
    titleService.get().subscribe(result => {
      this.titles = result;
    }, error => console.error(error));
  }
}
