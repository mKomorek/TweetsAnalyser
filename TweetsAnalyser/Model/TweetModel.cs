using System;

namespace TweetsAnalyser.Model
{
    public class TweetModel
    {
        public TweetModel() { }
        public TweetModel(Tweetinvi.Models.IUser tweetAuthor, DateTime tweetPublishedDate, string tweetFullText)
        {
            TweetAuthor = tweetAuthor;
            TweetPublishedDate = tweetPublishedDate;
            TweetFullString = tweetFullText;
            TweetAuthorImageURL = TweetAuthor.ProfileImageUrl;
        }

        public int Id { get; set; }

        public Tweetinvi.Models.IUser TweetAuthor { get; set; }

        public DateTime TweetPublishedDate { get; set; }

        public string TweetFullString { get; set; }

        public string TweetAuthorImageURL { get; set; }
    }
}
