using Anagrams.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Anagrams.Entity.Concrete
{
    public class TextRepository : IAnagramsRepository
    {
        public List<String> Wordlist
        {
            get
            {
                List<String> listOfWords = new List<string>();
                // read from text file
                var lines = File.ReadLines(HttpContext.Current.Server.MapPath("~/App_Data/wordlist.txt"));
                foreach (var line in lines)
                {
                    listOfWords.Add(line);
                }
                return listOfWords;
            }
        }
    }
}
