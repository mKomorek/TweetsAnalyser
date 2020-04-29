using System.Collections.Generic;
using Tweetinvi;
using System.Collections.ObjectModel;

namespace TweetsAnalyser.Model
{
    /// <summary>
    /// A class that supports tweet management.
    /// </summary>
    public class TweetServiceModel
    {
        /// <summary>
        /// A private object that stores information about the currently logged in user
        /// </summary>
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;

        /// <summary>
        /// The parametric constructor initializes components with the values given as 
        /// function arguments and create object that contain tweets.
        /// </summary>
        /// <param name="twitterUser"></param>
        public TweetServiceModel(Tweetinvi.Models.IAuthenticatedUser twitterUser)
        {
            _twitterUser = twitterUser;
            Tweets = new ObservableCollection<TweetModel>();
        }

        /// <summary>
        /// The method retrieves 30 last tweets from the logged-in user's table from twitter 
        /// Twitter service and assigns them to a private class variable.
        /// </summary>
        public void setHomeTimeLineTweets()
        {
            var homeLineTweets = _twitterUser.GetHomeTimeline(30);
            setTweetList(homeLineTweets);
        }

        /// <summary>
        /// The method retrieves the last 30 tweets from the profile specified in the function 
        /// argument and assigns them to a private class variable.
        /// </summary>
        /// <param name="userName"></param>
        public void setUserTimeLineTweets(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var userLineTweets = Timeline.GetUserTimeline(user);
            setTweetList(userLineTweets);
        }

        /// <summary>
        /// the method adds to the private variable of the class all elements included in the 
        /// list given as the function argument.
        /// </summary>
        /// <param name="tweets"></param>
        private void setTweetList(IEnumerable<Tweetinvi.Models.ITweet> tweets)
        {
            Tweets.Clear();
            foreach (var tweet in tweets)
            {
                Tweets.Add(new TweetModel(tweet.CreatedBy, tweet.CreatedAt, tweet.FullText));
            }
        }

        /// <summary>
        /// Returns a list of tweets
        /// </summary>
        public ObservableCollection<TweetModel> Tweets { get; }
    }
}
