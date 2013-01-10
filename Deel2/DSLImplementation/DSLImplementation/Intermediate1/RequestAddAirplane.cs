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
				List<Database.Class> classes = cr.fetchClassFromName (s.SeatClass.Name);
				if(classes.Count == 0){
					return new AnswerAdd("No class found with name " + s.SeatClass.Name);
				}
				int classID =  classes[0].ID;

				List<Database.Seat> databaseSeats = sr.fetchSeatFromClassAndNumber (class_: classID, number: s.Number);
				if(databaseSeats.Count == 0){
					return new AnswerAdd("No seat found with number " + s.Number + " in class " + s.SeatClass.Name);
				}
				int seatID =  databaseSeats[0].ID;
				seats.Add (seatID);
			}

			Database.Airplane airplane = new Database.Airplane (type: this.Airplane.Type, seat: seats, code: this.Airplane.Code);
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

