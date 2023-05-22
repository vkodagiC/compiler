namespace mc.CodeAnalysis.Syntax
{
    public sealed class SyntaxTree
    {
        public ExpressionSyntax Root { get; }
        public SyntaxToken EndOfFileToken { get; }
        public IReadOnlyList<string> Diagnostics { get; set; }
        public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken EndOfFileToken)
        {
            this.Diagnostics = diagnostics.ToArray();
            this.EndOfFileToken = EndOfFileToken;
            this.Root = root;

        }
        public static SyntaxTree Parse(string text)
        {
            var parser = new Parser(text);
            return parser.Parse();
        }
    }


}