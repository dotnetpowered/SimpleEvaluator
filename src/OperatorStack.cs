using System.Collections;

namespace SimpleEvaluator
{
	public class OperatorStack:Stack
	{
		public OperatorStack()
		{
		}

		public new EnmOperators Peek()
		{
			return (EnmOperators)base.Peek();
		}

		public new EnmOperators Pop()
		{
			return (EnmOperators)base.Pop();
		}

		public void Push(EnmOperators op)
		{
			base.Push(op);
		}
	}
}
