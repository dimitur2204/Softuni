import { Component, Input, OnInit } from '@angular/core';
import { ITheme } from '../interfaces/theme';

@Component({
  selector: 'app-theme-item',
  templateUrl: './theme-item.component.html',
  styleUrls: ['./theme-item.component.css']
})
export class ThemeItemComponent implements OnInit {

  @Input() theme!:ITheme;

  constructor() { }

  ngOnInit(): void {
    
  }

}
