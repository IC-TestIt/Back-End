using System.Collections.Generic;
using System.Text.RegularExpressions;
using Fastenshtein;
using System.Linq;
using Annytab.Stemmer;
using TestIt.Utils.Extend;

namespace TestIt.CorrectionAlgorithms
{
    public static class Core
    {
        public static IEnumerable<string> SeparateIntoSentences(string text)
        {
           var sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
            
           return sentences;
        }

        public static int TextDif(string text1, string text2)
        {
            return Levenshtein.Distance(text1, text2);
        }

        public static string NormalizeText(string text)
        {
            var stemmer = new PortugueseStemmer();

            var steamWord = stemmer.GetSteamWord(text);

            return steamWord;
        }

        public static int KeyWordMatcher(string baseText, List<string> keywords)
        {
            return baseText.Count(keywords);
        }
        
        public static IEnumerable<string> StemWords(string[] words)
        {
            var stemmer = new PortugueseStemmer();

            var steamWords = stemmer.GetSteamWords(words);

            return steamWords;
        }
    }
}
