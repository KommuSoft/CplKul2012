using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestGetAirports")]
	public class RequestGetAirports : XmlRequestBase
	{
		public RequestGetAirports (City City, Country Country){//TODO: waarom country nog eens megeven? Zit al in City
			this.City = City;
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
		
		public override IXmlAnswer execute()
		{
			Database.AirportRequest ar = new Database.AirportRequest();
			Database.AirlineRequest alr = new Database.AirlineRequest();

			List<Database.Airport> airports = new List<Database.Airport>();
			if(this.Country != null && this.City != null){
				airports = ar.fetchAirportFromCityAndCountry(new Database.City(this.City.Name),new Database.Country(this.Country.Name));
			} else if(this.Country != null){
				airports = ar.fetchAirportFromCountry(new Database.Country(this.Country.Name));
			} else if(this.City != null){
				airports = ar.fetchAirportFromCityName(this.City.Name);
			}
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
					airlines.Add(new Airline(al.name));
				}
				resultAirports.Add(new Airport(Name: a.name, Code: a.code, City: new City(ci.name, country), Airlines: airlines));
			}

			return new AnswerGetAirports(resultAirports);
		}		
		
	}
}

