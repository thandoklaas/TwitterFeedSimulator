using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterFeedSimulator.Domain;

namespace TwitterFeedSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            var feed = new TwitterFeed();
            Console.WriteLine("----Twitter feed Simulator-----");
            Console.WriteLine(feed.SimulateFeed());
            Console.WriteLine("----Twitter feed Simulator End-----");
            Console.Read();
        }
    }
}
