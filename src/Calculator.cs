// Evaluator code by Zainaustria
// http://www.codetools.com/csharp/string_evaluator.asp
//
// Modified by Brian Ritchie to support Function Plugins & External Variable Providers

using System;
using System.Collections.Generic;
using SimpleEvaluator.Functions;

namespace SimpleEvaluator
{
	/// <summary>
	/// Summary description for Calculator.
	/// </summary>
	/// 
	public class CalcException : Exception
	{
		public CalcException(){}
		public CalcException(string s) : base(s){}
	}

	public class Calculator
	{
		private static Dictionary<string, IFunctionPlugIn> Functions;
		private Dictionary<string, IFunctionPlugIn> LocalFunctions;
		private Stack<Variant> calcStack;
		public IVariableProvider Variables;

		public static void RegisterFunction(Type FunctionPlugIn)
		{
			IFunctionPlugIn plugin=(IFunctionPlugIn) Activator.CreateInstance(FunctionPlugIn);
			Functions.Add(plugin.FunctionName,plugin);
		}

		static Calculator()
		{
			Functions=new ();
			// Register Embedded Functions
			RegisterFunction(typeof(PiFunctionPlugIn));
			RegisterFunction(typeof(SinFunctionPlugIn));
			RegisterFunction(typeof(CosFunctionPlugIn));
			RegisterFunction(typeof(AbsFunctionPlugIn));
			RegisterFunction(typeof(SqrtFunctionPlugIn));
			RegisterFunction(typeof(IffFunctionPlugIn));
			RegisterFunction(typeof(FormatFunctionPlugIn));
			RegisterFunction(typeof(UpperFunctionPlugIn));
			RegisterFunction(typeof(SubStringFunctionPlugIn));
			RegisterFunction(typeof(XPathFunctionPlugIn));
			RegisterFunction(typeof(NowFunctionPlugIn));
			RegisterFunction(typeof(GuidFunctionPlugIn));
		}

		public  Calculator(IVariableProvider VariableProvider)
		{
			calcStack = new ();
			Variables=VariableProvider;
			LocalFunctions=new ();
		}

		public void RegisterFunction(IFunctionPlugIn function)
		{
			LocalFunctions.Add(function.FunctionName, function);
		}

		public  Variant CalcIt(ExecutionQueue execq)
		{
			ExecutionQueue eq=execq.Clone();
			ExecutionItem ei;
			if(eq.Count == 0) return new Variant((string)null);
			while(eq.Count > 0)
			{
				ei = eq.Dequeue();
				switch(ei.itemType)
				{
					case ItemType.itBool:
						if(String.Compare(ei.itemString,"True",true) == 0)
							calcStack.Push(new Variant(true));
						else
							calcStack.Push(new Variant(false));
						break;
					case ItemType.itString:
						calcStack.Push(new Variant(ei.itemString));
					break;
					case ItemType.itDigit:
						try
						{
							int i = int.Parse(ei.itemString);
							calcStack.Push(new Variant(i));
						}
						catch
						{	
							double d;							
							try {d = double.Parse(ei.itemString);}
							catch{throw(new CalcException("Bad digital format"));}
							calcStack.Push(new Variant(d));
						}
					break;
					case ItemType.itDate:
						DateTime dt;
						try {dt = DateTime.Parse(ei.itemString);}
						catch {throw(new CalcException("Bad date format"));}
						calcStack.Push(new Variant(dt));
					break;
					case ItemType.itOperator:
						DoOperator(ei.itemOperator,eq);
					break;
					case ItemType.itFunction:
						DoFunction(ei);
						break;
					case ItemType.itVariable:
						if(!Variables.ContainsKey(ei.itemString)) throw(new CalcException("Bad variable name:"+ei.itemString));
						calcStack.Push(new Variant(Variables.GetValue(ei.itemString)));
						break;
					default:
						throw(new CalcException("Bad item in execution queue"));
				}
			}
			return calcStack.Pop();
		}

		private void DoFunction(ExecutionItem ei)
		{
			Variant v;
			FunctionDesc fd = new FunctionDesc(ei.itemString);
			foreach(string s in ei.itemParams)
			{
				Parser p = new Parser();
				p.ParseIt(s);
				ExecutionQueue eq;
				eq = p.eqResult;
				Calculator c = new Calculator(Variables);
				fd.Add(c.CalcIt(eq));
			}
			v = EmbeddedFunction(fd);
			if(v.VarType != VariantType.vtUnknow) calcStack.Push(v);
			else throw(new CalcException("Bad function " + ei.itemString));
		}
		private void DoOperator(EnmOperators op, ExecutionQueue eq)
		{
			switch(op)
			{
				case EnmOperators.UnMinus:
				case EnmOperators.Nop:
				case EnmOperators.Not:
				case EnmOperators.UnPlus:
					if(calcStack.Count < 1) throw(new CalcException("Stack is empty on " + op.ToString()));	
					break;
				default:
					if(calcStack.Count < 2) throw(new CalcException("Stack is empty on " + op.ToString()));	
					break;
			}

			switch(op)
			{
				case EnmOperators.UnMinus:
				case EnmOperators.Not:
					calcStack.Push(-calcStack.Pop());
					break;
				case EnmOperators.UnPlus:
					break;
				case EnmOperators.Plus:
					calcStack.Push(calcStack.Pop() + calcStack.Pop());
					break;
				case EnmOperators.Minus:
					calcStack.Push(calcStack.Pop() - calcStack.Pop());
					break;
				case EnmOperators.Mul:
					calcStack.Push(calcStack.Pop() * calcStack.Pop());
					break;
				case EnmOperators.Div:
					calcStack.Push(calcStack.Pop() / calcStack.Pop());
					break;
				case EnmOperators.Gr:
					calcStack.Push(calcStack.Pop() > calcStack.Pop());
					break;	
				case EnmOperators.Ls:
					calcStack.Push(calcStack.Pop() < calcStack.Pop());
					break;	
				case EnmOperators.GrEq:
					calcStack.Push(calcStack.Pop() >= calcStack.Pop());
					break;	
				case EnmOperators.LsEq:
					calcStack.Push(calcStack.Pop() <= calcStack.Pop());
					break;	
				case EnmOperators.Eq:
					calcStack.Push(calcStack.Pop() == calcStack.Pop());
					break;	
				case EnmOperators.NtEq:
					calcStack.Push(calcStack.Pop() != calcStack.Pop());
					break;
				default:
					throw(new CalcException("Operator " + op.ToString() + " is not supported yet"));
			}
		}

		private Variant EmbeddedFunction(FunctionDesc fd)
		{
			IFunctionPlugIn plugin=Functions[fd.FunctionName.ToUpper()];
			if (plugin==null)
				plugin=LocalFunctions[fd.FunctionName.ToUpper()];
			if (plugin==null)
				throw new CalcException("Invalid function name: "+fd.FunctionName);
			else
			{
				if (plugin.ExpectedArgumentCount!=fd.Count)
					throw new CalcException(fd.FunctionName+" expects "+plugin.ExpectedArgumentCount.ToString()+" parameters");
				else
				{
					return plugin.Evaluate(fd);
				}
			}
		}
	}
}
