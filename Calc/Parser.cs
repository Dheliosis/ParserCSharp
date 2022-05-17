using System.Collections.Generic;
using System;

namespace Calc 
{
public class Parser 
{
    public Node Parse(IEnumerable<Token> tokens){
      // TO DO 
      // RECOIT UN ENSEMBLE DE TOKEN
      // RETOURNE UN NOEUD LA RACINE DE LA4RBRE
      //

      //foreach (var token in tokens){
      //    
      //}

    Node currentNode = null;
    foreach (var token in tokens)
    {
        if( token.Type == TokenType.Number)
        {
            if( currentNode == null ) 
            {
                // si noeud courrant est nul alors instacie noeud et met valeur du nombre et stocke dans noeud courant
                var node = new Node (TokenType.Number, token.Value);
                currentNode = node;
            } else {
                // cas ou le noeud courant est instancié (ici le +) on se met en enfant a droite du noeud existant 
                var childNode = new Node (TokenType.Number, token.Value);
                currentNode.RightChild = childNode;
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
                var arithmeticNode = new Node (TokenType.Operator, token.Value);
                arithmeticNode.LeftChild = currentNode;
                currentNode = arithmeticNode;
                //instanciation noeud operateur
                // stocker noeud precdefant dans enfant a gauche
                // change le current node
            }
            
            
        }

        if( token.Type == TokenType.Id) 
        {

        }
        if( token.Type == TokenType.LeftBracket) 
        {

        }
        if( token.Type == TokenType.RightBracket) 
        {

        }
        if( token.Type == TokenType.EOF) 
        {

        }


    }


      return null;
    }
  }
}