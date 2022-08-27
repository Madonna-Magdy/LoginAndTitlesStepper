import { TitleService } from './../services/title.service';
import { Component } from '@angular/core';
import { TitleVm } from '../models/title-vm';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  titles: TitleVm[] = [];
  stepTitles: TitleVm[] = [];
  stepIndexes: number[] = [];
  maxStep = 0;
  selectedStep = 1;
  isAddItem = false;

  constructor(private _formBuilder: FormBuilder, private titleService: TitleService) {
    this.fillData();
  }

  ngOnInit() {
    this.addStep();
  }

  fillData() {
    this.titleService.get().subscribe(result => {
      this.titles = result;
      this.maxStep = this.titles.length > 0 ? Math.max(...this.titles.map(x => x.stepNumber)) : 0;
      this.stepIndexes = Array(this.maxStep + 1).fill(0).map((x, i) => i + 1);
      this.getStepTitles(1);
    }, error => console.error(error));
  }

  addStep(stepNo: number) {
    this.getStepTitles(stepNo);
    this.maxStep = stepNo > this.maxStep ? stepNo : this.maxStep;
    this.stepIndexes = Array(this.maxStep + 1).fill(0).map((x, i) => i + 1);
  }

  getStepTitles(stepNo: number) {
    this.selectedStep = stepNo;
    this.stepTitles = stepNo <= this.maxStep ? this.titles.filter(x => x.stepNumber === stepNo) : [];
  }

  add(title) {
    const model: TitleVm = {
      id: 0,
      name: title.name,
      description: title.description,
      stepNumber: this.selectedStep
    };
    this.titleService.post(model).subscribe(() => {
      this.fillData();
      this.isAddItem = false;
    }, error => console.error(error));
  }

  update(id, title) {
    const model: TitleVm = {
      id: id,
      name: title.name,
      description: title.description,
      stepNumber: this.selectedStep
    };
    this.titleService.put(model).subscribe(() => this.fillData(), error => console.error(error));
  }

  delete(id) {
    this.titleService.delete(id).subscribe(() => this.fillData(), error => console.error(error));
  }

  deleteStep(stepNo) {
    this.titleService.deleteStep(stepNo).subscribe(() => this.fillData(), error => console.error(error));
  }
}
