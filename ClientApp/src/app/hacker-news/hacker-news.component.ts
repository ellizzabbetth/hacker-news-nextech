import { Component, OnInit } from "@angular/core";
import { HackerNewsService } from "../services/hacker-news.service";
import { IStory } from "../models/IStory";
import { Observable } from "rxjs";

@Component({
  selector: "app-hacker-news",
  templateUrl: "./hacker-news.component.html",
  styleUrls: ["./hacker-news.component.css"],
})
export class HackerNewsComponent implements OnInit {
  newStories$: Observable<IStory[]>;

  constructor(private hackerNewsService: HackerNewsService) {}

  ngOnInit() {
    this.loadStories();
  }

  loadStories() {
    // this.newStories$ = this.hackerNewsService.getNewStories();
    this.hackerNewsService.getNewStories();
  }

  search(event: KeyboardEvent) {
    this.get((event.target as HTMLTextAreaElement).value);
  }
  get(searchTerm: string) {
    console.log('calling get ', searchTerm);
    return [
      {
        title:
          "Ask HN: If you plan success, why ever raise equity instead of debt?",
        by: "flibble",
        url: null,
      },
      {
        title:
          "Credentials hiding in plain sight or how I pwned your HTTP auth",
        by: "gehaxelt",
        url:
          "https://0day.work/credentials-hiding-in-plain-sight-or-how-i-pwned-your-http-auth/",
      },
    ];
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
