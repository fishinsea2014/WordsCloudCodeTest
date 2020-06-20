import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { FetchWordsService } from '../services/fetch-words.service';
import { CloudOptions, CloudData } from 'angular-tag-cloud-module';

@Component({
  selector: 'app-word-cloud',
  templateUrl: './word-cloud.component.html',
  styleUrls: ['./word-cloud.component.css']
})
export class WordCloudComponent implements OnInit {

  options:CloudOptions={
    width:1000,
    height:400,
    overflow:false
  };

  data:CloudData[]=[
    {text: 'Weight-8-link-color', weight: 8 },
    {text: 'Weight-100-link', weight: 100},
    {text: 'Weight-1-link', weight: 1},
    {text: 'Weight-2-link', weight: 2},
    {text: 'Weight-3-link', weight: 3},
  ]

  urlString = new FormControl('',[Validators.required]);
  getErrorMessage(){
    if (this.urlString.hasError('required')){
      return "Please input a website address."
    }
  } 
  constructor(private fb:FormBuilder,
              private fetchWordsService:FetchWordsService) { }

  ngOnInit() {
 

  }

  submitUrl(){
    console.log(this.urlString.value);
    this.fetchWordsService.getWordsData();
  }

}
