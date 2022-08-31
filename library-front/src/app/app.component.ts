import { Component, OnInit } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'library-front';

  items: MenuItem[] =[{
    label: 'Liste des livres'
  },{
    label: 'Auteurs'
  }

]

  constructor() {}
  ngOnInit() {

  }
}
