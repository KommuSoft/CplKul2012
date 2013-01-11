using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DSLImplementation.IntermediateCode{
	public class XmlMain{

		private static void printFlights (RequestGetFlights rgf)
		{
			Console.WriteLine(((AnswerGetFlights)rgf.execute()).Flights.Count());
		}

		private static void tryPrintFlights (RequestGetFlights rgf)
		{
			try {
				printFlights(rgf);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}

		private static void testGetters(){
			Country country1 = new Country("belgium");
			Country country2 = new Country("onbestaand land");
			
			City city1 = new City("brussels", country1);
			City city2 = new City("onbestaande stad", country1);
			City city3 = new City("brussels", country2);
			
			RequestGetAirports rgaCity1 = new RequestGetAirports(city1);
			Console.WriteLine(((AnswerGetAirports)rgaCity1.execute()).Airports.Count());
			
			RequestGetAirports rgaCity2 = new RequestGetAirports(city2);
			Console.WriteLine(((AnswerGetAirports)rgaCity2.execute()).Airports.Count());
			
			RequestGetAirports rgaCity3 = new RequestGetAirports(city3);
			Console.WriteLine(((AnswerGetAirports)rgaCity3.execute()).Airports.Count());
			
			RequestGetAirports rgaCountry1 = new RequestGetAirports(country1);
			Console.WriteLine(((AnswerGetAirports)rgaCountry1.execute()).Airports.Count());
			
			RequestGetAirports rgaCountry2 = new RequestGetAirports(country2);
			Console.WriteLine(((AnswerGetAirports)rgaCountry2.execute()).Airports.Count());
			
			RequestGetCities rgcCountry1 = new RequestGetCities(country1);
			Console.WriteLine(((AnswerGetCities)rgcCountry1.execute()).Cities.Count());
			
			RequestGetCities rgcCountry2 = new RequestGetCities(country2);
			Console.WriteLine(((AnswerGetCities)rgcCountry2.execute()).Cities.Count());
			
			
			//----------------------
			Country belgium = new Country("belgium");
			Country netherlands = new Country("the netherlands");
			Airline sn = new Airline("sn");
			Airline unknownAirline = new Airline("UNK");
			SeatClass economy = new SeatClass("economy class");
			SeatClass unknownClass = new SeatClass("unknown class");
			
			RequestGetFlights rgf1 = new RequestGetFlights(netherlands, belgium);
			printFlights(rgf1);
			
			RequestGetFlights rgf2 = new RequestGetFlights(netherlands, belgium, new DateTime(year: 2012, month: 1, day: 16));
			printFlights(rgf2);
			
			RequestGetFlights rgf3 = new RequestGetFlights(netherlands, belgium, Airline: sn);
			printFlights(rgf3);
			
			RequestGetFlights rgf4 = new RequestGetFlights(netherlands, belgium, SeatClass: economy);
			printFlights(rgf4);
			
			RequestGetFlights rgf5 = new RequestGetFlights(netherlands, belgium, new DateTime(year: 2012, month: 1, day: 16), Airline: sn, SeatClass: economy);
			printFlights(rgf5);
			
			RequestGetFlights rgf6 = new RequestGetFlights(belgium, netherlands);
			printFlights(rgf6);
			
			RequestGetFlights rgf7 = new RequestGetFlights(netherlands, belgium, Airline: unknownAirline);
			tryPrintFlights(rgf7);
			
			RequestGetFlights rgf8 = new RequestGetFlights(netherlands, belgium, SeatClass: unknownClass);
			tryPrintFlights(rgf8);
			
			RequestGetFlights rgf9 = new RequestGetFlights(netherlands, belgium, new DateTime(year: 3009, month: 3, day: 14));
			tryPrintFlights(rgf9);
		}

		private static void printAddAnswer (IAnswer a)
		{
			AnswerAdd aa = (AnswerAdd) a;
			Console.WriteLine(aa.message);
		}

		private static void testAddCountry ()
		{
			Country c1 = new Country("");
			RequestAddCountry rac1 = new RequestAddCountry(c1);
			printAddAnswer(rac1.execute());

			Country c2 = new Country("Bladibla");
			RequestAddCountry rac2 = new RequestAddCountry(c2);
			//printAddAnswer(rac2.execute());

			Country c3 = new Country("belgium");
			RequestAddCountry rac3 = new RequestAddCountry(c3);
			printAddAnswer(rac3.execute());
		}

		private static void executeAddCity (City c)
		{
			RequestAddCity rac = new RequestAddCity(c);
			printAddAnswer(rac.execute());
		}

		private static void testAddCity ()
		{
			Country belgium = new Country("belgium");
			Country unknownLand = new Country("unk");

			City c1 = new City("", belgium);
			executeAddCity(c1);

			City c2 = new City("city", unknownLand);
			executeAddCity(c2);

			City c3 = new City("city", belgium);
		//	executeAddCity(c3);
		}

		private static void executedAddAiport (Airport a)
		{
			RequestAddAirport raa = new RequestAddAirport(a);
			printAddAnswer(raa.execute());
		}

		private static void testAddAirport ()
		{
			Country belgium = new Country("belgium");
			Country unknownCountry = new Country("unknown country");

			City brussels = new City("brussels", belgium);
			City unknownCity1 = new City("unknown city", belgium);
			City unknownCity2 = new City("brussels", unknownCountry);

			Airport a1 = new Airport("", "COO", brussels);
			executedAddAiport(a1);

			Airport a2 = new Airport("The name of the airport", "", brussels);
			executedAddAiport(a2);

			Airport a3 = new Airport("The name of the airport", "COO", unknownCity1);
			executedAddAiport(a3);

			Airport a4 = new Airport("The name of the airport", "COO", unknownCity2);
			executedAddAiport(a4);

			Airport a5 = new Airport("COO");
			executedAddAiport(a5);

			//TODO test airlines

			Airport a6 = new Airport("The name of the airport", "COO", brussels);
			//executedAddAiport(a6);

			Airport a7 = new Airport("The name of the airport", "878", brussels);
			executedAddAiport(a7);

			Airport a8 = new Airport("The name of the airport", "B78", brussels);
			executedAddAiport(a8);
		}

		private static void executeAddFlightTemplate (FlightTemplate f)
		{
			RequestAddFlightTemplate raft = new RequestAddFlightTemplate(f);
			printAddAnswer(raft.execute());
		}

		private static void testAddFlightTemplate ()
		{
			FlightTemplate f1 = new FlightTemplate("");
			executeAddFlightTemplate(f1);

			FlightTemplate f2 = new FlightTemplate("QLKFJMLKJMLJ");
			executeAddFlightTemplate(f2);

			FlightTemplate f3 = new FlightTemplate("666");
			//executeAddFlightTemplate(f3);

			FlightTemplate f4 = new FlightTemplate("CPL");
			executeAddFlightTemplate(f4);
		}

		private static void executeAddAirplane (Airplane a)
		{
			RequestAddAirplane raa = new RequestAddAirplane(a);
			printAddAnswer(raa.execute());
		}

		private static void testAddAirplane ()
		{
			SeatClass seatClass = new SeatClass("economy class");
			SeatClass newSeatClass = new SeatClass("derp class");

			Seat seat = new Seat(seatClass, 1);
			Seat newSeat1 = new Seat(newSeatClass, 666);
			Seat newSeat2 = new Seat(seatClass, 666);

			List<Seat> existingSeats = new List<Seat>{seat};
			List<Seat> newSeats1 = new List<Seat>{seat, newSeat1};
			List<Seat> newSeats2 = new List<Seat>{seat, newSeat2};

			Airplane a1 = new Airplane("code");
			executeAddAirplane(a1);

			Airplane a2 = new Airplane("B747", new List<Seat>(), "");
			executeAddAirplane(a2);

			Airplane a3 = new Airplane("", new List<Seat>(), "code");
			executeAddAirplane(a3);

			Airplane a4 = new Airplane("CX", existingSeats, "code");
			//executeAddAirplane(a4);

			Airplane a5 = new Airplane("CX", newSeats1, "code");
			executeAddAirplane(a5);

			Airplane a6 = new Airplane("CX", newSeats2, "code");
			//executeAddAirplane(a6);

			Airplane a7 = new Airplane("Type", new List<Seat>(), "A380-1");
			executeAddAirplane(a7);
		}

		private static void executeAddPassenger (Passenger p)
		{
			RequestAddPassenger rap = new RequestAddPassenger(p);
			printAddAnswer(rap.execute());
		}

		private static void testAddPassenger ()
		{
			Passenger p1 = new Passenger("");
			executeAddPassenger(p1);

			Passenger p2 = new Passenger("alice");
			//executeAddPassenger(p2);
		}

		private static void executeAddSeatClass (SeatClass s)
		{
			RequestAddSeatClass rasc = new RequestAddSeatClass(s);
			printAddAnswer(rasc.execute());
		}

		private static void testAddSeatClass ()
		{
			SeatClass s1 = new SeatClass("");
			executeAddSeatClass(s1);

			SeatClass s2 = new SeatClass("Economy Class");
			executeAddSeatClass(s2);

			SeatClass s3 = new SeatClass("Presidential class");
			//executeAddSeatClass(s3);
		}

		private static void executeAddAirline (Airline a)
		{
			RequestAddAirline raa = new RequestAddAirline (a);
			printAddAnswer (raa.execute ());
		}

		private static void testAddAirline ()
		{
			Airline a1 = new Airline("UNK");
			executeAddAirline(a1);

			Airline a2 = new Airline("Special name", "Z");
			executeAddAirline(a2);

			Airline a3 = new Airline("Very special name", "ZZZZ");
			executeAddAirline(a3);

			Airline a4 = new Airline("Extreme special name", "987");
			executeAddAirline(a4);

			Airline a5 = new Airline("Normal name", "");
			executeAddAirline(a5);

			Airline a6 = new Airline("", "UNK");
			executeAddAirline(a6);

			Airline a7 = new Airline("Name", "SN");
			executeAddAirline(a7);

			Airline a8 = new Airline("Normal name", "ZZZ");
			//executeAddAirline(a8);
		}

		private static void executeAddBooking (Booking b)
		{
			RequestAddBooking rab = new RequestAddBooking(b);
			printAddAnswer(rab.execute());
		}

		private static void testAddBooking ()
		{
			Passenger alice = new Passenger("alice");
			Passenger unknownPassenger = new Passenger("unknown");

			FlightTemplate template = new FlightTemplate("SN123");
			FlightTemplate unknownTemplate = new FlightTemplate("SN999");

			DateTime start = new DateTime(year: 2012, month: 12, day: 25, hour: 1, minute: 30, second: 00);

			Flight correctflight = new Flight(template, start);
			Flight unknownFlight = new Flight(unknownTemplate, start);

			SeatClass seatClass = new SeatClass("economy class");

			Seat correctSeat = new Seat(seatClass, 1);
			Seat unknownSeat = new Seat(seatClass, 9999);

			Booking b1 = new Booking(unknownPassenger, correctflight, correctSeat);
			executeAddBooking(b1);

			Booking b2 = new Booking(alice, unknownFlight, correctSeat);
			executeAddBooking(b2);

			Booking b3 = new Booking(alice, correctflight, unknownSeat);
			executeAddBooking(b3);

			Booking b4 = new Booking(alice, correctflight, correctSeat);
			//executeAddBooking(b4);
		}

		private static void executeAddFlight (Flight f)
		{
			RequestAddFlight raf = new RequestAddFlight (f);
			printAddAnswer (raf.execute ());
		}

		private static void testAddFlight ()
		{
			Airline sn = new Airline("SN");
			Airline unknownAirline = new Airline("UNK");

			FlightTemplate template = new FlightTemplate("123", sn);
			FlightTemplate unknownTemplate = new FlightTemplate("999", sn);
			//TODO hier testen of het mogelijk is om een flighttemplate te geven die enkel een code heeft

			DateTime start = new DateTime(year: 2012, month: 11, day: 25, hour: 1, minute: 30, second: 0);
			DateTime end = new DateTime(year: 2012, month: 11, day: 25, hour: 3, minute: 30, second: 0);
			DateTime startExists = new DateTime(year: 2012, month: 12, day: 25, hour: 1, minute: 30, second: 0);

			Airport brussels = new Airport("BRU");
			Airport schiphol = new Airport("AMS");
			Airport unknownAirport = new Airport("UNK");

			Airplane B747 = new Airplane("B747-1");
			Airplane unknownAirplane = new Airplane("UNK");

			Flight f1 = new Flight(template, start);
			executeAddFlight(f1);

			Console.WriteLine(); Console.WriteLine("2");
			Flight f2 = new Flight(unknownTemplate, start, end, brussels, schiphol, B747);
			executeAddFlight(f2); 

			Console.WriteLine(); Console.WriteLine("4"); 
			Flight f4 = new Flight(template, start, end, brussels, schiphol, B747);
			executeAddFlight(f4);

			Console.WriteLine(); Console.WriteLine("5"); 
			Flight f5 = new Flight(template, start, end, unknownAirport, schiphol, B747);
			executeAddFlight(f5);

			Console.WriteLine(); Console.WriteLine("6"); 
			Flight f6 = new Flight(template, start, end, brussels, unknownAirport, B747);
			executeAddFlight(f6);

			Console.WriteLine(); Console.WriteLine("3"); 
			Flight f3 = new Flight(unknownTemplate, start, end, brussels, schiphol, B747, 200);
			executeAddFlight(f3); //This adds a location

			Console.WriteLine(); Console.WriteLine("7"); 
			Flight f7 = new Flight(template, start, end, brussels, schiphol, unknownAirplane);
			executeAddFlight(f7);

			Flight f8 = new Flight(template, start, end, brussels, schiphol, B747);
			//executeAddFlight(f8);

			Console.WriteLine(); Console.WriteLine("9"); 
			Flight f9 = new Flight(template, start, end, brussels, schiphol, B747);
			executeAddFlight(f9);
		}

		public static void Main (string[] args){
//			testGetters();
//			testAddCountry();
//			testAddCity();
//			testAddAirport();
//			testAddFlightTemplate();
//			testAddAirplane();
//			testAddPassenger();
//			testAddSeatClass();
//			testAddAirline();
//			testAddBooking();
			testAddFlight();
		}
	}
}

