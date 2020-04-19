using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using System.Collections.ObjectModel;

namespace TwitterTests.Model
{
    class TweetServiceModel
    {
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;
        private ObservableCollection<TweetModel> _tweets;

        public TweetServiceModel(Tweetinvi.Models.IAuthenticatedUser twitterUser)
        {
            _twitterUser = twitterUser;
            _tweets = new ObservableCollection<TweetModel>();
        }

        public void setHomeTimeLineTweets()
        {
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
            _tweets.Clear();
            foreach (var tweet in tweets)
            {
                _tweets.Add(new TweetModel(tweet.CreatedBy, tweet.CreatedAt, tweet.FullText));
            }
        }

        public ObservableCollection<TweetModel> Tweets
        {
            get { return _tweets; }
        }
    }
}
