using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReconTest.Infrastructure.Utils
{
    public interface ITextProcessor
    {
        Task <List<int>> GetSubTextIndexes(string text, string subText);

    }
}
