using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizers.Models;

namespace Tokenizers
{
    public class WordTokenizer
    {
        private string inputString;
        private List<Token> Tokens;
        public StringBuilder token;
        public WordTokenizer()
        {
            this.inputString = "";
            this.Tokens = new List<Token>();
            token = new StringBuilder();
        }

        public void ParseToToken(string inputString)
        {
            this.inputString = inputString;
            this.Tokens.Clear();

            var enumerator = inputString.GetEnumerator();
            q0(enumerator);
        }

        public IEnumerable<Token> GetTokens()
        {
            foreach(var token in Tokens)
            {
                yield return new Token(token);
            }
           
        }
        
        //если символ буква
        private void q0(CharEnumerator charEnumerator)
        {
            if (charEnumerator.MoveNext())
            {
                char ch = charEnumerator.Current;
                if (char.IsLetter(ch))
                {
                    token.Append(ch);
                    q0(charEnumerator);
                }
                else
                {
                    q1(charEnumerator);
                }
                
            }
            else
            {
                if(token.Length > 0)
                {
                    Tokens.Add(new Token(token, true));
                }
            }
        }

        //если символ не буква
        private void q1(CharEnumerator charEnumerator)
        {
            char ch = charEnumerator.Current;
            if (token.Length > 0)
            {
                Tokens.Add(new Token(token, true));
            }
            token = new();
            Tokens.Add(new Token(new StringBuilder(ch.ToString()), false));
            q0(charEnumerator);
        }



    }
}
