import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { FetchWordsService } from '../services/fetch-words.service';

@Component({
  selector: 'app-word-cloud',
  templateUrl: './word-cloud.component.html',
  styleUrls: ['./word-cloud.component.css']
})
export class WordCloudComponent implements OnInit {

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
