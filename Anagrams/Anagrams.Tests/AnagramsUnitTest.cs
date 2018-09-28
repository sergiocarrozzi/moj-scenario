using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Anagrams.Tests
{
    [TestClass]
    public class AnagramsUnitTest
    {
        /// <summary>
        /// url for requesting an anagram
        /// </summary>
        private string url = "http://localhost:51906/Anagram/Index";

        [TestMethod]
        public void IsAnagramsAlgorithmWorksCorrectlyWithOneWord()
        {
            string urlWithParameters = $"{url}?words=crepitus";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
            
            // assert
            Assert.AreEqual(rawJson, "{\"crepitus\":[\"cuprites\",\"pictures\",\"piecrust\"]}");
            //{"crepitus":["cuprites","pictures","piecrust"]}
        }

        [TestMethod]
        public void IsAnagramsAlgorithmWorksCorrectlyWithMoreWords()
        {
            string urlWithParameters = $"{url}?words=crepitus,paste,kinship,enlist,boaster,fresher,sinks,knits,sort";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // assert
            Assert.AreEqual(rawJson, "{\"crepitus\":[\"cuprites\",\"pictures\",\"piecrust\"],\"paste\":[\"pates\",\"peats\",\"septa\",\"spate\",\"tapes\",\"tepas\"],\"kinship\":[\"pinkish\"],\"enlist\":[\"elints\",\"inlets\",\"listen\",\"silent\",\"tinsel\"],\"boaster\":[\"boaters\",\"borates\",\"rebatos\",\"sorbate\"],\"fresher\":[\"refresh\"],\"sinks\":[\"skins\"],\"knits\":[\"skint\",\"stink\",\"tinks\"],\"sort\":[\"orts\",\"rots\",\"stor\",\"tors\"]}");
        }

        [TestMethod]
        public void IsAnagramsAlgorithmWorksCorrectlyWithBadWord()
        {
            string urlWithParameters = $"{url}?words=sdfwehrtgegfg";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // assert
            Assert.AreEqual(rawJson, "{\"sdfwehrtgegfg\":[]");
            //{"crepitus":["cuprites","pictures","piecrust"]}
        }

    }
}
