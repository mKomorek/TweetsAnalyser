using System.Data.Entity;

namespace TweetsAnalyser.Model
{
    /// <summary>
    /// The class creates a db context to support the database.
    /// </summary>
    class DataBaseModel : DbContext
    {
        public DbSet<TweetModel> FavoriteTweets { get; set; }
    }
}
