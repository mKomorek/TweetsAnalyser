using Tweetinvi;

namespace TweetsAnalyser.Model
{   
    class TwitterUserModel
    {
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;

        public TwitterUserModel()
        {
            // may be changed, add some safe stuff
            Auth.SetUserCredentials("AzwaBl0U35AgAX9jJ83xigP2M", "Fs2ghuwr2OSqzmOgmZyLblXOx1B0hw06k1yrEjtNALW5Z5tCry", 
                "1247976477238362118-XXr2crv5aO9bjLaaC82IIiu5CF5UGC", "Zu5kS8MhAowOudyBmbym1HFHyqQJUvyDLmTpGKzpJ36KN");
            _twitterUser = User.GetAuthenticatedUser();
            TweetService = new TweetServiceModel(_twitterUser);
        }

        public string ProfileName
        {
            get { return _twitterUser.Name; }
        } 

        public string ProfileImageURL
        {
            get { return _twitterUser.ProfileImageUrl; }
        }

        public TweetServiceModel TweetService { get; }
    }
}
