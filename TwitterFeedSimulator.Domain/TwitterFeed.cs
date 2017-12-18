using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterFeedSimulator.Domain.DomainObjects;

namespace TwitterFeedSimulator.Domain
{
    public class TwitterFeed
    {
        public User User { get; set; }
        public Tweet Tweet { get; set; }

        public TwitterFeed()
        {
            User = new User();
            Tweet = new Tweet();
        }

        public string SimulateFeed()
        {
            var sb = new StringBuilder();
            foreach (var user in User.UserDetails.OrderBy(i => i.User))
            {
                sb.AppendLine(user.User);
                foreach (var tweet in Tweet.TweetDetails)
                {
                    string messages;
                    if (user.Following.Contains(tweet.User))
                    {
                        messages = string.Format("@{0}: {1}", tweet.User, tweet.TweetMessage);
                        sb.AppendLine(messages);
                    }
                    else if (string.Equals(user.User, tweet.User))
                    {
                        messages = string.Format("@{0}: {1}", user.User, tweet.TweetMessage);
                        sb.AppendLine(messages);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
