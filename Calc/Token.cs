using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public enum TokenType
    {
        Number,
        Id,
        Operator,
        LeftBracket,
        RightBracket,
        EOF
    }

    public class Token
    {
        public TokenType Type { get; set; }

        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            var token = obj as Token;
            if (token == null) return false;

            return token.Type == Type && token.Value == Value;
        }
    }
}
