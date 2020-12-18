using System;
using System.Collections.Generic;

namespace SimpleEvaluator
{
	public class Evaluator 
	{
        private DictionaryVariableProvider VariableList = new();

		public Evaluator():base(){}
		
		public Variant Evaluate(String s)
		{
			ExecutionQueue eq = ParseIt(s);
			return CalcIt(eq);
		}

		protected ExecutionQueue ParseIt(string s)
		{
			Parser p = new Parser();
			p.ParseIt(s);
			return p.eqResult;
		}

        protected Variant CalcIt(ExecutionQueue eq)
		{
			Calculator c = new Calculator(VariableList);
			return c.CalcIt(eq);
		}

		public IDictionary<string, object> Variables
		{
			get
			{
				return VariableList;
			}
		}
	}
}
