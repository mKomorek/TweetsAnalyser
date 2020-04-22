using System.Data.Entity;

namespace TweetsAnalyser.Model
{
    class DataBaseModel : DbContext
    {
        public DbSet<TweetModel> FavoriteTweets { get; set; }
    }
}
