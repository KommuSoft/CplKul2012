using System;
namespace DSLImplementation.IntermediateCode
{
	public class RequestAddFlightTemplate : XmlRequestBase
	{
		public RequestAddFlightTemplate (FlightTemplate FlightTemplate){
			this.FlightTemplate = FlightTemplate;
		}

		public FlightTemplate FlightTemplate{ get; set; }		

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

