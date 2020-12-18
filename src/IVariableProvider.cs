namespace SimpleEvaluator
{
	public interface IVariableProvider
	{
		object GetValue(string index);
		bool ContainsKey(string index);
	}
}
