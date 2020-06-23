import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CloudWord } from '../domain/cloudWord';

@Injectable({
  providedIn: 'root'
})
export class GetAllWordsService {

constructor(private httpclient:HttpClient) { }
getAllWords() {
  return this.httpclient.get<CloudWord[]>("api/WebsiteWords");
}

}
