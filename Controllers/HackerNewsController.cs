using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hacker_news_nextech.Model;
using hacker_news_nextech.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hacker_news_nextech.Controllers
{
  

    [Route("api/[controller]")] 
    public class HackerNewsController : Controller
    {
        private readonly IHackerNewsService _hackerNewsService;
       ILogger _logger;
         public HackerNewsController(IHackerNewsService hackerNewsService)//, ILoggerFactory loggerFactory)
        {
            _hackerNewsService = hackerNewsService;
           // _logger = loggerFactory.CreateLogger(nameof(HackerNewsController));
        }   


        // GET api/hackernews
        [HttpGet]
        //[NoCache]
        //[ProducesResponseType(typeof(List<Story>), 200)]
       // [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> NewStories(string searchTerm)
        {
            try
            {
                var newStories = await _hackerNewsService.GetNewStoriesAsync(searchTerm);
                return Ok(newStories);
            }
            catch (Exception )//ex)
            {
               // _logger.LogError(ex.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/hackernews
    //     [HttpGet]
    //     //[NoCache]
    //     //[ProducesResponseType(typeof(List<Story>), 200)]
    //    // [ProducesResponseType(typeof(ApiResponse), 400)]
    //     public async Task<ActionResult> BestStories()
    //     {
    //         try
    //         {
    //             var bestStories = await _hackerNewsService.BestStoriesAsync();
    //             return Ok(bestStories);
    //         }
    //         catch (Exception )//ex)
    //         {
    //            // _logger.LogError(ex.Message);
    //             return BadRequest(new ApiResponse { Status = false });
    //         }
    //     }
  
    }
}