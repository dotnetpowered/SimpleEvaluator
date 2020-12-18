using System.Collections.Generic;

namespace SimpleEvaluator
{
    public class FunctionDesc : List<Variant>
    {
        private string functionName;

        public FunctionDesc()
        {
            FunctionName = string.Empty;
        }

        public FunctionDesc(string s)
        {
            FunctionName = s;
        }

        public string FunctionName { get => functionName; set => functionName = value; }
    }
}
