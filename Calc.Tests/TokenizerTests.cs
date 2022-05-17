using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Calc.Tests
{
    [TestClass]
    public class TokenizerTests
    {
        [TestMethod]
        public void Tokenize()
        {
            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize("(344+48)*3/2+test(5)").ToList();

            CollectionAssert.AreEqual(new List<Token>
            {
                new Token{ Type = TokenType.LeftBracket, Value = "(" },
                new Token{ Type = TokenType.Number, Value = "344" },
                new Token{ Type = TokenType.Operator, Value = "+" },
                new Token{ Type = TokenType.Number, Value = "48" },
                new Token{ Type = TokenType.RightBracket, Value = ")" },
                new Token{ Type = TokenType.Operator, Value = "*" },
                new Token{ Type = TokenType.Number, Value = "3" },
                new Token{ Type = TokenType.Operator, Value = "/" },
                new Token{ Type = TokenType.Number, Value = "2" },
                new Token{ Type = TokenType.Operator, Value = "+" },
                new Token{ Type = TokenType.Id, Value = "test" },
                new Token{ Type = TokenType.LeftBracket, Value = "(" },
                new Token{ Type = TokenType.Number, Value = "5" },
                new Token{ Type = TokenType.RightBracket, Value = ")" },
                new Token{ Type = TokenType.EOF, Value = null }
            }, tokens);
        }

        [TestMethod]
        public void TokenizeWithSpaces()
        {
            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize("  ( 344  +  48 ) * 3 /  2  +  test  ( 5  )   ").ToList();

            CollectionAssert.AreEqual(new List<Token>
            {
                new Token{ Type = TokenType.LeftBracket, Value = "(" },
                new Token{ Type = TokenType.Number, Value = "344" },
                new Token{ Type = TokenType.Operator, Value = "+" },
                new Token{ Type = TokenType.Number, Value = "48" },
                new Token{ Type = TokenType.RightBracket, Value = ")" },
                new Token{ Type = TokenType.Operator, Value = "*" },
                new Token{ Type = TokenType.Number, Value = "3" },
                new Token{ Type = TokenType.Operator, Value = "/" },
                new Token{ Type = TokenType.Number, Value = "2" },
                new Token{ Type = TokenType.Operator, Value = "+" },
                new Token{ Type = TokenType.Id, Value = "test" },
                new Token{ Type = TokenType.LeftBracket, Value = "(" },
                new Token{ Type = TokenType.Number, Value = "5" },
                new Token{ Type = TokenType.RightBracket, Value = ")" },
                new Token{ Type = TokenType.EOF, Value = null }
            }, tokens);
        }
    }
}
