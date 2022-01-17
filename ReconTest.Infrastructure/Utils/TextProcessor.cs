using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReconTest.Infrastructure.Utils
{
    public class TextProcessor :ITextProcessor
    {
        public TextProcessor() 
        {
        }

        public Task<List<int>> GetSubTextIndexes(string text, string subText)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                string stringToCompare = string.Empty;

                for (int j = i; j < text.Length; j++)
                {
                    stringToCompare += text[j];
                    if (String.Compare(subText, stringToCompare, true) == 0)
                    {
                        indexes.Add(i + 1);
                    }
                }
            }
            return Task.FromResult(indexes);
        }
    }
}
