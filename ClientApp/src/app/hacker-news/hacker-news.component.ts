import { Component, OnInit } from '@angular/core';
import { HackerNewsService } from '../services/hacker-news.service';
import { IStory } from '../models/IStory';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-hacker-news',
  templateUrl: './hacker-news.component.html',
  styleUrls: ['./hacker-news.component.css'],
})
export class HackerNewsComponent implements OnInit {
  newStories$: IStory[];

  constructor(private hackerNewsService: HackerNewsService) {
  }

  ngOnInit() {
    this.loadStories();
    this.get('');
  }

  loadStories() {
    // this.newStories$ = this.hackerNewsService.getNewStories();
    this.hackerNewsService.getNewStories();
  }

  search(event: KeyboardEvent) {
    this.get((event.target as HTMLTextAreaElement).value);
  }

  get(searchTerm: string) {
     // searchTerm = 'aws'; // todo : remove
      // console.log('calling get ', searchTerm);
      this.hackerNewsService.getStories('aws').subscribe(
        result => {
          console.log(result);
          this.newStories$ = result;
        },
        error => console.error(error)
      );



    // this.http
    //   .get<HackerNewsStory[]>(
    //     `${this.baseUrl}hackernews?searchTerm=${searchTerm}`
    //   )
    //   .subscribe(
    //     result => {
    //       this.hackerNewsStories = result;
    //     },
    //     error => console.error(error)
    //   );



  }

  open(url: string) {
    window.open(url, '_blank');
  }
}
