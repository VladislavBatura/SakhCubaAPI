import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { AdminService } from '../Services/admin.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGetOneResolver implements Resolve<boolean> {

  constructor(private adminService:AdminService)
  {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
    let id = Number(route.paramMap.get('id')) || 0;
    return this.adminService.getOneApplication(id);
  }

}
