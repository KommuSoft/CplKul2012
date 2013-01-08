using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddCity")]
	public class RequestAddCity : XmlRequestBase
	{

		public RequestAddCity (){
		}		
		
		public RequestAddCity (City City){
			this.City = City;
		}		
		
		[XmlElement("City")]
		public City City{
			get;
			set;
		}
		
	}
}

