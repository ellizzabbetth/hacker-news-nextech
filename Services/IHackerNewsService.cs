using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using hacker_news_nextech.Model;

namespace hacker_news_nextech.Services
{
    public interface IHackerNewsService
    {
       Task<List<Story>> GetNewStoriesAsync(string searchTerm);
        Task<List<Story>> GetStoriesAsync();
       // Task<PagingResult<Customer>> GetCustomersPageAsync(int skip, int take);
        Task<Story> GetStoryAsync(int id);
        // TODO remove
        Task<List<Story>> BestStoriesAsync();
        //TODO remove
        Task<HttpResponseMessage> GetStoryByIdAsync(int id);
    }
}