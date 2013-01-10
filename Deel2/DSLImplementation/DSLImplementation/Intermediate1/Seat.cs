using System;
namespace DSLImplementation.IntermediateCode
{
	public class Seat
	{		
		public Seat(SeatClass SeatClass, int Number){
			this.SeatClass = SeatClass;
			this.Number = Number;
		}

		public SeatClass SeatClass { get; set; }
		public int Number { get; set; }	
	}
}

