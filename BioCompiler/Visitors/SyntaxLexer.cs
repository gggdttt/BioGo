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

using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public partial class SyntaxLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, ID=16, INT=17, 
		FLOAT=18, COMMENT=19, SPACE=20;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "ID", "INT", "FLOAT", 
		"COMMENT", "SPACE"
	};


	public SyntaxLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public SyntaxLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'repeat'", "'times{'", "'}'", "'droplet'", "';'", "'input('", "','", 
		"')'", "'move'", "'('", "'merge'", "'split'", "'mix'", "'output'", "'store'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, "ID", "INT", "FLOAT", "COMMENT", "SPACE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Syntax.g"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static SyntaxLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,20,143,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,1,0,1,0,1,0,1,0,
		1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,
		3,1,3,1,3,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,
		1,8,1,8,1,8,1,9,1,9,1,10,1,10,1,10,1,10,1,10,1,10,1,11,1,11,1,11,1,11,
		1,11,1,11,1,12,1,12,1,12,1,12,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,14,
		1,14,1,14,1,14,1,14,1,14,1,15,1,15,5,15,117,8,15,10,15,12,15,120,9,15,
		1,16,4,16,123,8,16,11,16,12,16,124,1,17,1,17,1,17,1,17,1,18,1,18,5,18,
		133,8,18,10,18,12,18,136,9,18,1,18,1,18,1,19,1,19,1,19,1,19,0,0,20,1,1,
		3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,
		31,16,33,17,35,18,37,19,39,20,1,0,5,3,0,65,90,95,95,97,122,4,0,48,57,65,
		90,95,95,97,122,1,0,48,57,2,0,10,10,13,13,3,0,9,10,13,13,32,32,145,0,1,
		1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,
		13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,
		0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,
		0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,1,41,1,0,0,0,3,48,1,0,0,0,5,55,
		1,0,0,0,7,57,1,0,0,0,9,65,1,0,0,0,11,67,1,0,0,0,13,74,1,0,0,0,15,76,1,
		0,0,0,17,78,1,0,0,0,19,83,1,0,0,0,21,85,1,0,0,0,23,91,1,0,0,0,25,97,1,
		0,0,0,27,101,1,0,0,0,29,108,1,0,0,0,31,114,1,0,0,0,33,122,1,0,0,0,35,126,
		1,0,0,0,37,130,1,0,0,0,39,139,1,0,0,0,41,42,5,114,0,0,42,43,5,101,0,0,
		43,44,5,112,0,0,44,45,5,101,0,0,45,46,5,97,0,0,46,47,5,116,0,0,47,2,1,
		0,0,0,48,49,5,116,0,0,49,50,5,105,0,0,50,51,5,109,0,0,51,52,5,101,0,0,
		52,53,5,115,0,0,53,54,5,123,0,0,54,4,1,0,0,0,55,56,5,125,0,0,56,6,1,0,
		0,0,57,58,5,100,0,0,58,59,5,114,0,0,59,60,5,111,0,0,60,61,5,112,0,0,61,
		62,5,108,0,0,62,63,5,101,0,0,63,64,5,116,0,0,64,8,1,0,0,0,65,66,5,59,0,
		0,66,10,1,0,0,0,67,68,5,105,0,0,68,69,5,110,0,0,69,70,5,112,0,0,70,71,
		5,117,0,0,71,72,5,116,0,0,72,73,5,40,0,0,73,12,1,0,0,0,74,75,5,44,0,0,
		75,14,1,0,0,0,76,77,5,41,0,0,77,16,1,0,0,0,78,79,5,109,0,0,79,80,5,111,
		0,0,80,81,5,118,0,0,81,82,5,101,0,0,82,18,1,0,0,0,83,84,5,40,0,0,84,20,
		1,0,0,0,85,86,5,109,0,0,86,87,5,101,0,0,87,88,5,114,0,0,88,89,5,103,0,
		0,89,90,5,101,0,0,90,22,1,0,0,0,91,92,5,115,0,0,92,93,5,112,0,0,93,94,
		5,108,0,0,94,95,5,105,0,0,95,96,5,116,0,0,96,24,1,0,0,0,97,98,5,109,0,
		0,98,99,5,105,0,0,99,100,5,120,0,0,100,26,1,0,0,0,101,102,5,111,0,0,102,
		103,5,117,0,0,103,104,5,116,0,0,104,105,5,112,0,0,105,106,5,117,0,0,106,
		107,5,116,0,0,107,28,1,0,0,0,108,109,5,115,0,0,109,110,5,116,0,0,110,111,
		5,111,0,0,111,112,5,114,0,0,112,113,5,101,0,0,113,30,1,0,0,0,114,118,7,
		0,0,0,115,117,7,1,0,0,116,115,1,0,0,0,117,120,1,0,0,0,118,116,1,0,0,0,
		118,119,1,0,0,0,119,32,1,0,0,0,120,118,1,0,0,0,121,123,7,2,0,0,122,121,
		1,0,0,0,123,124,1,0,0,0,124,122,1,0,0,0,124,125,1,0,0,0,125,34,1,0,0,0,
		126,127,3,33,16,0,127,128,5,46,0,0,128,129,3,33,16,0,129,36,1,0,0,0,130,
		134,5,35,0,0,131,133,8,3,0,0,132,131,1,0,0,0,133,136,1,0,0,0,134,132,1,
		0,0,0,134,135,1,0,0,0,135,137,1,0,0,0,136,134,1,0,0,0,137,138,6,18,0,0,
		138,38,1,0,0,0,139,140,7,4,0,0,140,141,1,0,0,0,141,142,6,19,0,0,142,40,
		1,0,0,0,4,0,118,124,134,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
