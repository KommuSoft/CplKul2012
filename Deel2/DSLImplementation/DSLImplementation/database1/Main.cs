using System;
using System.Data;
using System.Collections.Generic;

using DSLImplementation.Database;

public class Test
{
	public static void print<T> (List<T> l, string prefix = "")
	{
		l.ForEach (delegate(T t) {
			Console.WriteLine (prefix + t);
		});
	}

	public static void println<T> (List<T> l, string prefix = "")
	{
		print (l, prefix);
		Console.WriteLine ();
	}

	public static void Main (string[] args)
	{
		CityRequest cr = new CityRequest ();

		Console.WriteLine ("Find the city with ID = 1");
		println (cr.fetchCityFromID (1));

		Console.WriteLine ("Find the cities that are in a country with ID = 1");
		println (cr.fetchCitiesFromCountry (1));

		//------------------------------------------------------
		AirportRequest ar = new AirportRequest ();

		Console.WriteLine ("Find the airport with ID = 1");
		println (ar.fetchAirportFromID (1));

		Console.WriteLine ("Find the airports that are in a city with ID = 1");
		println (ar.fetchAirportsFromCity (1));

		//------------------------------------------------------
		FlightRequest fr = new FlightRequest ();
		LocationRequest lr = new LocationRequest ();
		ClassRequest clr = new ClassRequest ();
		/*SeatRequest sr = new SeatRequest ();
		SeatPriceRequest spr = new SeatPriceRequest ();*/

		Console.WriteLine ("Find the flight with location = 1");
		List<Flight> flights = fr.fetchFlightFromLocation (1);
		print (flights);

		Flight f0 = flights [0];
		Location l0 = lr.fetchLocationFromID (f0.location) [0];

		Console.WriteLine ("\tFrom: " + cr.fetchCityFromID (l0.start_city) [0].name + "\tTo: " + cr.fetchCityFromID (l0.destination_city) [0].name);
		/*List<Seat> seats = sr.fetchSeatFromFlight (f0.ID);

		Console.WriteLine("\n\tThe seats with their price");
		foreach (Seat s in seats) {
			List<SeatPrice> seatprices = spr.fetchSeatPriceFromSeatAndFlight(s.ID, f0.ID);
			Console.Write("\t" + s + " -> ");
			print (seatprices);
		}*/
		Console.WriteLine("\n\tThe classes of this flight");
		println(clr.fetchClassFromFlight (f0.ID), "\t");

		DateTime startDateTime = DateTime.Parse ("2012-12-25");
		Console.WriteLine ("Find the flight with location = 1 & airline = 1 & class = 3 & startDateTime = " + startDateTime);
		flights = fr.fetchFlight (1, 1, 3, startDateTime);
		flights.ForEach (delegate(Flight f) {
			Console.WriteLine (f);
		});

		//------------------------------------------------------
//		Booking b = new Booking(1, 2, 2, 200);
//		b.insert();
	}
}