using System;
namespace DSLImplementation.IntermediateCode
{
	public class RequestAddSeatClass : XmlRequestBase
	{
		public RequestAddSeatClass (SeatClass SeatClass){
			this.SeatClass = SeatClass;
		}

		public SeatClass SeatClass{ get; set; }	

		public override IXmlAnswer execute ()
		{
			Database.Class class_ = new Database.Class(SeatClass.Name);
			AnswerAdd aa = new AnswerAdd();

			try{
				class_.insert();
			} catch(Exception e){
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}

	}
}

