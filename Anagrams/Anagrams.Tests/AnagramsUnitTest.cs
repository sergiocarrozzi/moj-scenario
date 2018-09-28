using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace Anagrams.Tests
{
    [TestClass]
    public class AnagramsUnitTest
    {
        /// <summary>
        /// url for requesting an anagram
        /// </summary>
        private string url = "http://localhost:51906/Anagram";

        [TestMethod]
        public void IsAnagramsAlgorithmWorksCorrectly()
        {
            string urlWithParameters = $"{url}?words=crepitus";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            
        }
    }
}
