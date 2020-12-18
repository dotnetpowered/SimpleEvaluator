namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// Sqrt Function
    /// </summary>
    public class SqrtFunctionPlugIn : IFunctionPlugIn
	{
		public SqrtFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant(System.Math.Sqrt(fd[0]));
		}
		
		public string FunctionName
		{
			get
			{
				return "SQRT";
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
