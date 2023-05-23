﻿// See https://aka.ms/new-console-template for more information
using System;
using mc.CodeAnalysis;
using mc.CodeAnalysis.Binding;
using mc.CodeAnalysis.Syntax;

namespace mc
{
    internal static class Program
    {
        private static void Main()
        {
            var showTree = false;
            while (true)
            {   

                Console.Write("> ");
                var line = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(line))
                return;

                if(line == "#showTree")
                {
                    showTree  = !showTree;
                    Console.WriteLine(showTree ? "Showing parse trees." : "Not showing parse trees");
                    continue;
                }
                else if(line == "#cls"){
                    Console.Clear();
                    continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);
                var binder = new Binder();
                var boundExpression = binder.BindExpression(syntaxTree.Root);
                var diagnostics = syntaxTree.Diagnostics.Concat(binder.Diagnostics).ToArray();
                if(showTree)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    PrettyPrint(syntaxTree.Root);
                    Console.ForegroundColor = color;
                }
                

                if (!diagnostics.Any())
                {
                    var e = new Evaluator(boundExpression);
                    var result = e.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var _diagnostic in syntaxTree.Diagnostics)
                    {
                        Console.WriteLine(_diagnostic);
                    }
                    Console.ForegroundColor = color;
                }


            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "",bool isLast  = true)
        {       //├──
                //└── 
                //│
                var marker =  isLast? "└──" : "├──";
                Console.Write(indent);
                Console.Write(marker);
                Console.Write(node.Kind);
                if(node is SyntaxToken t && t.Value != null)
                {
                    Console.Write(" ");
                    Console.Write(t.Value);
                }
                Console.WriteLine();
                //indent += "    ";
                indent += isLast? "    ":"│   ";
                var lastChild  = node.GetChildren().LastOrDefault();

                foreach(var child in node.GetChildren())
                {
                    PrettyPrint(child,indent,child == lastChild);
                }
        }
    }

}
