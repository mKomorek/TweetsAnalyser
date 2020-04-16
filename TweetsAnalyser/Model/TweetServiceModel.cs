using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace TwitterTests.Model
{
    class TweetServiceModel
    {
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;
        private List<TweetModel> _tweets;

        public TweetServiceModel(Tweetinvi.Models.IAuthenticatedUser twitterUser)
        {
            _twitterUser = twitterUser;
            _tweets = new List<TweetModel>();
        }

        public void setHomeTimeLineTweets()
        {
            _tweets.Clear();
            var homeLineTweets = _twitterUser.GetHomeTimeline(30);
            setTweetList(homeLineTweets);
        }

        public void setUserTimeLineTweets(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            var userLineTweets = Timeline.GetUserTimeline(user);
            setTweetList(userLineTweets);
        }

        private void setTweetList(IEnumerable<Tweetinvi.Models.ITweet> tweets)
        {
            foreach (var tweet in tweets)
            {
                _tweets.Add(new TweetModel(tweet.CreatedBy, tweet.CreatedAt, tweet.FullText));
            }
        }

        public List<TweetModel> Tweets
        {
            get { return _tweets; }
        }
    }
}
