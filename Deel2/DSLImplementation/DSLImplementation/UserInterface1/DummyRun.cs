using System;

namespace DSLImplementation.UserInterface {

	public class DummyRun : IPuzzleQueryResolver {

		public DummyRun () {

		}

		public IPuzzlePiece[] Resolve (IPuzzlePiece query) {
			return new IPuzzlePiece[] {new TimePiece(),new AirportPiece(),new FlightPiece(),new PassengerPiece(),new PassengerPiece()};
		}

	}
}