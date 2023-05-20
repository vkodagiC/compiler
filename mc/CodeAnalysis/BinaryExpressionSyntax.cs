namespace mc.CodeAnalysis
{
    sealed class BinaryExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax Left { get; }
        public SyntaxToken OperatorToken { get; }
        public ExpressionSyntax Right { get; }

        public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

        
        public BinaryExpressionSyntax(ExpressionSyntax left,SyntaxToken operatorToken,ExpressionSyntax right)
        {
            this.OperatorToken = operatorToken;
            this.Right = right;
            this.Left = left;

        }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return Left;
            yield return OperatorToken;
            yield return Right;
        }
    }


}