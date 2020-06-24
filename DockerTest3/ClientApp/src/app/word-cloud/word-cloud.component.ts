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
    {text: 'Welcome to word cloud of Jason', weight: 6 },
    {text: 'Please input a website URL', weight: 5},
    {text: 'Word Cloud', weight: 3},
    {text: 'Word Cloud', weight: 3},
    {text: 'Word Cloud', weight: 3},
    {text: 'Welcome', weight: 8},
    {text: 'Hi', weight: 7},
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
    this.fetchWordsService.getWordsData(this.urlString.value)
    .subscribe(
      data =>{        
        this.data = data;
      }
    );
  }

}
