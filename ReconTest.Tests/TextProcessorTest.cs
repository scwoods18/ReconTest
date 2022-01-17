using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReconTest.Infrastructure.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReconTest.Tests
{
    [TestClass]
    public class TextProcessorTest
    {
        public const string Text = "Peter told me (actually he slurrred) that peter the pickle piper piped a pitted pickle before he petered out. Phew!";
        [TestMethod]
        public void TextProcessorTestWithTextAndPetterAsSubText()
        {
            var ITextProcessor = new TextProcessor();
            List<int> inputIndexes = new List<int>();
            inputIndexes.AddRange(new []{ 1,43,98});
            List<int> outIndexes = ITextProcessor.GetSubTextIndexes(Text, "Peter").Result;
            
            CollectionAssert.AreEqual(inputIndexes, outIndexes);

        }
        [TestMethod]
        public void TextProcessorTestWithTextAndPetterLoweCaseAsSubText()
        {
            var ITextProcessor = new TextProcessor();
            List<int> inputIndexes = new List<int>();
            inputIndexes.AddRange(new[] { 1,43,98 });
            List<int> outIndexes = ITextProcessor.GetSubTextIndexes(Text, "peter").Result;

            CollectionAssert.AreEqual(inputIndexes, outIndexes);

        }

        [TestMethod]
        public void TextProcessorTestWithTextAndPickAsSubText()
        {
            var ITextProcessor = new TextProcessor();
            List<int> inputIndexes = new List<int>();
            inputIndexes.AddRange(new[] { 53, 81 });
            List<int> outIndexes = ITextProcessor.GetSubTextIndexes(Text, "Pick").Result;

            CollectionAssert.AreEqual(inputIndexes, outIndexes);

        }

        [TestMethod]
        public void TextProcessorTestWithTextAndPiAsSubText()
        {
            var ITextProcessor = new TextProcessor();
            List<int> inputIndexes = new List<int>();
            inputIndexes.AddRange(new[] { 53, 60, 66, 74, 81 });
            List<int> outIndexes = ITextProcessor.GetSubTextIndexes(Text, "Pi").Result;

            CollectionAssert.AreEqual(inputIndexes, outIndexes);

        }

        [TestMethod]
        public void TextProcessorTestWithTextAndZAsSubText()
        {
            var ITextProcessor = new TextProcessor();
            List<int> outIndexes = ITextProcessor.GetSubTextIndexes(Text, "Z").Result;
            Assert.AreEqual(0, outIndexes.Count);
         
        }
    }
}
