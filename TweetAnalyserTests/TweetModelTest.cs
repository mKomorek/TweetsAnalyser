using NUnit.Framework;
using System;
using TweetsAnalyser.Model;

namespace TweetAnalyserTests
{
    public class TweetModelTests
    {
        private TweetModel _tweetModel;

        [SetUp]
        public void Setup()
        {
            _tweetModel = new TweetModel();
            _tweetModel.TweetPublishedDate = DateTime.Today;
            _tweetModel.TweetFullString = "test";
            _tweetModel.TweetAuthorImageURL = "https://test.png";
        }

        [Test]
        public void TweetPublishedDate_getter_test()
        {
            Assert.AreEqual(DateTime.Today, _tweetModel.TweetPublishedDate);
        }

        [Test]
        public void TweetFullString_getter_test()
        {
            Assert.AreEqual("test", _tweetModel.TweetFullString);
        }

        [Test]
        public void TweetAuthorImageURl_getter_test()
        {
            Assert.AreEqual("https://test.png", _tweetModel.TweetAuthorImageURL);
        }
    }
}