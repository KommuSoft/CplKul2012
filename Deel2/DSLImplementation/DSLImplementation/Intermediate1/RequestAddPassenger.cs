using System;
namespace DSLImplementation.IntermediateCode
{
	public class RequestAddPassenger : RequestBase
	{
		public RequestAddPassenger (Passenger Passenger){
			this.Passenger = Passenger;
		}

		public Passenger Passenger{ get; set; }	

		public override IAnswer execute ()
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

