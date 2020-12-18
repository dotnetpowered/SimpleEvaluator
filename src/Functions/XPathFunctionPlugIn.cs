using System;
using System.IO;
using System.Xml.XPath;
using SimpleEvaluator;

namespace SimpleEvaluator.Functions
{
	/// <summary>
	/// XPath Function
	/// </summary>
	public class XPathFunctionPlugIn : IFunctionPlugIn
	{
		public XPathFunctionPlugIn() {}

		public Variant Evaluate(FunctionDesc fd)
		{
			XPathDocument doc=new XPathDocument(new StringReader(fd[0]));
			string xpath=fd[1];

			XPathNavigator navigator=doc.CreateNavigator();
			XPathNodeIterator iterator=navigator.Select(xpath);
			if (iterator.MoveNext())
				return iterator.Current.Value;
			else 
				return new Variant(string.Empty);
		}
		
		public string FunctionName
		{
			get
			{
				return "XPATH";
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

