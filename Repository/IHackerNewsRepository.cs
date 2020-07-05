using System.Net.Http;
using System.Threading.Tasks;
using hacker_news_nextech.Model;

namespace hacker_news_nextech.Repository
{
    public interface IHackerNewsRepository
    {
        Task<HttpResponseMessage> GetNewStoriesAsync();
       // Task<List<Story>> GetStoriesAsync();
       // Task<PagingResult<Customer>> GetCustomersPageAsync(int skip, int take);
        Task<Story> GetStoryAsync(int id);
        // TODO remove
        Task<HttpResponseMessage> BestStoriesAsync();
        //TODO remove
        Task<HttpResponseMessage> GetStoryByIdAsync(int id);
    }
}