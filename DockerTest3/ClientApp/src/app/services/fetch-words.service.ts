import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FetchWordsService {

constructor() { }
getWordsData(){
  console.log("Fetching words.....");
}
}
