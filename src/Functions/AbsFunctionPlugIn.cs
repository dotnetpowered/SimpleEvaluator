namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// Abs Function
    /// </summary>
    public class AbsFunctionPlugIn : IFunctionPlugIn
	{
		public AbsFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant((double)System.Math.Abs((double)fd[0]));
		}
		
		public string FunctionName
		{
			get
			{
				return "ABS";
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
