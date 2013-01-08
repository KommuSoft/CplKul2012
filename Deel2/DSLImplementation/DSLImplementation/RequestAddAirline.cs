using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddAirline")]
	public class RequestAddAirline : XmlRequestBase
	{
		public RequestAddAirline(){
		}
		
		public RequestAddAirline(Airline Airline){
			this.Airline = Airline;
		}

		[XmlElement("Airline")]
		public Airline Airline{
			get;
			set;
		}	

		public override IXmlAnswer execute()
		{
			Database.Airline airline = new Database.Airline(code: this.Airline.Code, name: this.Airline.Name);
			airline.insert();

			//TODO maak op de juiste manier het antwoord
			return null;
		}
	}
}

