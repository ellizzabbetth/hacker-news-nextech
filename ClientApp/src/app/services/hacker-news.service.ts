import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';

import { Observable } from 'rxjs';
import { of } from 'rxjs';


import { map, catchError } from 'rxjs/operators';

// import {IStory } from '../../shared/interfaces';
import { environment } from 'src/environments/environment';
import { IStory } from '../models/IStory';




@Injectable({
  providedIn: 'root'
})


export class HackerNewsService {
  baseUrl = environment.apiUrl;
  baseHackerUrl = this.baseUrl + 'hackernews';
  // private headers: HttpHeaders;
  // httpOptions = {
  //   headers: new HttpHeaders({
  //     'Content-Type': 'application/json; charset=utf-8'
  //   })
  // };
  newStories$: IStory[];



  constructor(private http: HttpClient) { 
    // this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }


  // https://app.pluralsight.com/guides/sending-request-processing-mapped-response-retrieve-data
  getNewStories(): Observable<IStory[]> {
      console.log(this.baseHackerUrl);
      return this.http
      .get(this.baseHackerUrl)// , {headers: this.headers})
          .pipe(
              map((data: IStory[]) => {
                console.log(data);
                  return data;
              }),
              catchError(this.handleError)
          );
  }

  getStories(searchTerm: string): Observable<IStory[]>  {
    console.log(this.baseHackerUrl, searchTerm);
    return this.http
      .get<IStory[]>(
        `${this.baseHackerUrl}?searchTerm=${searchTerm}`
      );
       // below works :)
      // this.http
      // .get<IStory[]>(
      //   `${this.baseHackerUrl}?searchTerm=${searchTerm}`
      // )
      // .subscribe(
      //   result => {
      //     console.log(result);
      //     this.newStories$ = result;
      //   },
      //   error => console.error(error)
      // );

       // this.newStories$ = [
    //   {
    //     title:
    //       'Ask HN: If you plan success, why ever raise equity instead of debt?',
    //     by: 'flibble',
    //     url: null,
    //   },
    //   {
    //     title:
    //       'Credentials hiding in plain sight or how I pwned your HTTP auth',
    //     by: 'gehaxelt',
    //     url:
    //       'https://0day.work/credentials-hiding-in-plain-sight-or-how-i-pwned-your-http-auth/',
    //   },
    // ];
    // return of(this.newStories$);
  }

  private handleError(error: HttpErrorResponse) {
      console.error('Server error:', error);
      if (error.error instanceof Error) {
          const errMessage = error.error.message;
          return Observable.throw(errMessage);
      }
      return Observable.throw(error || 'Server error');
  }
}
