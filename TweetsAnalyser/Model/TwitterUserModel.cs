using Tweetinvi;

namespace TweetsAnalyser.Model
{   
    /// <summary>
    /// A class that supports a twitter user.
    /// </summary>
    class TwitterUserModel
    {
        private Tweetinvi.Models.IAuthenticatedUser _twitterUser;
	
        /// <summary>
        /// Nonparametric constructor. Performs user authentication.
	/// Create instance of user and instance og TweetServiceModel.
        /// </summary>
        public TwitterUserModel()
        {
            Auth.SetUserCredentials("AzwaBl0U35AgAX9jJ83xigP2M", "Fs2ghuwr2OSqzmOgmZyLblXOx1B0hw06k1yrEjtNALW5Z5tCry", 
                "1247976477238362118-XXr2crv5aO9bjLaaC82IIiu5CF5UGC", "Zu5kS8MhAowOudyBmbym1HFHyqQJUvyDLmTpGKzpJ36KN");
            _twitterUser = User.GetAuthenticatedUser();
            TweetService = new TweetServiceModel(_twitterUser);
        }
	
	/// <summary>
        /// Profile name getter, return user profile name.
        /// </summary>
        public string ProfileName
        {
            get { return _twitterUser.Name; }
        } 
	
	/// <summary>
        /// Profile image URL getter, return user profile image URL.
        /// </summary>
        public string ProfileImageURL
        {
            get { return _twitterUser.ProfileImageUrl; }
        }
	
	/// <summary>
        /// TwitterServiceModel getter, return TwitterServiceModel instance.
        /// </summary>
        public TweetServiceModel TweetService { get; }
    }
}
