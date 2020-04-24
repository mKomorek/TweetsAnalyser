using System.Collections.ObjectModel;

namespace TweetsAnalyser.Model
{
    /// <summary>
    /// The class enables database management.
    /// </summary>
    class DataBaseServiceModel
    {
        private DataBaseModel _dataBaseModel;

        /// <summary>
        /// A constructor who creates a new dbcontext to support the database.
        /// </summary>
        public DataBaseServiceModel() => _dataBaseModel = new DataBaseModel();

        /// <summary>
        /// Adds the elements given as an argument to the database.
        /// </summary>
        /// <param name="tweet"></param>
        public void add(TweetModel tweet)
        {
            _dataBaseModel.FavoriteTweets.Add(tweet);
            _dataBaseModel.SaveChanges();
        }

        /// <summary>
        /// Removes the element supplied as an argument from the database.
        /// </summary>
        /// <param name="tweet"></param>
        public void remove(TweetModel tweet)
        {
            _dataBaseModel.FavoriteTweets.Remove(tweet);
            _dataBaseModel.SaveChanges();
        }

        /// <summary>
        /// Removes all items from the database.
        /// </summary>
        public void clear()
        {
            _dataBaseModel.FavoriteTweets.RemoveRange(_dataBaseModel.FavoriteTweets);
        }

        /// <summary>
        /// Retrieves all saved tweets from the database and returns a collection of objects
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<TweetModel> getAllFavoriteTweets()
        {
            ObservableCollection<TweetModel> tweets = new ObservableCollection<TweetModel>();
            foreach(var tweet in _dataBaseModel.FavoriteTweets)
            {
                tweets.Add(tweet);
            }
            return tweets;
        }
    }
}
