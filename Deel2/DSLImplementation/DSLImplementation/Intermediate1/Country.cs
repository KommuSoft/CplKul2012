using System;
namespace DSLImplementation.IntermediateCode
{
	public class Country : ILocation
	{
		public Country(String Name){
			this.Name = Name;
		}

		public String Name{ get; set; }
	}
}

