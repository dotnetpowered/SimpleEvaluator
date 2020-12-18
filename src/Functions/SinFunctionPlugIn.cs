namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// SIN Function
    /// </summary>
    public class SinFunctionPlugIn : IFunctionPlugIn
	{
		public SinFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant(System.Math.Sin(fd[0]));
		}
		
		public string FunctionName
		{
			get
			{
				return "SIN";
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
