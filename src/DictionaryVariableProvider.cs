using System.Collections.Generic;

namespace SimpleEvaluator
{
	public class DictionaryVariableProvider : Dictionary<string, object>, IVariableProvider
	{
		public DictionaryVariableProvider()
		{
		}

		public object GetValue(string index)
		{
			return this[index];
		}
	}
}
