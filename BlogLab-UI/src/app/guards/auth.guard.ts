import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from '../services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(
    private accountService: AccountService,
    private router: Router
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {

      const currentUser = this.accountService.currentUserValue;
      const isLoggedIn = currentUser && currentUser.token;
    
      if (isLoggedIn) {
        return true;
      }
    
      this.router.navigate(['/']);
      return false;
  }
  
}
