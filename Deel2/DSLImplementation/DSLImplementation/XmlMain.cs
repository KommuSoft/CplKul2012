using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace DSLImplementation.XmlRepresentation{
	public class XmlMain{
		public static void Main (string[] args){
				Country c = new Country("Belgie");
				CityRequest cr = new CityRequest(c);
			
				XmlSerializer sCr = new XmlSerializer(typeof(CityRequest));
				FileStream fs = File.Open("cityrequest.xml", FileMode.Create, FileAccess.Write);
				sCr.Serialize(fs, cr);
				fs.Close();
			
				List<Airport> airports = new List<Airport>();
				Airport a1 = new Airport("Lendelede", "1");
				Airport a2 = new Airport("Wielsbeke", "2");
				Airport a3 = new Airport("Veurne", "3");
				airports.Add(a1);
				airports.Add(a2);
				airports.Add(a3);
				AirportAnswer aa = new AirportAnswer(airports);
				XmlSerializer sAa = new XmlSerializer(typeof(AirportAnswer));
				fs = File.Open("airportanswer.xml", FileMode.Create, FileAccess.Write);
				sAa.Serialize(fs, aa);
				fs.Close();
		}
	}
}

