using ReconTest.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using ReconTest.Infrastructure.Utils;
using System.Threading.Tasks;

namespace ReconTest.Services.Text
{
    public class TextService : IText
    {
        readonly ITextProcessor _textProcessor;
        public TextService(ITextProcessor textProcessor)
        {
            _textProcessor = textProcessor; 
        }

        public void InsertSubText(string[] subTexts)
        {
            throw new NotImplementedException();
        }

        public void InsertText(string text)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> FindSubTextIndexes(string text, string subText)
        {
            return _textProcessor.GetSubTextIndexes(text, subText);
        }
    }
}
