//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Users\Wenjie\OneDrive\MasterThesis\VisionBasedCompiler\BioCompiler\Visitors\Syntax.g by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="SyntaxParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface ISyntaxVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] SyntaxParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStat([NotNull] SyntaxParser.StatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.repeat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRepeat([NotNull] SyntaxParser.RepeatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] SyntaxParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInput([NotNull] SyntaxParser.InputContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.move"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMove([NotNull] SyntaxParser.MoveContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.merge"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMerge([NotNull] SyntaxParser.MergeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.split"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSplit([NotNull] SyntaxParser.SplitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.mix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMix([NotNull] SyntaxParser.MixContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.output"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOutput([NotNull] SyntaxParser.OutputContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SyntaxParser.store"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStore([NotNull] SyntaxParser.StoreContext context);
}
