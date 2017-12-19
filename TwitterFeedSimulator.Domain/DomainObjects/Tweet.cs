using System;
using System.Collections.Generic;
using TwitterFeedSimulator.Domain.DomainData;

namespace TwitterFeedSimulator.Domain.DomainObjects
{
    public class Tweet
    {
        public string TweetFileContent { get; private set; }

        public IList<TweetDetail> TweetDetails { get; private set; }
        public UserTweetFileIo File { get; private set; }

        public Tweet()
        {
            TweetDetails = new List<TweetDetail>();
            File = new UserTweetFileIo();

            SetupTweet();
        }

        public IList<TweetDetail> GetTweets()
        {
            return TweetDetails;
        }

        private void BuildTweetList()
        {
            var tweetList = TweetFileContent.Split(new[] {">", "\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            SetTweetPerUser(tweetList);

        }

        public void SetupTweet()
        {
            GetUserFileContent();

            BuildTweetList();
        }

        private void SetTweetPerUser(IList<string> tweets)
        {
            var index = 0;
            while (index < tweets.Count)
            {
                TweetDetails.Add(new TweetDetail()
                {
                    User = tweets[index].Trim(),
                    TweetMessage = tweets[index + 1]
                });

                index += 2;
            }
        }

        private void GetUserFileContent()
        {
            TweetFileContent = File.GetTweetFileContent();
        }
    }
}
