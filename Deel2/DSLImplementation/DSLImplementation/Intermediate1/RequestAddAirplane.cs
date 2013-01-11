using System;
using System.Collections.Generic;

namespace DSLImplementation.IntermediateCode
{
	public class RequestAddAirplane : RequestBase
	{	
		public RequestAddAirplane (Airplane Airplane){
			this.Airplane = Airplane;
		}		

		public Airplane Airplane{ get; set; }	

		public override IAnswer execute ()
		{
			List<int> seats = new List<int> ();
			Database.SeatRequest sr = new Database.SeatRequest ();
			Database.ClassRequest cr = new Database.ClassRequest ();
			bool newSeats = false;

			if (this.Airplane.Seats == null) {
				return new AnswerAdd("The seats of the airplane aren't set");
			}

			foreach (Seat s in this.Airplane.Seats) {
				List<Database.Class> classes = cr.fetchClassFromName (s.SeatClass.Name);
				if(classes.Count != 1){
					return new AnswerAdd("No (unique) class found with name " + s.SeatClass.Name);
				}
				int classID =  classes[0].ID;

				List<Database.Seat> databaseSeats = sr.fetchSeatFromClassAndNumber (class_: classID, number: s.Number);
				if(databaseSeats.Count == 0){
					Database.Seat s_ = new Database.Seat(classID, s.Number, -1);
					try {
						s_.insert();
					} catch (Exception e){
						return new AnswerAdd(e.Message);
					}
					newSeats = true;
					databaseSeats = sr.fetchSeatFromClassNumberAndAirplane (class_: classID, number: s.Number, airplane: -1);
				}
				int seatID =  databaseSeats[0].ID;
				seats.Add (seatID);
			}

			Database.Airplane airplane = new Database.Airplane (type: this.Airplane.Type, seat: seats, code: this.Airplane.Code);
			AnswerAdd aa = new AnswerAdd ();
			try {
				int airplaneID = airplane.insert();
				if (newSeats){
					sr.updateSeats(airplaneID);
				}
			} catch (Exception e) {
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
	}
}

