using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutationsComparison
{
    class Program
    {

        static void Main(string[] args)

        {
            List<string> deneme = new List<string>();
            List<string> deneme2 = new List<string>();
            List<string> deneme3 = new List<string>();

            string word = "hafizenur";
            string word2 = "nur";
            string word3 = "xbx";

            deneme = StringPermutationsList(word);
            deneme2 = StringPermutationsList(word2);
            deneme3 = StringPermutationsList(word3);

            Console.WriteLine(IsListContains(deneme, deneme2));//result true
            Console.WriteLine(IsListContains(deneme, deneme3));//result false

            Console.ReadLine();

        }

        static List<string> StringPermutationsList(string word)
        {
            List<string> result = new List<string>();
            List<string> result2 = new List<string>();

            int total = (int)Math.Pow(2, word.Length);


            for (int i = 0; i < total; i++)
            {
                string tempWord = string.Empty;

                for (int temp = i, j = 0; temp > 0; temp = temp >> 1, j++)
                {
                    if ((temp & 1) == 1)
                    {
                        tempWord += word[j];
                    }
                }

                List<string> permutations;
                Permutations(tempWord, out permutations);

                foreach (var prm in permutations)
                    result.Add(prm);
            }

            var resultDistinct = result.Distinct();

            foreach (var w in resultDistinct)
                result2.Add(w);

            return result2;

        }
        static void Permutations(string str, out List<string> result)
        {
            result = new List<string>();

            if (str.Length == 1)
            {
                result.Add(str);
                return;
            }


            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                string temp = str.Remove(i, 1);

                List<string> tempResult;
                Permutations(temp, out tempResult);

                foreach (var tempRes in tempResult)
                    result.Add(c + tempRes);
            }

        }
        static bool IsListContains(List<string> strList, List<string> strList2)
        {
            bool _isListContains = false;
            foreach (var item in strList2)
            {
                if (strList.Contains(item))
                {
                    _isListContains = true;
                }
            }
            return _isListContains;
        }
    }
}
