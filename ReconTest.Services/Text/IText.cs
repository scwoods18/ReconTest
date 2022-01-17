using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReconTest.Services.Text
{
    public interface IText
    {
        void InsertText(string text);
        void InsertSubText(string[] subTexts);

       Task<List<int>> FindSubTextIndexes(string text, string subText);
    }
}
