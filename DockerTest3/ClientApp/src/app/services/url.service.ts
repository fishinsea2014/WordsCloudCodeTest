import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

constructor(private http:HttpClient) { }
validateUrl(url:string){
  return this.http.get<any>(url);
}

}
