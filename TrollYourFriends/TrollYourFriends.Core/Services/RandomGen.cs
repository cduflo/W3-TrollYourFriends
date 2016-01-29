using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;
using TrollYourFriends.Core.Domain;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TrollYourFriends.Core.Services
{
    public class RandomGen
    {

        public static  RandomResponse RandomChuck()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString($"http://api.icndb.com/jokes/random");
                var result = JsonConvert.DeserializeObject<RandomResponse>(json);
                return result;
            }

        }
    }
}
