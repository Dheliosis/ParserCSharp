namespace Calc 
{
public class Node 
{
    public Node Parent { get; set; }
    public Node LeftChild { get; set; }
    public Node RightChild { get; set; }
    public TokenType TokenType { get; set; }

    public string Value { get; set;}

    public Node(TokenType tokenType, string value)
    {   
        TokenType = tokenType;
        Value = value;
    }

  }
}