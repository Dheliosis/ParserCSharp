using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calc
{
    public class Tokenizer
    {
        public IEnumerable<Token> Tokenize(string code)
        {
            return Tokenize(code.Trim().GetEnumerator());
        }

        public IEnumerable<Token> Tokenize(IEnumerator<char> code)
        {
            if (!code.MoveNext())
            {
                yield return new Token
                {
                    Type = TokenType.EOF
                };
                yield break;
            }

            Token token;
            var eof = false;

            do
            {
                token = IgnoreWhiteSpace(code, out eof);
                if (token == null && !eof) token = ParseNumber(code, out eof);
                if (token == null && !eof) token = ParseId(code, out eof);
                if (token == null && !eof) token = ParseOneChar(code, '+', TokenType.Operator, out eof);
                if (token == null && !eof) token = ParseOneChar(code, '-', TokenType.Operator, out eof);
                if (token == null && !eof) token = ParseOneChar(code, '*', TokenType.Operator, out eof);
                if (token == null && !eof) token = ParseOneChar(code, '/', TokenType.Operator, out eof);
                if (token == null && !eof) token = ParseOneChar(code, '(', TokenType.LeftBracket, out eof);
                if (token == null && !eof) token = ParseOneChar(code, ')', TokenType.RightBracket, out eof);

                if (token == null) throw new Exception("Unknow token");

                yield return token;

            } while (!eof);

            yield return new Token
            {
                Type = TokenType.EOF
            };
        }

        private Token IgnoreWhiteSpace(IEnumerator<char> code, out bool eof)
        {
            eof = false;
            while(char.IsWhiteSpace(code.Current))
            {
                if (eof = !code.MoveNext()) break;
            }

            return null;
        }

        private Token ParseNumber(IEnumerator<char> code, out bool eof)
        {
            eof = false;
            var number = new StringBuilder();

            while (char.IsDigit(code.Current))
            {
                number.Append(code.Current);
                if (eof = !code.MoveNext()) break;
            }

            if (number.Length > 0)
                return new Token
                {
                    Type = TokenType.Number,
                    Value = number.ToString(),
                };

            return null;
        }

        private Token ParseId(IEnumerator<char> code, out bool eof)
        {
            eof = false;
            var id = new StringBuilder();

            while (char.IsLetter(code.Current))
            {
                id.Append(code.Current);
                if (eof = !code.MoveNext()) break;
            }

            if (id.Length > 0)
                return new Token
                {
                    Type = TokenType.Id,
                    Value = id.ToString(),
                };

            return null;
        }

        private Token ParseOneChar(IEnumerator<char> code, char c, TokenType type, out bool eof)
        {
            eof = false;
            Token token = null;
            if (code.Current == c)
            {
                token = new Token
                {
                    Type = type,
                    Value = c.ToString()
                };
                eof = !code.MoveNext();
            }

            return token;
        }
    }
}
