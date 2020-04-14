using System;
using TwitterTests.Model;

namespace TwitterTests
{
    class Program
    {
        static void Run(string[] args)
        {
            TwitterUserModel m_twitterUser = new TwitterUserModel();

            Console.WriteLine("Hello World!");
            Console.WriteLine(m_twitterUser.ProfileName);
            Console.WriteLine(m_twitterUser.ProfileImageURL);

            foreach(var tweet in m_twitterUser.Tweets)
            {
                Console.WriteLine("TWEET ---- ");
                Console.WriteLine(tweet.TweetAuthor);
                Console.WriteLine(tweet.TweetPublishedDate);
                Console.WriteLine(tweet.TweetFullString);
                Console.WriteLine("");
            }
        }
    }
}
