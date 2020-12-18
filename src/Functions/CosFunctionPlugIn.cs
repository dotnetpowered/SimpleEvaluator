namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// COS Function
    /// </summary>
    public class CosFunctionPlugIn : IFunctionPlugIn
	{
		public CosFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant(System.Math.Cos(fd[0]));
		}
		
		public string FunctionName
		{
			get
			{
				return "COS";
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
