import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse} from '@angular/common/http';

import { Observable } from 'rxjs';
// import 'rxjs/add/observable/throw';

import { map, catchError } from 'rxjs/operators';

// import {IStory } from '../../shared/interfaces';
import { environment } from 'src/environments/environment';



export interface IStory {
  title: string;
  by: string;
  url: string;
}
@Injectable({
  providedIn: 'root'
})


export class HackerNewsService {
  baseUrl = environment.apiUrl;
  baseHackerUrl = this.baseUrl + 'hackernews';


  constructor(private http: HttpClient) { }

  // https://app.pluralsight.com/guides/sending-request-processing-mapped-response-retrieve-data
  getNewStories(): Observable<IStory[]> {
      return this.http
      .get(this.baseHackerUrl)
          .pipe(
              map((data: IStory[]) => {
                  return data;
              }),
              catchError(this.handleError)
          );
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
