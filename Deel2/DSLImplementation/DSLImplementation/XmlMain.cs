using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace DSLImplementation.XmlRepresentation{
	public class XmlMain{
		public static void Main (string[] args){
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
				Airport a1 = new Airport("LendeledeAirport", "1", ci1, c, null);
				Airport a2 = new Airport("WielsbekeAirport", "2", ci2, c, null);
				Airport a3 = new Airport("VeurneAirport", "3", ci3, c, null);
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

