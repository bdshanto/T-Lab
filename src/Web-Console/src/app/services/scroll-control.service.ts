import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ScrollControlService {
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
  ){
  }

  getDiglogLeft(dialogWidth: number = 400){
    return {leftposition: ((window.innerWidth / 2) - dialogWidth / 2), dialogWidth};
  }


}
