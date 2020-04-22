using System.Collections.Generic;
using Tweetinvi;
using System.Collections.ObjectModel;

namespace TweetsAnalyser.Model
{
    class TweetServiceModel
    {
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;

        public TweetServiceModel(Tweetinvi.Models.IAuthenticatedUser twitterUser)
        {
            _twitterUser = twitterUser;
            Tweets = new ObservableCollection<TweetModel>();
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
            Tweets.Clear();
            foreach (var tweet in tweets)
            {
                Tweets.Add(new TweetModel(tweet.CreatedBy, tweet.CreatedAt, tweet.FullText));
            }
        }

        public ObservableCollection<TweetModel> Tweets { get; }
    }
}
