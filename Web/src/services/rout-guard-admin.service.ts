import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from './login.Service';
import { inject } from '@angular/core';
import jwt_decode from 'jwt-decode';

export const routeGuardAdmin: CanActivateFn = (route, state) => {
const token:any = localStorage.getItem("token");

    if (token != null) {
      const tokenData:any = jwt_decode(token);
      const role:any = tokenData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      
      if(role.toLowerCase() == 'admin'){
      return true
      }
      else{
        inject(Router).navigate(['/Home']);
        return false;
      }
 
    }
    inject(Router).navigate(['/login']);
    return false;
  
  }