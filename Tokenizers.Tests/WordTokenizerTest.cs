using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Tokenizers.Tests
{
    public class WordTokenizerTest : BeforeAfterTestAttribute 
    {

        public WordTokenizerTest()
        {

        }

        [Fact]
        public void WordTokenizerShouldParseToToken()
        {
            var tokenizer = new WordTokenizer();
            string inputString = ",word?";// "набор0%ж.,№%д";
            tokenizer.ParseToToken(inputString);
            var tokens = tokenizer.GetTokens();
            Assert.Collection<Token>(tokens,
                token => Assert.Equal(",", token.value.ToString()),
                token => Assert.Equal("word", token.value.ToString()),
                token => Assert.Equal("?", token.value.ToString())
            );
        }

        [Fact]
        public void WordTokenizerShouldParseToTokenIsWord()
        {
            var tokenizer = new WordTokenizer();
            string inputString = ",word?";// "набор0%ж.,№%д";
            tokenizer.ParseToToken(inputString);
            var tokens = tokenizer.GetTokens();
            Assert.Collection<Token>(tokens,
                token => Assert.False(token.isWord),
                token => Assert.True(token.isWord ),
                token => Assert.False(token.isWord));
        }
        //

    }
}
