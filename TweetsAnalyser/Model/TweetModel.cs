using System;

namespace TweetsAnalyser.Model
{
    /// <summary>
    /// A class that supports a single tweet.
    /// </summary>
    public class TweetModel
    {
        /// <summary>
        /// Nonparametric constructor.
        /// </summary>
        public TweetModel() { }

        /// <summary>
        /// The parametric constructor initializes components with the values given as function arguments.
        /// </summary>
        /// <param name="tweetAuthor"></param>
        /// <param name="tweetPublishedDate"></param>
        /// <param name="tweetFullText"></param>
        public TweetModel(Tweetinvi.Models.IUser tweetAuthor, DateTime tweetPublishedDate, string tweetFullText)
        {
            TweetAuthor = tweetAuthor;
            TweetPublishedDate = tweetPublishedDate;
            TweetFullString = tweetFullText;
            TweetAuthorImageURL = TweetAuthor.ProfileImageUrl;
        }

        /// <summary>
        /// Tweet ID getter and setter.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tweet author getter and setter.
        /// </summary>
        public Tweetinvi.Models.IUser TweetAuthor { get; set; }

        /// <summary>
        /// Tweet published date getter and setter.
        /// </summary>
        public DateTime TweetPublishedDate { get; set; }

        /// <summary>
        /// Tweet full text getter and setter.
        /// </summary>
        public string TweetFullString { get; set; }

        /// <summary>
        /// Tweet author image URL getter and setter.
        /// </summary>
        public string TweetAuthorImageURL { get; set; }
    }
}
