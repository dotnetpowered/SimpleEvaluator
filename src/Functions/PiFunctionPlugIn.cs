namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// PI Function
    /// </summary>
    public class PiFunctionPlugIn : IFunctionPlugIn
	{
		public PiFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			return new Variant(System.Math.PI);
		}
		
		public string FunctionName
		{
			get
			{
				return "PI";
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
