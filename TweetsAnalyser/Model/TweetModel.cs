﻿using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace TwitterTests.Model
{
    public class TweetModel
    {
        private Tweetinvi.Models.IUser _tweetAuthor;
        private DateTime _tweetPublishedDate;
        private string _tweetFullText;

        public TweetModel() { }
        public TweetModel(Tweetinvi.Models.IUser tweetAuthor, DateTime tweetPublishedDate, string tweetFullText)
        {
            _tweetAuthor = tweetAuthor;
            _tweetPublishedDate = tweetPublishedDate;
            _tweetFullText = tweetFullText;
        }

        public int Id { get; set; }

        public Tweetinvi.Models.IUser TweetAuthor
        {
            get { return _tweetAuthor; }
            set { _tweetAuthor = value;  }
        }

        public DateTime TweetPublishedDate
        {
            get { return _tweetPublishedDate; }
            set { _tweetPublishedDate = value; }
        }

        public string TweetFullString
        {
            get { return _tweetFullText; }
            set { _tweetFullText = value;  }
        }
    }
}