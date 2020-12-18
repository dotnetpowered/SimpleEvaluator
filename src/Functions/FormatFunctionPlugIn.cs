using System;

namespace SimpleEvaluator.Functions
{
    /// <summary>
    /// Format Function
    /// </summary>
    public class FormatFunctionPlugIn : IFunctionPlugIn
	{
		public FormatFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			Variant v = fd[1];
			switch(v.VarType)
			{
				case VariantType.vtBool:
					return new Variant(String.Format("{0:" + fd[0].ToString() + "}",(bool)v));
				case VariantType.vtInt:
					return new Variant(String.Format("{0:" + fd[0].ToString() + "}",(int)v));
				case VariantType.vtDouble:
					return new Variant(String.Format("{0:" + fd[0].ToString() + "}",(double)v));
				case VariantType.vtDateTime:
					return new Variant(String.Format("{0:" + fd[0].ToString() + "}",(DateTime)v));
				case VariantType.vtString:
					return new Variant(String.Format("{0:" + fd[0].ToString() + "}",(string)v));
				default:
					return new Variant(string.Empty);
			}
		}
		
		public string FunctionName
		{
			get
			{
				return "FORMAT";
			}
		}

		public int ExpectedArgumentCount
		{
			get
			{
				return 2;
			}
		}
	}


}
