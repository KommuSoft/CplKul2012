using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddFlightTemplate")]
	public class RequestAddFlightTemplate : XmlRequestBase
	{
		
		public RequestAddFlightTemplate (){
		}
		
		public RequestAddFlightTemplate (FlightTemplate FlightTemplate){
			this.FlightTemplate = FlightTemplate;
		}
		
		[XmlElement("FlightTemplate")]
		public FlightTemplate FlightTemplate{
			get;
			set;
		}		

		public override IXmlAnswer execute ()
		{
			Database.FlightTemplate template = new Database.FlightTemplate(this.FlightTemplate.Code);
			AnswerAdd aa = new AnswerAdd();

			try{
				template.insert();
			} catch(Exception e){
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}


	}
}

