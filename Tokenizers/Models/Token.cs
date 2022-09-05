using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizers.Models
{
    public class Token 
    {
        public StringBuilder value { get; private set; }
        public bool isWord { get; private set; }

        public Token(Token token)
        {
            this.value = new StringBuilder(token.value.ToString());
            this.isWord = token.isWord;
        }

        public Token(StringBuilder value, bool isWord)
        {
            this.value = value;
            this.isWord = isWord;
        }

        public override string ToString()
        {
            return $"{value.ToString()}";
        }

    }
}
