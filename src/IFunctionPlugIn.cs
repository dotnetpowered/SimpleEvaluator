namespace SimpleEvaluator
{
	public interface IFunctionPlugIn
	{
		Variant Evaluate(FunctionDesc fd);
		
		string FunctionName
		{
			get;
		}

		int ExpectedArgumentCount
		{
			get;
		}
	}
}
