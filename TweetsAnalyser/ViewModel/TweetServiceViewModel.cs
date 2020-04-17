using TwitterTests.Model;
using System.ComponentModel;


namespace TwitterTests.ViewModel
{
    class TweetServiceViewModel : INotifyPropertyChanged
    {
        public TwitterUserModel twitterUser;
        public DataBaseServiceModel dataBaseService;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public TweetServiceViewModel()
        {
            twitterUser = new TwitterUserModel();
            dataBaseService = new DataBaseServiceModel();
        }
        
        public string TwitterUser_ProfileName
        {
            get { return twitterUser.ProfileName; }
        }
        public string TwitterUser_ProfileImage_URL
        {
            get { return twitterUser.ProfileImageURL; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
