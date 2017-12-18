using System;
using System.Collections.Generic;
using System.Linq;
using TwitterFeedSimulator.Domain.DomainData;

namespace TwitterFeedSimulator.Domain.DomainObjects
{
    public class User
    {
        public string UserFileContent { get; private set; }

        public List<UserDetail> UserDetails{ get; private set; }
        public UserTweetFileIo File { get; private set; }
        
        public User()
        {
            UserDetails = new List<UserDetail>();
            UserFileContent = string.Empty;
            File = new UserTweetFileIo();

            SetupUser();
        }

        public List<UserDetail> GetUsers()
        {
            return UserDetails;
        }

        public void SetupUser()
        {
            GetUserFileContent();
            BuildUserList();
        }

        private void GetUserFileContent()
        {
            UserFileContent = File.GetUserFileContent();
        }

        private void BuildUserList()
        {
            var data = UserFileContent.Replace("follows", ">");
            var userList = data.Split(new[] {">", "\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            SetUserAndFollowing(userList);
        }

        private void SetUserAndFollowing(IList<string> users)
        {
            var index = 0;
            while (index < users.Count)
            {
                UserDetails.Add(new UserDetail()
                {
                    User = users[index].Trim(),
                    Following = GetFollowers(users[index + 1].Trim())
                });

                index += 2;
            }
        }

        private static IList<string> GetFollowers(string followerString)
        {
            var followerData = followerString.Split(',');

            return followerData.ToList();
        }

    }
}
