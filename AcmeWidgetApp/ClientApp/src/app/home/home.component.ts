import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private router: Router) { }

  title = 'owlcarouselinAngular';
  Images = ['../assets/images/scavengerhunt.png', '../assets/images/board.jpg','../assets/images/rockclimb.jpg'];

  SlideOptions = { items: 1, dots: true, nav: true };
  CarouselOptions = { items: 3, dots: true, nav: true };

  btnClick = function () {

    this.router.navigate(['/participant']);
  }
}
