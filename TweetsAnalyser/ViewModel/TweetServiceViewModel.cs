﻿using TwitterTests.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;


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
            twitterUser.TweetService.setUserTimeLineTweets("StackOverflow");
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

        public ObservableCollection<TweetModel> TwitterUser_TweetService_Tweets
        {
            get { return twitterUser.TweetService.Tweets; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
