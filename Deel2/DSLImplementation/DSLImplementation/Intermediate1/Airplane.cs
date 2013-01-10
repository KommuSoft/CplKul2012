using System;
using System.Collections.Generic;
namespace DSLImplementation.IntermediateCode
{
	public class Airplane
	{	
		public Airplane (String Type, List<Seat> Seats)
		{
			this.Type = Type;
			this.Seats = Seats;
		}

		public String Type { get; set; }
		public List<Seat> Seats { get; set; }
	}
}

