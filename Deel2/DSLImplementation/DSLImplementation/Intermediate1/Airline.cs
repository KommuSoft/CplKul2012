using System;
namespace DSLImplementation.IntermediateCode
{
	public class Airline{
		public Airline (string code)
		{
			this.Code = code;
			//TODO is de parameter de code of de name?
		}
		
		public Airline(String Name, string Code){
			this.Name = Name;
			this.Code = Code;
		}

		public String Name { get; set; }
		public String Code { get; set;}
	}
}

