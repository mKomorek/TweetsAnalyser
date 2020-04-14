using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace TwitterTests.Model
{   
    class TwitterUserModel
    {
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;
        private string _profileName;
        private string _profileImageURL;
        private List<TweetAppModel> _tweets;

        public TwitterUserModel()
        {
            // may be changed, add some safe stuff
            Auth.SetUserCredentials("AzwaBl0U35AgAX9jJ83xigP2M", "Fs2ghuwr2OSqzmOgmZyLblXOx1B0hw06k1yrEjtNALW5Z5tCry", 
                "1247976477238362118-XXr2crv5aO9bjLaaC82IIiu5CF5UGC", "Zu5kS8MhAowOudyBmbym1HFHyqQJUvyDLmTpGKzpJ36KN");
            setUserProperties();
            _tweets = new List<TweetAppModel>();
            getTweets();
        }

        private void setUserProperties()
        {
            _twitterUser = User.GetAuthenticatedUser();
            _profileName = _twitterUser.Name;
            _profileImageURL = _twitterUser.ProfileImageUrl;
        }

        private void getTweets()
        {
            var getTweets = _twitterUser.GetHomeTimeline(30);
            generateTweetsFromTimeLine(getTweets);
        }

        private void generateTweetsFromTimeLine(IEnumerable<Tweetinvi.Models.ITweet> tweetsTimeline)
        {
            foreach(var tweet in tweetsTimeline)
            {
                _tweets.Add(new TweetAppModel(tweet.CreatedBy, tweet.CreatedAt, tweet.FullText));
            }
        }

        public string ProfileName
        {
            get { return _profileName; }
            set { _profileName = value; }
        }

        public string ProfileImageURL
        {
            get { return _profileImageURL; }
            set { _profileImageURL = value; }
        }

        public List<TweetAppModel> Tweets
        {
            get { return _tweets; }
            set { }
        }
    }
}
