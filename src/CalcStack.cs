using System.Collections;

namespace SimpleEvaluator
{
	public class CalcStack : Stack
	{
		public CalcStack()
		{
		}
		
		public new Variant Pop()
		{
			return (Variant)base.Pop();
		}
		
		public new Variant Peek()
		{
			return (Variant)base.Peek();
		}

		private new void Push(object o) {}
		public void Push(Variant v)
		{
			base.Push(v);
		}
	}

	public class FunctionDesc : ArrayList  
	{
		public string functionName;	
		public FunctionDesc()
		{
			functionName = string.Empty;
		}
		public FunctionDesc(string s)
		{
			functionName = s;
		}

		private new int Add(object o) {return 0;}
		public int Add(Variant v) {return base.Add(v);}

		public new Variant this[int index]
		{
			get{return (Variant)base[index];}
			set{base[index] = value;}
		}
		
		
	}

}
