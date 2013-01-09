using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DSLImplementation.IntermediateCode
{
	[XmlRoot("RequestGetAirports")]
	public class RequestGetAirports : XmlRequestBase
	{
		public RequestGetAirports (City City){
			this.City = City;
		}

		public RequestGetAirports (Country Country){
			this.Country = Country;
		}
		
		[XmlElement("City")]
		public City City{
			get;
			set;
		}
		
		[XmlElement("Country")]
		public Country Country{
			get;
			set;
		}

		private List<Database.Airport> executeOnCountry ()
		{
			Database.AirportRequest ar = new Database.AirportRequest();
			return ar.fetchAirportFromCountry(new Database.Country(this.Country.Name));
		}

		private List<Database.Airport> executeOnCity ()
		{
			Database.AirportRequest ar = new Database.AirportRequest();
			return ar.fetchAirportFromCityAndCountry(new Database.City(this.City.Name),new Database.Country(this.Country.Name));
		}
		
		public override IXmlAnswer execute ()
		{
			List<Database.Airport> airports = new List<Database.Airport>();
			if (this.City != null) {
				airports = executeOnCity();
			} else if (this.Country != null) {
				airports = executeOnCountry();
			}

			Database.AirlineRequest alr = new Database.AirlineRequest();
			List<Airport> resultAirports = new List<Airport>();
			foreach(Database.Airport a in airports){
				Database.CityRequest cir = new Database.CityRequest();
				Database.CountryRequest cor = new Database.CountryRequest();
				Database.City ci = cir.fetchFromID(a.city)[0];
				Database.Country co = cor.fetchFromID(a.country)[0];

				Country country = new Country(co.name);

				List<Airline> airlines = new List<Airline>();
				foreach(int airline in a.company){
					Database.Airline al = alr.fetchFromID(airline)[0];
					airlines.Add(new Airline(Name: al.name, Code: al.code));
				}
				resultAirports.Add(new Airport(Name: a.name, Code: a.code, City: new City(ci.name, country), Airlines: airlines));
			}

			return new AnswerGetAirports(resultAirports);
		}		
		
	}
}

