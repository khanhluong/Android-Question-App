using System;
using System.Threading.Tasks;
using Common.Model;
using Refit;

namespace Common.Interface
{
    [Headers("User-Agent: :request:")]
    public interface IRedditApi
    {
        [Get("/subreddits/search.json?q={keyword}")]
        Task<SubRedditResponse> GetSubReddit([AliasAs("keyword")] string keyword);
    }
}
