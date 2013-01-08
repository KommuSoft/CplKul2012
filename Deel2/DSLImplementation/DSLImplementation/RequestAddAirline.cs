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
			AnswerAdd aa = new AnswerAdd();

			try{
				airline.insert();
			} catch(Exception e){
				aa = new AnswerAdd(e.Message);
			}

			//TODO maak op de juiste manier het antwoord
			return aa;
		}
	}
}

