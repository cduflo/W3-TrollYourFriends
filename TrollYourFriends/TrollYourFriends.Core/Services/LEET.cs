using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrollYourFriends.Core.Services
{
    public class LEET
    {
        public static string LEETFY(string x)
        {
            string responseText;
            var input = HTTPify(x);
            WebRequest request = WebRequest.Create($"https://montanaflynn-l33t-sp34k.p.mashape.com/encode?text={input}");
            request.Headers.Add("X-Mashape-Key", "WejfcnPh8amshirrN3TzKEK4rnXVp1fknqmjsnFk38OOLZ6DA3");
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
            }
            return responseText;
        }

        public static string HTTPify(string x)
        {
            var split = x.Split(' ');
            var input = split[0];
            for (var i = 1; i < split.Length; i++)
            {
                input += "+" + split[i];
            }
            return input;
        }
    }
}
