using System;
using SimpleEvaluator;

namespace SimpleEvaluator.Functions
{
	/// <summary>
	/// Substring Function
	/// </summary>
	public class SubStringFunctionPlugIn : IFunctionPlugIn
	{
		public SubStringFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			string s=(string)fd[0];
			int start=fd[1];
			int len=fd[2];
			if (s.Length<start+len)
				len=s.Length-start;
			return new Variant( s.Substring(start, len) );
		}
		
		public string FunctionName
		{
			get
			{
				return "SUBSTRING";
			}
		}

		public int ExpectedArgumentCount
		{
			get
			{
				return 3;
			}
		}
	}
}
