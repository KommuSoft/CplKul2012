using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddCity")]
	public class RequestAddCity
	{
	
		public RequestAddCity (City City){
			this.City = City;
		}		
		
		public RequestAddCity ()
		{
		}
		
		[XmlElement("City")]
		public City City{
			get;
			set;
		}
		
	}
}

