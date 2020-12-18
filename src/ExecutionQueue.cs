using System.Collections;
using System.Collections.Generic;

namespace SimpleEvaluator
{
	public class ExecutionQueue : Queue<ExecutionItem>
	{
		public ExecutionQueue()
		{
		}

		public ExecutionQueue Clone()
		{
			ExecutionQueue retEQ = new ExecutionQueue();
			IEnumerator ieNum = this.GetEnumerator();
			while(ieNum.MoveNext())
				retEQ.Enqueue((ExecutionItem)ieNum.Current);
			return retEQ;
		}
	}
}
