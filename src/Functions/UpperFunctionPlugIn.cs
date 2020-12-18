using System;
using SimpleEvaluator;

namespace SimpleEvaluator.Functions
{
	/// <summary>
	/// Upper Function
	/// </summary>
	public class UpperFunctionPlugIn : IFunctionPlugIn
	{
		public UpperFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant( fd[0].ToString().ToUpper() );
		}
		
		public string FunctionName
		{
			get
			{
				return "UPPER";
			}
		}

		public int ExpectedArgumentCount
		{
			get
			{
				return 1;
			}
		}
	}
}
