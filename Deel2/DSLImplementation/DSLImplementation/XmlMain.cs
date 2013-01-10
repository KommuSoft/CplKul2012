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

		public static void Main (string[] args){
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
			SeatClass economy = new SeatClass("economy class");

			RequestGetFlights rgf1 = new RequestGetFlights(netherlands, belgium);
			printFlights(rgf1);

			RequestGetFlights rgf2 = new RequestGetFlights(netherlands, belgium, new DateTime(year: 2012, month: 1, day: 16));
			printFlights(rgf2);

			RequestGetFlights rgf3 = new RequestGetFlights(netherlands, belgium, Airline: sn);
			printFlights(rgf3);

			RequestGetFlights rgf4 = new RequestGetFlights(netherlands, belgium, SeatClass: economy);
			printFlights(rgf4);

			RequestGetFlights rfg5 = new RequestGetFlights(netherlands, belgium, new DateTime(year: 2012, month: 1, day: 16), Airline: sn, SeatClass: economy);
			printFlights(rfg5);

			return;






			FlightTemplate template = new FlightTemplate("CPL");
			Airline airline = new Airline("SN");
			Airport start = new Airport("BRU");
			Airport end = new Airport("CRL");
			Airplane airplane = new Airplane("B747-1");

			Flight f = new Flight(template, airline, new DateTime(), new DateTime(), start, end, airplane);
			RequestAddFlight raf = new RequestAddFlight(f);
			//AnswerAdd aad = (AnswerAdd)raf.execute();
			//Console.WriteLine(aad.message);
			return;

			//Testje van Jonas
			RequestGetCities rgc = new RequestGetCities(belgium);
			AnswerGetCities agc = (AnswerGetCities) rgc.execute();
			XmlSerializer xr = new XmlSerializer(typeof(AnswerGetCities));
			FileStream fss = File.Open("citiesBelgium.xml", FileMode.Create, FileAccess.Write);
			xr.Serialize(fss, agc);
			fss.Close();

				//File 1
				Country c = new Country("Belgie");
				RequestGetCities cr = new RequestGetCities(c);
				XmlSerializer sCr = new XmlSerializer(typeof(RequestGetCities));
				FileStream fs = File.Open("cityrequest.xml", FileMode.Create, FileAccess.Write);
				sCr.Serialize(fs, cr);
				fs.Close();
			
				//File 2
				City ci1 = new City("Lendelede", c);
				City ci2 = new City("Wielsbeke", c);
				City ci3 = new City("Veurne", c);
				List<Airport> airports = new List<Airport>();
				//Door null te gebruiken zullen er geen airlines 
				//zichtbaar worden in het xml-bestand
				Airport a1 = new Airport("LendeledeAirport", "1", ci1, null);
				Airport a2 = new Airport("WielsbekeAirport", "2", ci2, null);
				Airport a3 = new Airport("VeurneAirport", "3", ci3, null);
				airports.Add(a1);
				airports.Add(a2);
				airports.Add(a3);
				AnswerGetAirports aa = new AnswerGetAirports(airports);
				XmlSerializer sAa = new XmlSerializer(typeof(AnswerGetAirports));
				fs = File.Open("airportanswer.xml", FileMode.Create, FileAccess.Write);
				sAa.Serialize(fs, aa);
				fs.Close();
			
				//File 3
				RequestAddCountry rac = new RequestAddCountry(c);
				XmlSerializer sRac = new XmlSerializer(typeof(RequestAddCountry));
				fs = File.Open("requestAddCountry.xml", FileMode.Create, FileAccess.Write);
				sRac.Serialize(fs, rac);
				fs.Close();
		}
	}
}

