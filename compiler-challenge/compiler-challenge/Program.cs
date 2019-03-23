using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxTreeWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = CSharpSyntaxTree.ParseText(@"
class C
{
void Method()
{}
};");

            // print out full tree 
            System.Diagnostics.Debug.WriteLine(tree);

            var root = tree.GetRoot();
            var method = root.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            
            // make a new method returning string instead of void
            var returnType = SyntaxFactory.ParseTypeName("string");
            var newmethod = method.WithReturnType(returnType);

            System.Diagnostics.Debug.WriteLine(newmethod.ToString());
        }
    }
}
