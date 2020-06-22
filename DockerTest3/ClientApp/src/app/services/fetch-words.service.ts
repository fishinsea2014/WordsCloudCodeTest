import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CloudWord } from '../domain/cloudWord';

@Injectable({
  providedIn: 'root'
})
export class FetchWordsService {

constructor(private http:HttpClient) { }
getWordsData(url:string){
  console.log(encodeURI(url));
  return this.http.get<CloudWord[]>(
    `api/WebsiteWords/CreateWordCloud/${encodeURIComponent(url)}`
  );
}
}
