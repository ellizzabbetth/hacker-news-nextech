
using System;
// using Microsoft.EntityFrameworkCore;   // ??
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;


using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using hacker_news_nextech.Model;

namespace hacker_news_nextech.Repsoitory
{
    public class HackerNewsRepository: IHackerNewsRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HackerNewsRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> GetNewStoriesAsync()
        {
  
            var client =  _httpClientFactory.CreateClient();
            return await client.GetAsync("https://hacker-news.firebaseio.com/v0/newstories.json");

        }

        public Task<Story> GetStoryAsync(int id)
        {
            throw new NotImplementedException();
        }

       // TODO remove
        public async Task<HttpResponseMessage> BestStoriesAsync()
        {
            
            var client =  _httpClientFactory.CreateClient();
            return await client.GetAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
        }

        
       // TODO remove
        public async Task<HttpResponseMessage> GetStoryByIdAsync(int id)
        {            
            var client =  _httpClientFactory.CreateClient();
            return await client.GetAsync(string.Format("https://hacker-news.firebaseio.com/v0/item/{0}.json", id));
        }

        public Task<List<Story>> GetStoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}