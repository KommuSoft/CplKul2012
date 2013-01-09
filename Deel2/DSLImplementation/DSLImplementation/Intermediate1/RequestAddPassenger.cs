using System;
using System.Xml.Serialization;
namespace DSLImplementation.IntermediateCode
{
	[XmlRoot("RequestAddPassenger")]
	public class RequestAddPassenger : XmlRequestBase
	{
		public RequestAddPassenger (){
		}
		
		public RequestAddPassenger (Passenger Passenger){
			this.Passenger = Passenger;
		}
		
		[XmlElement("Passenger")]
		public Passenger Passenger{
			get;
			set;
		}	

		public override IXmlAnswer execute ()
		{
			Database.Passenger passenger = new Database.Passenger (this.Passenger.Name);
			AnswerAdd aa = new AnswerAdd ();

			try {
				passenger.insert();
			} catch (Exception e) {
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
		
	}
}

