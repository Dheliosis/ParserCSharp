using System;
using Calc;

namespace Calc.launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tokens = new Tokenizer();
            var parser = new Parser();
            parser.Parse(tokens.Tokenize("1+2"));
        }
    }
}
