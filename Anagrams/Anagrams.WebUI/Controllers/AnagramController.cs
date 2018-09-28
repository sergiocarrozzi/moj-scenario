using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anagrams.WebUI.Controllers
{
    public class AnagramController : Controller
    {
        private Business.AnagramsBusiness anagramsBusiness;

        public AnagramController(Business.AnagramsBusiness anagramsBusiness)
        {
            this.anagramsBusiness = anagramsBusiness;
        }

        // GET: Anagram
        public ActionResult Index(string words)
        {
            string[] wordsArray = words.Split(',');
            Dictionary<String, List<String>> results = new Dictionary<string, List<string>>();
            foreach (var word in wordsArray)
            {
                List<String> anagrams = this.anagramsBusiness.GetAnagrams(word);
                results.Add(word, anagrams);
            }
            //return Json(results, JsonRequestBehavior.AllowGet);
            var jsonResult = Json(results, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}