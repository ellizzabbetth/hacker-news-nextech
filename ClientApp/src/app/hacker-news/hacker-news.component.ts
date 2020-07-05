import { Component, OnInit } from '@angular/core';
import { HackerNewsService } from '../services/hacker-news.service';
import { IStory } from '../models/IStory';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-hacker-news',
  templateUrl: './hacker-news.component.html',
  styleUrls: ['./hacker-news.component.css']
})
export class HackerNewsComponent implements OnInit {
  newStories$: Observable<IStory[]>;

  constructor(    private hackerNewsService: HackerNewsService) { }

  ngOnInit() {
    this.loadStories();
  }

  loadStories() {
   // this.newStories$ = this.hackerNewsService.getNewStories();
   this.hackerNewsService.getNewStories();
  }

}
