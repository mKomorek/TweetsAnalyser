﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TwitterTests.Model
{
    class DataBaseServiceModel
    {
        private DataBaseModel _dataBaseModel;

        public DataBaseServiceModel() => _dataBaseModel = new DataBaseModel();

        public void add(TweetModel tweet)
        {
            _dataBaseModel.FavoriteTweets.Add(tweet);
            _dataBaseModel.SaveChanges();
        }

        public void remove(TweetModel tweet)
        {
            _dataBaseModel.FavoriteTweets.Remove(tweet);
            _dataBaseModel.SaveChanges();
        }

        public void clear()
        {
            _dataBaseModel.FavoriteTweets.RemoveRange(_dataBaseModel.FavoriteTweets);
        }

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
