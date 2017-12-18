using System.Collections.Generic;

namespace TwitterFeedSimulator.Domain.DomainData
{
    public class UserDetail
    {
        public string User { get; set; }
        public IList<string> Following { get; set; }

        public UserDetail()
        {
            User = string.Empty;
            Following = new List<string>();
        }
    }
}
