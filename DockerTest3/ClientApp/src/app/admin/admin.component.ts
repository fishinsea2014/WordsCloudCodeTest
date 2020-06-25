import { Component, OnInit, ViewChild } from '@angular/core';
import { CloudWord } from '../domain/cloudWord';
import { GetAllWordsService } from '../services/get-all-words.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  
  displayedColumns:string[] = ["text","weight"];
  dataSource: MatTableDataSource<CloudWord>;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  showSpinner=false;

  constructor(private getAllWordsService:GetAllWordsService) {
    this.showSpinner=true;
   }

  ngOnInit() {
    //this.showSpinner = true;
    
    this.getAllWordsService.getAllWords()    
    .subscribe(
      data =>{
        console.log(data);
        this.dataSource= new  MatTableDataSource<CloudWord>(data);
        this.dataSource.paginator = this.paginator;
        this.showSpinner=false;
      },
      err =>{
        console.log(err);
        this.showSpinner=false;
      }


    )
  }
}

