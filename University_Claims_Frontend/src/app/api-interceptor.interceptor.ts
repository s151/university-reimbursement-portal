import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ApiInterceptorInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token=localStorage.getItem("token")
    const BASE_URL="http://localhost:5255/api/v1/";
    if(token){
      const newreq=request.clone({
        url: BASE_URL+request.url,
        setHeaders: { Authorization: `Bearer ${token}`}
      })
      return next.handle(newreq);
    }else{
      const req=request.clone({
        url: BASE_URL+request.url
      })
      return next.handle(req);
    }
  }
}
