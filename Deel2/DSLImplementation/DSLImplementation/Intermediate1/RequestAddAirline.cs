using System;
namespace DSLImplementation.IntermediateCode
{
	public class RequestAddAirline : XmlRequestBase
	{
		public RequestAddAirline(Airline Airline){
			this.Airline = Airline;
		}

		public Airline Airline{ get; set; }	

		public override IXmlAnswer execute()
		{
			Database.Airline airline = new Database.Airline(code: this.Airline.Code, name: this.Airline.Name);
			AnswerAdd aa = new AnswerAdd();

			try{
				airline.insert();
			} catch(Exception e){
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
	}
}

