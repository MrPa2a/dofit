import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterContentInit, Component, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDrawerMode, MatSidenav } from '@angular/material/sidenav';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemService } from './services/item.service';
import { SellService } from './services/sell.service';
import { LoadingStore } from './store/loading/loading.store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterContentInit {

  loading$ = this.store.select('loading');
  showSidenav = false;
  modeSidenav = new FormControl('over' as MatDrawerMode);

  routes = [
    {route:'/history', icon: 'dvr', selected: true, label: "Historique des ventes"},
    {route:'/stats', icon: 'trending_up', selected: false, label: "Statistiques"},
  ]
  
  constructor(
    private itemService: ItemService,
    private sellService: SellService,
    private store: LoadingStore,
    private observer: BreakpointObserver,
    private route: ActivatedRoute
  ) {
    this.itemService.init();
    this.sellService.init();
    const path = window.location.pathname
    this.updateSelectedRoutes('/' + path.split('/')[path.split('/').length - 1] || '/history');
  }

  updateSelectedRoutes(selectedRoute: string) {
    this.routes.forEach(route => {
      if (selectedRoute === route.route) {
        route.selected = true; 
      } 
      else {
        route.selected = false;
      }
    })
  }

  ngAfterContentInit() {
    this.observer.observe(['(max-width: 700px)']).subscribe((res) => {
      if (res.matches) {
        this.modeSidenav.setValue('over');
      } else {
        this.modeSidenav.setValue('side');
      }
    });
  }
}
