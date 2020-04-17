using System;
using TwitterTests.Model;

namespace TwitterTests
{
    class Program
    {
        static void Run(string[] args)
        {
            // Torzenie instancji usera i serwisu dla bazy danych 
            TwitterUserModel twitterUser = new TwitterUserModel();
            DataBaseServiceModel dataBaseService = new DataBaseServiceModel();

            Console.WriteLine(twitterUser.ProfileName);
            Console.WriteLine(twitterUser.ProfileImageURL);

            // Zbiera z twittera ostanie 30 tweetów użytkownia o nazwie którą podasz - nazwa bez '@'! 
            twitterUser.TweetService.setUserTimeLineTweets("StackOverflow");

            // Zbiera z twittera ostatnie 30 tweetów z naszego timelinu 
            //twitterUser.GetTweetService.setHomeTimeLineTweets();

            Console.WriteLine("");
            Console.WriteLine("--------------- TWEETS -----------");
            Console.WriteLine("");
            // twitterUser.TweetService.Tweets zwraca listę obiektów TweetModel (czyli listę tweetów)
            foreach (var tweet in twitterUser.TweetService.Tweets)
            {
                Console.WriteLine("TWEET ---- ");
                Console.WriteLine(tweet.TweetAuthor);
                Console.WriteLine(tweet.TweetPublishedDate);
                Console.WriteLine(tweet.TweetFullString);
                Console.WriteLine("");
            }

            // czyści baze danych
            dataBaseService.clear();

            for (int i = 0; i < 5; ++i)
            {
                // dodaje do bazy danych (jako argument podajesz po prostu instancję obiektu TweetModel)
                dataBaseService.add(twitterUser.TweetService.Tweets[i]);
            }

            // usuwa z bazy (jako argument podajesz po prostu instancję obiektu TweetModel)
            dataBaseService.remove(dataBaseService.getAllFavoriteTweets()[0]);

            Console.WriteLine("");
            Console.WriteLine("--------------- favorite TWEETS -----------");
            Console.WriteLine("");
            // dataBaseService.getAllFavoriteTweets() zwraca listę obiektów TweetModel (czyli listę tweetów) zapisanych w bazie
            foreach (var tweet in dataBaseService.getAllFavoriteTweets())
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
