using System;
using System.Data;
using System.Collections.Generic;

using DSLImplementation.Database;

public class Test
{
	public static void Main (string[] args)
	{
		CityRequest cr = new CityRequest ();

		Console.WriteLine ("Find the city with ID = 1");
		Console.WriteLine (cr.fetchCityFromID (1) + "\n");

		Console.WriteLine ("Find the cities that are in a country with ID = 1");
		List<City> cities = cr.fetchCitiesFromCountry (1);
		cities.ForEach (delegate(City c) {
			Console.WriteLine (c);
		});
		Console.WriteLine ();

		//------------------------------------------------------
		AirportRequest ar = new AirportRequest ();

		Console.WriteLine ("Find the airport with ID = 1");
		Console.WriteLine (ar.fetchAirportFromID (1) + "\n");

		Console.WriteLine ("Find the airports that are in a city with ID = 1");
		List<Airport> airports = ar.fetchAirportsFromCity (1);
		airports.ForEach (delegate(Airport a) {
			Console.WriteLine (a);
		});
		Console.WriteLine ();

		//------------------------------------------------------
		FlightRequest fr = new FlightRequest ();
		LocationRequest lr = new LocationRequest ();
		ClassRequest clr = new ClassRequest ();
		ClassPriceRequest cpr = new ClassPriceRequest();

		Console.WriteLine ("Find the flight with location = 1");
		List<Flight> flights = fr.fetchFlightFromLocation (1);
		flights.ForEach (delegate(Flight f) {
			Console.WriteLine (f);
		});

		Flight f0 = flights [0];
		Location l0 = lr.fetchLocationFromID (f0.location)[0];

		Console.WriteLine ("\tFrom: " + cr.fetchCityFromID (l0.start_city)[0].name + "\tTo: " + cr.fetchCityFromID (l0.destination_city)[0].name);
		List<Class> classes = clr.fetchClassFromFlight (f0.ID);
		foreach (Class c in classes) {
			Console.WriteLine(c);
			Console.WriteLine(cpr.fetchClassPriceFromID(c.ID));
		}

		Console.WriteLine();

		DateTime startDateTime = DateTime.Parse("2012-01-15");
		Console.WriteLine("Find the flight with location = 2 & airline = 1 & class = 3 & startDateTime = " + startDateTime);
		flights = fr.fetchFlightFromLocation(2, 1, 3, startDateTime);
		flights.ForEach(delegate(Flight f){
			Console.WriteLine(f);
		});

		//------------------------------------------------------
//		Booking b = new Booking(1, 2, 2, 200);
//		b.insert();
	}
}