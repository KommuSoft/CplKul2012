using System;
using System.Collections.Generic;
namespace DSLImplementation.IntermediateCode
{
	public class Airplane
	{	
		public Airplane (String Type, List<Seat> Seats, string Code)
		{
			this.Type = Type;
			this.Seats = Seats;
			this.Code = Code;
		}

		public String Type { get; set; }
		public List<Seat> Seats { get; set; }
		public String Code { get; set; }
	}
}

