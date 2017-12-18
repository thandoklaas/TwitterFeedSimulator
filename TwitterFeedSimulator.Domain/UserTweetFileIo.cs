using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace TwitterFeedSimulator.Domain
{
    public class UserTweetFileIo
    {
        public string FilePath { get; private set; }

        public UserTweetFileIo()
        {
            FilePath =  ConfigurationManager.AppSettings["TextFilePath"];
        }

        public string ReadFile(string fileName)
        {
            const Int32 bufferSize = 128;
            using (var fileStream = File.OpenRead(string.Format("{0}{1}", FilePath, fileName)))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
            {
                var line = string.Empty;
                while (!streamReader.EndOfStream)
                {
                    line += streamReader.ReadLine() + Environment.NewLine;
                }
                return line;
            }
        }

        public string ReadUserFile()
        {
            var file = new UserTweetFileIo();
            return file.ReadFile("user.txt");
        }

        public string ReadTweetFile()
        {
            var file = new UserTweetFileIo();
            return file.ReadFile("tweet.txt");
        }

        public string GetUserFileContent()
        {
            return ReadUserFile();
        }

        public string GetTweetFileContent()
        {
            return ReadTweetFile();
        }
    }
}
