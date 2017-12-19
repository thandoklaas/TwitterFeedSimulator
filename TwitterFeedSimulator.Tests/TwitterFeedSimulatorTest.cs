using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterFeedSimulator.Domain;
using TwitterFeedSimulator.Domain.DomainObjects;

namespace TwitterFeedSimulator.Tests
{
    [TestClass]
    public class TwitterFeedSimulatorTest
    {
        private readonly UserTweetFileIo  file = new UserTweetFileIo();
        [TestMethod]
        public void CanReadFile()
        {

            var userFile = file.ReadFile("user.txt");
            var tweetFile = file.ReadFile("tweet.txt");

            Assert.IsNotNull(userFile);
            Assert.IsNotNull(tweetFile);
        }

        [TestMethod]
        public void CanReadUserFile()
        {
            var result = file.ReadUserFile();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanReadTweetFile()
        {
            var result = file.ReadTweetFile();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanGetUser()
        {
            var user = new User();
            var users = user.GetUsers();

            Assert.IsNotNull(users);
        }
        [TestMethod]
        public void CanGetTweet()
        {
            var tweet = new Tweet();
            var users = tweet.GetTweets();

            Assert.IsNotNull(users);
        }
        [TestMethod]
        public void CanSetupUser()
        {
            var user = new User();
            user.SetupUser();

            Assert.IsNotNull(user.UserDetails);
        }

        [TestMethod]
        public void CanSetupTweet()
        {
            var tweet = new Tweet();
            tweet.SetupTweet();


            Assert.IsNotNull(tweet.TweetDetails);
        }

        [TestMethod]
        public void CanSimulateFeed()
        {
            var feed  = new TwitterFeed();
            Assert.AreNotEqual(feed.SimulateFeed(), string.Empty);
        }

        [TestMethod]
        public void UsersCreated()
        {
            var user = new User();
            Assert.IsTrue(user.UserDetails.Any(x => !string.IsNullOrWhiteSpace(x.User)));
        }
        [TestMethod]
        public void UserFollowingCreated()
        {
            var user = new User();
            Assert.IsTrue(user.UserDetails.Any(x => x.Following != null && x.Following.Any()));
        }
        [TestMethod]
        public void TweetUsersCreated()
        {
            var tweet = new Tweet();
            Assert.IsTrue(tweet.TweetDetails.Any(x => !string.IsNullOrWhiteSpace(x.User)));
        }
        [TestMethod]
        public void TweetMessagesCreated()
        {
            var tweet = new Tweet();
            Assert.IsTrue(tweet.TweetDetails.Any(x=> !string.IsNullOrWhiteSpace(x.TweetMessage)));
        }
        [TestMethod]
        public void TweetMessagesLessThan140Characters()
        {
            var tweet = new Tweet();
            Assert.IsFalse(tweet.TweetDetails.Any(x => x.TweetMessage.Count() > 140));
        }
    }
}
