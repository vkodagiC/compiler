namespace mc.CodeAnalysis
{
    public sealed class UnaryExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken OperatorToken { get; }
        public override SyntaxKind Kind => SyntaxKind.UnaryExpression;  
        public ExpressionSyntax Operand { get; }
        public UnaryExpressionSyntax(SyntaxToken operatorToken,ExpressionSyntax operand)
        {
            this.Operand = operand;
            this.OperatorToken = operatorToken;
        }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OperatorToken;
            yield return Operand;
        }
    }


}