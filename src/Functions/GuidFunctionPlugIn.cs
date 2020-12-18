using System;
using SimpleEvaluator;

namespace SimpleEvaluator.Functions
{
	/// <summary>
	/// Guid Function
	/// </summary>
	public class GuidFunctionPlugIn : IFunctionPlugIn
	{
		public GuidFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant(Guid.NewGuid().ToString());
		}
		
		public string FunctionName
		{
			get
			{
				return "GUID";
			}
		}

		public int ExpectedArgumentCount
		{
			get
			{
				return 0;
			}
		}
	}
}
