using System;
using System.Collections.Generic;
using DSLImplementation.IntermediateCode;
using DSLImplementation.UserInterface;

namespace DSLImplementation.Tiling {

	[TilePattern]
	public class RequestAddBookingTilePattern : TilePatternBase {

		private static readonly Tree<TypeBind> bindtree = new Tree<TypeBind>(typeof(BookingPiece),new Tree<TypeBind>(new TypeBind(typeof(PassengerPiece),"name","passengername")),new Tree<TypeBind>(typeof(FlightPiece),new TypeBind(typeof(FlightTemplatePiece),"code","flighttemplatecode"),new TypeBind(typeof(TimePiece),"time","time")),new Tree<TypeBind>(new TypeBind(typeof(SeatPiece),"number","seatnumber"),new TypeBind(typeof(ClassPiece),"name","classname")));

		public RequestAddBookingTilePattern () : base(bindtree) {
		}

		protected override IRequest InternalToTransferCode (IPuzzlePiece root, Dictionary<string, object> bindings) {
			return new RequestAddBooking(new Booking(new Passenger((string) bindings["passengername"]),
			                                         new Flight(new FlightTemplate((string) bindings["flighttemplatecode"]),
			           (DateTime) bindings["time"]),new Seat(new SeatClass((string) bindings["classname"]),(int) bindings["seatnumber"])));
		}

	}
}

