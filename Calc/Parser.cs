using System.Collections.Generic;
using System;
using System.Linq;

namespace Calc 
{
public class Parser 
{
    public Node Parse(IEnumerable<Token> tokens){

    Node currentNode = null;
    int i = 0;
    foreach (var token in tokens)
    {
        if( token.Type == TokenType.Number)
        {
            if( currentNode == null ) 
            {
                // si le noeud courant est null alors instacier noeud et mettre en valeur le nombre puis stocker ce noeud dans noeud courant
                Console.WriteLine("Pas de noeud courant");
                var node = new Node (TokenType.Number, token.Value);
                currentNode = node;
            } else {
                // cas où le noeud courant est instancié, on se met en enfant à droite du noeud existant 
                Console.WriteLine("Noeud Courant : {0}", currentNode.Value);
                Console.WriteLine("Noeud à ajouter : {0}", token.Value);
                var childNode = new Node (TokenType.Number, token.Value);
            }
        }

        if( token.Type == TokenType.Operator)
        {
            if(currentNode == null ) 
            {
                throw new Exception("Une erreur car arithmétique a forcément un élement gauche");
            } 
            else
            {
                Console.WriteLine("Noeud courant : {0}", currentNode.Value);
                Console.WriteLine("Noeud à ajouter : {0}", token.Value);
                var arithmeticNode = new Node (TokenType.Operator, token.Value);
                arithmeticNode.LeftChild = currentNode;
                currentNode = arithmeticNode;
            }
        }

        if( token.Type == TokenType.Id) 
        {
            // CAS D'UNE FONCTION
        }

        if( token.Type == TokenType.LeftBracket) 
        {
            // SI on à une ( alors on stock toutes les valeurs qu'on trouve après jusqu'a qu'on trouve une )
            // Pour ensuite faire une récursivité avec Parser stocker les noeuds dans une varible
            // Et les ajouter au noeud parent
            var tokenBis = tokens.Where(t => t.Value.StartsWith("(") && t.Value.EndsWith(")"));
            foreach(var v in tokenBis)
            {
                Console.WriteLine(v.Value);
            }
            
            // Console.WriteLine(token.Value);
            // var _tokens = tokens.Value;
            
        }
        if( token.Type == TokenType.RightBracket) 
        {            
            //Parse(_tokens)
        }

        if( token.Type == TokenType.EOF) 
        {
            // END OF FILE
            return currentNode;
        }

    i++;
    }


      return null;
    }
  }
}