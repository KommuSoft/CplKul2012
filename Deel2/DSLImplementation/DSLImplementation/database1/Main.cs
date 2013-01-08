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

	private static void tryCatch (DatabaseTable dt)
	{
		try {
			dt.insert();
		} catch (Exception e) {
			Console.WriteLine("Exception: " + e.Message);
		}
	}

	public static void Main (string[] args)
	{
		AirlineRequest alr = new AirlineRequest ();
		AirplaneRequest pr = new AirplaneRequest ();
		CityRequest cr = new CityRequest ();
		AirportRequest ar = new AirportRequest ();
		FlightRequest fr = new FlightRequest ();
		LocationRequest lr = new LocationRequest ();
		ClassRequest clr = new ClassRequest ();
		CountryRequest cnr = new CountryRequest ();
		SeatRequest sr = new SeatRequest ();
		SeatPriceRequest spr = new SeatPriceRequest ();
		PassengerRequest par = new PassengerRequest ();
		BookingRequest br = new BookingRequest();

		//------------------------------------------------------
		Console.WriteLine ("Find the airline with ID = 1");
		println (alr.fetchFromID (1));

		//------------------------------------------------------
		Console.WriteLine ("Find airplane with ID = 1");
		println (pr.fetchFromID (1));

		//------------------------------------------------------
		Console.WriteLine ("Find the airport with ID = 1");
		println (ar.fetchFromID (1));
	
		Console.WriteLine ("Find the airports that are in a city with ID = 1");
		println (ar.fetchAirportFromCity (1));

		Console.WriteLine ("Find the airports that are in a city with name ILIKE brussels");
		println (ar.fetchAirportFromCityName ("brussels"));

		Console.WriteLine ("Find the airports that are in a city with name ILIKE brussels and in a country with name ILIKE belgium");
		println (ar.fetchAirportFromCityNameAndCountryName ("brussels", "belgium"));

		//------------------------------------------------------
		Console.WriteLine ("Find the city with ID = 1");
		println (cr.fetchFromID (1));

		Console.WriteLine ("Find the cities that are in a country with ID = 1");
		println (cr.fetchCityFromCountry (1));

		Console.WriteLine ("Find the cities that are in a country with name ILIKE belgium");
		println (cr.fetchCityFromCountry (new Country ("belgium")));

		//------------------------------------------------------
		Console.WriteLine ("Find the class with ID = 1");
		println (clr.fetchFromID (1));

		//------------------------------------------------------
		Console.WriteLine ("Find the country with ID = 1");
		println (cnr.fetchFromID (1));

		//------------------------------------------------------
		Console.WriteLine ("Find the flight with location = 1");
		List<Flight> flights = fr.fetchFlight (1);
		print (flights);

		Flight f0 = flights [0];
		Location l0 = lr.fetchFromID (f0.location) [0];

		Console.WriteLine ("\tFrom: " + cr.fetchFromID (l0.start_airport) [0].name + "\tTo: " + cr.fetchFromID (l0.destination_airport) [0].name);
		List<Seat> seats = sr.fetchSeatFromFlight (f0.ID);

		Console.WriteLine ("\n\tThe seats with their price");
		foreach (Seat s in seats) {
			List<SeatPrice> seatprices = spr.fetchSeatPriceFromSeatAndFlight (s.ID, f0.ID);
			Console.Write ("\t" + s + " -> ");
			print (seatprices);
		}
		Console.WriteLine ("\n\tThe classes of this flight");
		println (clr.fetchClassFromFlight (f0.ID), "\t");

		DateTime startDateTime = DateTime.Parse ("2012-12-25");
		Console.WriteLine ("Find the flight with location = 1 & airline = 1 & class = 3 & startDateTime = " + startDateTime);
		flights = fr.fetchFlight (1, 1, 3, startDateTime);
		flights.ForEach (delegate(Flight f) {
			Console.WriteLine (f);
		});
		Console.WriteLine ();

		//------------------------------------------------------
		Console.WriteLine ("Find the location with ID = 1");
		println (lr.fetchFromID (1));

		Console.WriteLine ("Find the locations that have as start_airport = 1 and destination_airport = 3");
		println (lr.fetchLocationFromAirports (1, 3));

		//------------------------------------------------------
		Console.WriteLine ("Find the passenger with ID = 1");
		println (par.fetchFromID (1));

		//------------------------------------------------------
		Console.WriteLine ("Find the seat with ID = 1");
		println (sr.fetchFromID (1));

		//------------------------------------------------------
		Console.WriteLine ("Find the seat_price with ID = 1");
		println (spr.fetchSeatPriceFromSeatAndFlight (seatID: 1, flightID: 1));

		//------------------------------------------------------
		Console.WriteLine("Find the booking with passenger's name ILIKE bob");
		println(br.fetchBookingFromPassenger(new Passenger(name: "bob")));

		//------------------------------------------------------
		Console.WriteLine ("Do some valid inserts");
		try{
			Airline ba = new Airline (code: "BA", name: "British Airways");
			ba.insert ();
			
			Airplane a380 = new Airplane (seat: new List<int>{1, 2, 3}, type: "A380");
			a380.insert ();
			
			Airport kjk = new Airport (name: "Kortrijk-Wevelgem International Airport", code: "KJK", country: 1, city: 4, company: new List<int>{});
			City wevelgem = new City(4, "Wevelgem", 1);
			wevelgem.insert();
			int kjkID = kjk.insert();

			int flightAlice = fr.fetchFlight(new Airport(code: "bru"), new Airport(code: "crl"))[0].ID;
			int alice = par.fetchPassengerFromName("alice")[0].ID;
			int classAlice = clr.fetchClassFromFlightAndName(flightID: flightAlice, name: "economy class")[0].ID;
			int seatAlice = sr.fetchSeatFromFlighAndClass(flightID: flightAlice, class_: classAlice)[0].ID;
			Booking bookingAlice = new Booking(flightAlice, alice, seatAlice);
			bookingAlice.insert();
			
			Class superDeluxe = new Class("Super Deluxe");
			int superDeluxeID = superDeluxe.insert();
			
			Country sweden = new Country("Sweden");
			sweden.insert();
			
			Location schipholWevelgem = new Location(2, kjkID, 200);
			schipholWevelgem.insert();
			
			Passenger zoidberg = new Passenger("Zoidberg");
			zoidberg.insert();
			
			Seat seat = new Seat(superDeluxeID, 20);
			int seatID = seat.insert();
			
			SeatPrice expensiveSeat = new SeatPrice(seatID, 2, 10000);
			expensiveSeat.insert();
		} catch(Exception e){
			Console.WriteLine("Unexpected error:");
			Console.WriteLine("    Did you run the main twice?");
			Console.WriteLine("    Are you sure that insert queries are executed? See insert in DatabaseTable");
			Console.WriteLine("    Here is the error: " + e.Message);
		}

		Console.WriteLine ();

		//------------------------------------------------------
		Console.WriteLine ("Do some invalid inserts");

		Airline airline1 = new Airline (code: "", name : "Let 'm crash");
		tryCatch(airline1);

		Airline airline2 = new Airline (code : "TNT", name: "");
		tryCatch(airline2);

		Airline airline3 = new Airline(code: "Too long code", name: "");
		tryCatch(airline3);

		Airplane airplane1 = new Airplane(new List<int>(), "");
		tryCatch(airplane1);

		Airplane airplane2 = new Airplane(new List<int>{9999}, "Citation X");
		tryCatch(airplane2);

		Airport airport1 = new Airport(name: "", code: "BAL", country: 1, city: 1, company: new List<int>());
		tryCatch(airport1);

		Airport airport2 = new Airport(name: ":-)", code: "", country: 1, city: 1, company: new List<int>());
		tryCatch(airport2);

		Airport airport3 = new Airport(name: ":-D", code: "Too long code", country: 1, city: 1, company: new List<int>());
		tryCatch(airport3);

		Airport airport4 = new Airport(name: "Airport in a non-existing country", code : "ABC", country: 9999, city: 1, company: new List<int>());
		tryCatch(airport4);

		Airport airport5 = new Airport(name: "Airport in a non-existing city", code : "XYZ", country:1, city: 9999, company: new List<int>());
		tryCatch(airport5);

		Booking booking1 = new Booking(flight: 999, passenger: 1, seat: 1);
		tryCatch(booking1);

		Booking booking2 = new Booking(flight: 1, passenger: 999, seat: 1);
		tryCatch(booking2);

		Booking booking3 = new Booking(flight: 1, passenger: 1, seat: 999);
		tryCatch(booking3);

		City city1 = new City(name: "", country: 1);
		tryCatch(city1);

		City city2 = new City(name: ":-P", country: 9999);
		tryCatch(city2);

		Class class1 = new Class("");
		tryCatch(class1);

		Country country1 = new Country();
		tryCatch(country1);

		Location location1 = new Location(start_airport: 9999, destination_airport:1, distance: 100);
		tryCatch(location1);

		Location location2 = new Location(start_airport: 1, destination_airport:9999, distance: 100);
		tryCatch(location2);

		Location location3 = new Location(start_airport: 1, destination_airport:1, distance: 0);
		tryCatch(location3);

		Location location4 = new Location(start_airport: 1, destination_airport: 2, distance: -222);
		tryCatch(location4);

		Passenger passenger1 = new Passenger(name: "");
		tryCatch(passenger1);

		Seat seat1 = new Seat(class_: 9999, number: 1);
		tryCatch(seat1);

		Seat seat2 = new Seat(class_: 1, number: -12);
		tryCatch(seat2);

		SeatPrice seatPrice1 = new SeatPrice(seat: 9999, flight: 1, price: 500);
		tryCatch(seatPrice1);

		SeatPrice seatPrice2 = new SeatPrice(seat: 1, flight: 9999, price: 500);
		tryCatch(seatPrice2);

		SeatPrice seatPrice3 = new SeatPrice(seat: 1, flight: 1, price: -1000);
		tryCatch(seatPrice3);


		//------------------------------------------------------
		//TODO test insert flight
		//------------------------------------------------------
		Airport start = new Airport (code: "BRU");
		Airport destination = new Airport (code: "crl");

		println (fr.fetchFlight (start, destination));

		println (fr.fetchFlight(new Country("The Netherlands"), new Country("Belgium")));
		println (fr.fetchFlight(new City("amsterdam"), new City("charleroi")));
	}
}