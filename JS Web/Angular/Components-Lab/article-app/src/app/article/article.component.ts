import { Component, Input, OnInit } from '@angular/core';
import {Article} from '../models/article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  private symbols:number = 250;
  @Input() article:Article;
  @Input() articleDesc:string;
  descToShow:string;
  articleDescLen:number;
  showReadMoreBtn:boolean=true;
  showHideBtn:boolean=false;
  imageIsShown:boolean=false;
  imageButtonTitle:string='Show Image';

  readMore():void{
    this.articleDescLen+=this.symbols;
    if (this.articleDescLen >= this.articleDesc.length) {
      this.showReadMoreBtn = false;
      this.showHideBtn = true;
      return;
    }
    this.descToShow = this.articleDesc.substring(0,this.articleDescLen);
  }

  hideDesc():void{
    this.articleDescLen = 0;
    this.descToShow = '';
    this.showReadMoreBtn = false;
    this.showHideBtn = true;
  }

  toggleImage():void{
    this.imageIsShown = !this.imageIsShown;
    if (this.imageButtonTitle === 'Show Image') {
      this.imageButtonTitle = 'Hide Image';
      return;
    }
    this.imageButtonTitle = 'Show Image';
  }

  constructor() {
      this.articleDescLen = 0;
      this.descToShow = '';
     }

  ngOnInit(): void {
  }

}
