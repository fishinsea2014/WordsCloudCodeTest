import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators, ValidatorFn,AsyncValidatorFn, AbstractControl } from '@angular/forms';
import { FetchWordsService } from '../services/fetch-words.service';
import { CloudOptions, CloudData } from 'angular-tag-cloud-module';
import { UrlService } from '../services/url.service';
import {debounceTime,distinctUntilChanged, switchMap, map} from 'rxjs/operators'
import { Observable } from 'rxjs';
import {MatDialog} from '@angular/material';
import { componentFactoryName } from '@angular/compiler';

@Component({
  selector: 'app-word-cloud',
  templateUrl: './word-cloud.component.html',
  styleUrls: ['./word-cloud.component.css']
})
export class WordCloudComponent implements OnInit {

  showSpinner=false;

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

  urlString = new FormControl(null,Validators.required);
  getErrorMessage(){
    if (this.urlString.hasError('required')){
      return "Please input a website address.";
    }
    if (this.urlString.hasError('invalidURL')){
      return "Invalid URL";
    }
  } 

  validateURL():AsyncValidatorFn{
    return (control:AbstractControl):Observable<{[key:string] :any} | null> =>{
      return this._urlService.validateUrl(control.value).pipe(
        map(res => {
          console.log(res);
          return null;
        },
        err =>{
          console.log(err);
        }),
        distinctUntilChanged(),
        debounceTime(300),
      )

    }
  }
  constructor(private fb:FormBuilder,
              private fetchWordsService:FetchWordsService,
              private _urlService:UrlService,
              private _dialog:MatDialog) { }

  ngOnInit() {}

  submitUrl(){
    this.showSpinner=true;
    this.fetchWordsService.getWordsData(this.urlString.value)
    .subscribe(
      data =>{        
        this.data = data;
        this.showSpinner=false;
      },
      err =>{
        this.showSpinner=false;
        this._dialog.open(DialogGetWordErrorComponent);
      }
    );
  }

}

//Dialog component.
@Component({
  selector:'dialog-get-wrods-error',
  templateUrl:'dialog-get-wrods-error.html',
})
export class DialogGetWordErrorComponent{}
