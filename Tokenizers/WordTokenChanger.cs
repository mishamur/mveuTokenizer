using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizers.Models;

namespace Tokenizers
{
    public class WordTokenChanger
    {
        private IEnumerable<Token> tokens;

        public WordTokenChanger(IEnumerable<Token> tokens)
        {
            this.tokens = tokens;
        }

        public IEnumerable<Token> ChangeWord()
        {
            foreach(var token in tokens)
            {
                if (token.isWord)
                {
                    StringBuilder tokenValue = token.value;
                    if (tokenValue.ToString().StartsWith("пре"))
                    {
                        tokenValue.Replace("пре", "при", 0, 3);
                    }
                    if (token.value.ToString().EndsWith("ие"))
                    {
                         tokenValue.Replace("ие", "ии", tokenValue.Length - 2, 2);
                    }
                }
                yield return token;
            }
        }
    }
}
