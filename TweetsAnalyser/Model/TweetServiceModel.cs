using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace TwitterTests.Model
{
    class TweetServiceModel
    {
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;
        private List<TweetAppModel> _tweets;

        public TweetServiceModel(Tweetinvi.Models.IAuthenticatedUser twitterUser)
        {
            _twitterUser = twitterUser;
            _tweets = new List<TweetAppModel>();
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
                _tweets.Add(new TweetAppModel(tweet.CreatedBy, tweet.CreatedAt, tweet.FullText));
            }
        }

        public List<TweetAppModel> Tweets
        {
            get { return _tweets; }
        }
    }
}
