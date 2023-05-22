namespace mc.CodeAnalysis.Syntax
{
    public sealed class LiteralExpressionSyntax : ExpressionSyntax
    {
       
        public LiteralExpressionSyntax(SyntaxToken literalToken)
        {
            this.LiteralToken = literalToken;
            
        }

        
        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;
        public SyntaxToken LiteralToken { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return LiteralToken;
        }
    }


}