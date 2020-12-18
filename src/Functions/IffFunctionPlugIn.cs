namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// IIF Function
    /// </summary>
    public class IffFunctionPlugIn : IFunctionPlugIn
	{
		public IffFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			if((bool)fd[0])
				return fd[1];
			else
				return fd[2];
		}
		
		public string FunctionName
		{
			get
			{
				return "IIF";
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
