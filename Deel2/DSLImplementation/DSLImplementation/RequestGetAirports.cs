using System;
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
		
		public AnswerGetAirports execute()
		{
			Database.AirportRequest ar = new Database.AirportRequest();
			if(this.Country != null && this.City != null){
				List<Database.Airport> airports = ar.fetchAirportFromCityAndCountry(new Database.City(this.City.Name),new Database.Country(this.Country.Name));
			} else if(this.Country != null){
				List<Database.Airport> airports = ar.fetchAirportFromCountry(new Database.Country(this.Country.Name));
			} else if(this.City != null){
				List<Database.Airport> airports = ar.fetchAirportFromCity(new Database.City(this.City.Name));
			}
			List<Airport> resultAirports = new List<Airport>();
			foreach(Database.Airport a in airports){
				resultAirports.Add(new Airport(City: this.City , Country: this.Country));
			}

			return new AnswerGetCities(resultAirports);
		}		
		
	}
}

