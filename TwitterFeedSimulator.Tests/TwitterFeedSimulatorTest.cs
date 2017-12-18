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
    }
}
