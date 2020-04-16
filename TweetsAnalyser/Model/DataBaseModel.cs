using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace TwitterTests.Model
{
    class DataBaseModel : DbContext
    {
        public DbSet<TweetModel> FavoriteTweets { get; set; }
    }
}
