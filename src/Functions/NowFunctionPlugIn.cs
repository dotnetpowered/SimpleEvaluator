namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// NOW Function
    /// </summary>
    public class NowFunctionPlugIn : IFunctionPlugIn
	{
		public NowFunctionPlugIn() {}
		
		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant(System.DateTime.Now);
		}
		
		public string FunctionName
		{
			get
			{
				return "NOW";
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
