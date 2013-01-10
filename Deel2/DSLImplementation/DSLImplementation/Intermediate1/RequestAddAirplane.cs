using System;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class RequestAddAirplane : XmlRequestBase
	{	
		public RequestAddAirplane (Airplane Airplane){
			this.Airplane = Airplane;
		}		

		public Airplane Airplane{ get; set; }	

		public override IXmlAnswer execute ()
		{
			List<int> seats = new List<int> ();
			Database.SeatRequest sr = new Database.SeatRequest ();
			Database.ClassRequest cr = new Database.ClassRequest ();

			foreach (Seat s in this.Airplane.Seats) {
				//TODO in plaats van hier direct het nulde element te nemen moet de size van de lijst gecontroleerd worden
				int classID = cr.fetchClassFromName (s.SeatClass.Name) [0].ID;
				int seatID = sr.fetchSeatFromClassAndNumber (class_: classID, number: s.Number) [0].ID;
				seats.Add (seatID);
			}

			Database.Airplane airplane = new Database.Airplane (type: this.Airplane.Type, seat: seats);
			AnswerAdd aa = new AnswerAdd ();
			try {
				airplane.insert();
			} catch (Exception e) {
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
	}
}

