namespace mc.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryExpression : BoundExpression
    {
        public BoundExpression Left { get; }
        public BoundBinaryOperatorKind OperatorKind { get; }
        public BoundExpression Right { get; }
        public BoundBinaryExpression(BoundExpression left, BoundBinaryOperatorKind operatorKind,BoundExpression right)
        {
            this.Right = right;
            this.Left = left;
            this.OperatorKind = operatorKind;

        }

        public override Type Type => Left.Type;

        public BoundExpression Operand { get; }

        public override BoundNodeKind Kind => BoundNodeKind.BinaryExpression;
    }
}
