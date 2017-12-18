namespace TwitterFeedSimulator.Domain.DomainData
{
    public class TweetDetail
    {
        public string User { get;  set; }
        public string TweetMessage { get; set; }

        public TweetDetail()
        {
            User = string.Empty;
            TweetMessage = string.Empty;
        }

    }
}