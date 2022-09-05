using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
namespace Tokenizers.Tests
{
    public class WordTokenChangerTest : BeforeAfterTestAttribute
    {
        [Fact]
        public void TokenChangerDontShouldChangeSymbols()
        {
            var inputTokens = new List<Token> {
                new Token(new StringBuilder(","), false),
                new Token(new StringBuilder("-"), false),
                new Token(new StringBuilder("#"), false),
                new Token(new StringBuilder("="), false),
                new Token(new StringBuilder("+"), false),
                new Token(new StringBuilder("2"), false),
                new Token(new StringBuilder("%"), false),
                new Token(new StringBuilder("@"), false),
                new Token(new StringBuilder("?"), false),
            };

            WordTokenChanger wordTokenChanger = new WordTokenChanger(inputTokens);

            var outTokens = wordTokenChanger.ChangeWord();
            Assert.Equal(inputTokens, outTokens);
        }

        [Fact]
        public void TokenChangerShouldChangeWord()
        {

            var inputTokens = new List<Token> {
                new Token(new StringBuilder("изменение"), true),
                new Token(new StringBuilder("собака"), true),
                new Token(new StringBuilder("удаление"), true),
                new Token(new StringBuilder("преведение"), true),
            };

            WordTokenChanger wordTokenChanger = new WordTokenChanger(inputTokens);
            var outTokens = wordTokenChanger.ChangeWord();
            Assert.Collection<Token>(outTokens,
                token => Assert.Equal("изменении", token.value.ToString()),
                token => Assert.Equal("собака", token.value.ToString()),
                token => Assert.Equal("удалении", token.value.ToString()),
                token => Assert.Equal("приведении", token.value.ToString())
            );
        }

        [Fact]
        public void TokenChangerDontShouldModificNotWordTokens1()
        {
            var tokenizer = new WordTokenizer();
            string inputString = ",преведение собака213, изменение?Э81 обострение()ХЪ слово не воробей";
            tokenizer.ParseToToken(inputString);

            var tokens = tokenizer.GetTokens();

            WordTokenChanger wordTokenChanger = new WordTokenChanger(tokens);
            var ChangeTokens = wordTokenChanger.ChangeWord();

            string outString = string.Concat(ChangeTokens);

            Assert.Equal(",приведении собака213, изменении?Э81 обострении()ХЪ слово не воробей", outString);
        }

        [Fact]
        public void TokenChangerDontShouldModificNotWordTokens2()
        {
            var tokenizer = new WordTokenizer();
            string inputString = ",пре ие 21перуй3на,2";
            tokenizer.ParseToToken(inputString);

            var tokens = tokenizer.GetTokens();

            WordTokenChanger wordTokenChanger = new WordTokenChanger(tokens);
            var ChangeTokens = wordTokenChanger.ChangeWord();

            string outString = string.Concat(ChangeTokens);

            Assert.Equal(",при ии 21перуй3на,2", outString);
        }

        [Fact]
        public void TokenChangerDontShouldModificNotWordTokens3()
        {
            var tokenizer = new WordTokenizer();
            string inputString = ",преие-,йперекатие приие 71*:?%;№предугадать";
            tokenizer.ParseToToken(inputString);

            var tokens = tokenizer.GetTokens();

            WordTokenChanger wordTokenChanger = new WordTokenChanger(tokens);
            var ChangeTokens = wordTokenChanger.ChangeWord();

            string outString = string.Concat(ChangeTokens);

            Assert.Equal(",приии-,йперекатии приии 71*:?%;№придугадать", outString);
        }
    }
}
