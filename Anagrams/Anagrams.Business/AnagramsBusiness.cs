using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anagrams.Entity.Abstract;

namespace Anagrams.Business
{
    public class AnagramsBusiness
    {
        private IAnagramsRepository repository;

        public AnagramsBusiness(IAnagramsRepository repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// checks the anagrams of the given word
        /// </summary>
        /// <param name="word"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        public List<String> GetAnagrams(string word)
        {
            // clean the word from unwanted charatcters
            String wordToBeChecked = CleanWord(word);
            // order the word alphabetically
            wordToBeChecked = wordToBeChecked.ToLower().OrderBy(c => c).ToString();

            // get the repository
            List<String> wordlist = this.repository.Wordlist;

            // check the repository ordering the values alphabetically
            return wordlist.Where(c => c.OrderBy(wo => wo).ToString() == wordToBeChecked).ToList();
        }

        /// <summary>
        /// clean the word from special characters
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string CleanWord(string word)
        {
            return word.Replace("'", "");
        }
    }
}
