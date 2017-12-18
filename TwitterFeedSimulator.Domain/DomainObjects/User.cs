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
        public IList<string> UniqueUsers { get; set; } 
        public User()
        {
            UserDetails = new List<UserDetail>();
            UniqueUsers = new List<string>();
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

            UniqueUsers = GetDistinctUsers(userList);
            SetUserAndFollowing(userList);
        }

        private static IList<string> GetDistinctUsers(string[] users)
        {
            IList<string> commaSeperatedString = new List<string>();

            var usersInFile = (from user in users
                               where !users.Contains(user.Trim())
                               select user.Trim()).ToList().Distinct().ToList();

            //handle comma seperated names
            foreach (var item in usersInFile.Where(item => item.Contains(',')))
            {
                commaSeperatedString = SplitCommaString(item);
            }
            usersInFile.RemoveAll(x => x.Contains((',')));

            var distinctUsers = usersInFile.Union(commaSeperatedString)
                                            .Distinct()
                                            .ToList();
            return distinctUsers;
        }

        private void SetUserAndFollowing(IList<string> users)
        {
            var index = 0;
            foreach (var user in UniqueUsers)
            {
                UserDetails.Add(new UserDetail()
                {
                    User = user.Trim(),
                    Following = SplitCommaString(users[index + 1].Trim())
                });
                index++;
            }
        }

        private static IList<string> SplitCommaString(string commaString)
        {
            var resultData = commaString.Split(',');

            var result = resultData.Select(item => item.Trim()).ToList();

            return result;
        }

    }
}
