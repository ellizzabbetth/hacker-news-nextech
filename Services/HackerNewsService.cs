using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Microsoft.Extensions.Options;

using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Caching.Memory;
using hacker_news_nextech.Repository;
using hacker_news_nextech.Model;

namespace hacker_news_nextech.Services
{
    public class HackerNewsService : IHackerNewsService
    {   
        private readonly IMemoryCache _cache;
     //   private readonly IHttpClientFactory _httpFactory;
        private readonly IHackerNewsRepository _repository;


        public HackerNewsService(
            IHackerNewsRepository repository,
            IMemoryCache cache) 
        {
            _cache = cache;
            _repository = repository;
        }
        
    // TODO remove
    public async Task<List<Story>> BestStoriesAsync()
    {

        List<Story> stories = new List<Story>();

        var response = await _repository.BestStoriesAsync();
        if (response.IsSuccessStatusCode)
        {
            var storiesResponse = response.Content.ReadAsStringAsync().Result;
            var bestIds = JsonConvert.DeserializeObject<List<int>>(storiesResponse);

            var tasks = bestIds.Select(GetStoryAsync);
            stories = (await Task.WhenAll(tasks)).ToList();


            
            // if (!String.IsNullOrEmpty(searchTerm))
            // {
            //     var search = searchTerm.ToLower();
            //     stories = stories.Where(s =>
            //                        s.Title.ToLower().IndexOf(search) > -1 || s.By.ToLower().IndexOf(search) > -1)
            //                        .ToList();
            // }
        }
        return stories;

    }

    // TODO remove
    private async Task<Story> GetStoryAsync(int storyId)
    {
        return await _cache.GetOrCreateAsync<Story>(storyId,
            async cacheEntry =>
            {
                Story story = new Story();

                var response = await _repository.GetStoryByIdAsync(storyId);
                if (response.IsSuccessStatusCode)
                {
                    var storyResponse = response.Content.ReadAsStringAsync().Result;
                    story = JsonConvert.DeserializeObject<Story>(storyResponse);
                }

                return story;
            });
    }
    public async Task<List<Story>> GetNewStoriesAsync(string searchTerm)
    {
        
        List<Story> stories = new List<Story>();

        var response = await _repository.GetNewStoriesAsync();
        if (response.IsSuccessStatusCode)
        {
            var storiesResponse = response.Content.ReadAsStringAsync().Result;
            var bestIds = JsonConvert.DeserializeObject<List<int>>(storiesResponse);

            var tasks = bestIds.Select(GetStoryAsync);
            stories = (await Task.WhenAll(tasks)).ToList();
            
            if (!String.IsNullOrEmpty(searchTerm))
            {
                var search = searchTerm.ToLower();
                stories = stories.Where(s =>
                                   s.Title.ToLower().IndexOf(search) > -1 || s.By.ToLower().IndexOf(search) > -1)
                                   .ToList();
            }
        }
        return stories;
    }

    public Task<List<Story>> GetStoriesAsync()
    {
        throw new NotImplementedException();
    }



    public Task<HttpResponseMessage> GetStoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

        Task<Story> IHackerNewsService.GetStoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}